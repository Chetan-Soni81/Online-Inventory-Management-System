using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineInventory.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set;}
        public string? ProductImage { get; set;}
        public double Price { get; set; }
        public int SupplierId { get; set; }
        public int CategoryId { get; set; }
        public virtual CategoryModel? Category { get; set; }
        public virtual SupplierModel? Supplier { get; set; }
        public virtual ICollection<ProductModel> Products { get; set; } = new List<ProductModel>();
    }
}
