using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ims.Models;

namespace ims.Repository.StockRepository
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAllAsync();
        Task<Stock?> GetOneAsync(int id);
        Task<Stock> Create(Stock record);

        int GetAvaliableBySku(string sku);
    }
}