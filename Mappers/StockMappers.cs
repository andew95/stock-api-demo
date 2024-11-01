using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ims.Dtos.Stock;
using ims.Models;

namespace ims.Mappers
{
    public static class StockMappers
    {
        public static StockDto ToStockDto(this Stock record)
        {
            return new StockDto
            {
                Id = record.Id,
                Sku = record.Sku,
                Description = record.Description,
                In = record.In,
                Out = record.Out,
                Avaliable = record.Avaliable,
                CreatedAt = record.CreatedAt.ToString("yyyy-mm-dd H:mm:ss zzz"),
            };
        }

        public static Stock ToStockFromCreateStockRequestDto(this CreateStockRequestDto request)
        {
            return new Stock
            {
                Sku = request.Sku,
                Description = request.Description,
                In = request.In,
                Out = request.Out,
                CreatedAt = DateTime.Now
            };
        }
    }
}