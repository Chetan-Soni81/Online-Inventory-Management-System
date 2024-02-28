using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineInventory.Models
{
    public class WarehouseModel
    {
        public int WarehouseId { get; set; }
        public string? WarehouseName { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public virtual ICollection<StockModel> Stocks { get; set; } = new List<StockModel>();
    }
}
