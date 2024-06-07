using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineInventory.ViewModels
{
    public class StockViewModel
    {
        public int StockId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int WarehouseId {get;set;}
        [Required]
        public int Quantity { get; set; }
        public string? ProductName { get; set; }
        public string? WarehouseName { get;set; }
    }
}
