using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ims.Dtos.Stock
{
    public class StockDto
    {
        public int Id { get; set; }
        public string Sku { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int In { get; set; }
        public int Out { get; set; }
        public int Avaliable { get; set; }
        public string CreatedAt { get; set; } = string.Empty;

    }
}