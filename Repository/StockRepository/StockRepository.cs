using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using ims.Data;
using ims.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ims.Repository.StockRepository
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDBContext dbContext;
        public StockRepository(ApplicationDBContext context)
        {
            dbContext = context;

        }
        public Task<List<Stock>> GetAllAsync()
        {
            return dbContext.Stocks.ToListAsync();
        }

        public async Task<Stock?> GetOneAsync(int id)
        {
            var stock = await dbContext.Stocks.FindAsync(id);
            if (stock == null)
            {
                return null;
            }
            return stock;
        }

        public int GetAvaliableBySku(string sku)
        {
            var record = dbContext.Stocks.Where(s => s.Sku == sku).OrderByDescending(s => s.CreatedAt).FirstOrDefault();
            if (record == null)
            {
                return 0;
            }
            return record.Avaliable;
        }

        public async Task<Stock> Create(Stock record)
        {
            await dbContext.Stocks.AddAsync(record);
            await dbContext.SaveChangesAsync();
            return record;
        }
    }
}