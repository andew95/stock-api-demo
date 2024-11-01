using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Threading.Tasks;
using ims.Data;
using ims.Dtos.Stock;
using ims.Mappers;
using ims.Models;
using ims.Repository.StockRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ims.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private IStockRepository _stockRepo;
        public StockController(ApplicationDBContext context, IStockRepository stockRepo)
        {
            _context = context;
            _stockRepo = stockRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var stocks = await _stockRepo.GetAllAsync();
            var response = stocks.Select(s => s.ToStockDto());
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneAsync([FromRoute] int id)
        {
            var stock = await _stockRepo.GetOneAsync(id);

            if (stock == null)
            {
                return NotFound();
            }
            return Ok(stock.ToStockDto());
        }


        [HttpGet("sku")]
        public async Task<IActionResult> GetSkuAsync()
        {
            var stocks = await _context.Stocks.OrderByDescending(s => s.CreatedAt).GroupBy(s => s.Sku).Select(group => new { Sku = group.Key, Stocks = group.ToList() }).ToListAsync();
            var response = stocks.Select(s => s.Stocks.Last().ToStockDto());
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStockRequestDto request)
        {
            var avaliable = _stockRepo.GetAvaliableBySku(request.Sku);
            var stockModel = request.ToStockFromCreateStockRequestDto();

            if (avaliable > 0)
            {
                stockModel.Avaliable = avaliable + stockModel.In;
                stockModel.Avaliable = stockModel.Avaliable - stockModel.Out;
            }
            else
            {
                if (stockModel.In > 0)
                {

                    stockModel.Avaliable = stockModel.In;
                }
                if (stockModel.Out > 0)
                {

                    stockModel.Avaliable = stockModel.Out;
                }
            }
            stockModel = await _stockRepo.Create(stockModel);

            return Ok(stockModel.ToStockDto());
        }
    }
}