using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineInventory.ViewModels
{
    public class CategoryViewModel
    {
        public int CategoryID { get; set; }
        [Required]
        public string CategoryName { get; set; } = "";
    }
}
