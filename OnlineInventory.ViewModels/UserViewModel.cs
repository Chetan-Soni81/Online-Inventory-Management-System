using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineInventory.ViewModels
{
    public class UserViewModel
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? Role {  get; set; }
    }
}
