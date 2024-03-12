using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineInventory.Models
{
    [Table("tbl_stock")]
    public class StockModel
    {
        public int StockId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int WarehouseId { get; set; }
        public virtual WarehouseModel? Warehouse { get; set; }
        public virtual ProductModel? Product { get; set; }
    }
}
