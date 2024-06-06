using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineInventory.ViewModels
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        [Required]
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        [Required]
        public string? ProductImage { get; set; }
        [Required]
        public double Price { get; set; }
        public int SupplierId { get; set; }
        public int CategoryId { get; set; }
    }
}
