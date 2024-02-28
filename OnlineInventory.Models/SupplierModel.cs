using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineInventory.Models
{
    public class SupplierModel
    {
        public int SupplierId { get; set; }
        public string? SupplierName { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? Email { get; set; }
        public string? MobileNo { get; set; }
        public virtual ICollection<ProductModel> Products { get; set; } = new List<ProductModel>();
    }
}
