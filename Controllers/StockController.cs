using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ims.Data;
using Microsoft.AspNetCore.Mvc;

namespace ims.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private ApplicationDBContext context;
        public StockController(ApplicationDBContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var stocks = this.context.Stocks.ToList();
            return Ok(stocks);
        }

        [HttpGet("{id}")]
        public IActionResult GetOne([FromRoute] int id)
        {
            var stock = this.context.Stocks.Find(id);

            if (stock == null)
            {
                return NotFound();
            }
            return Ok(stock);
        }
    }
}