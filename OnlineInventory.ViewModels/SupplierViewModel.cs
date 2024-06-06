using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineInventory.ViewModels
{
    public class SupplierViewModel
    {
        public int SupplierId { get; set; }
        [Required(ErrorMessage = "Supplier Name is required")]
        public string? SupplierName { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? Email { get; set; }
        public string? MobileNo { get; set; }
    }
}
