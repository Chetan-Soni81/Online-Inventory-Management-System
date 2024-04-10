using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineInventory.ViewModels
{
    public class WarehouseViewModel
    {
        public int WarehouseId { get; set; }
        [Required]
        public string? WarehouseName { get; set; }
        [Required]
        public string? City { get; set; }
        [Required]
        public string? Country { get; set; }
    }
}
