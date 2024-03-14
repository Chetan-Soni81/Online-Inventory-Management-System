using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineInventory.Models
{
    [Table("tbl_category")]
    public class CategoryModel
    {
        [Key]
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public virtual ICollection<ProductModel> Products { get; set; } = new List<ProductModel>();
    }
}
