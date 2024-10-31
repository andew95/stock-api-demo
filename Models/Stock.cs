using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ims.Models
{
    [Table("Stocks")]
    public class Stock
    {
        public int Id { get; set; }
        public string Sku { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int In { get; set; }
        public int Out { get; set; }
        public int Avaliable { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}