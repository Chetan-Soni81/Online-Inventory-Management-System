using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineInventory.ViewModels
{
    public class RegisterDetailViewModel
    {
        public int UserId { get; set; }
        [Required(ErrorMessage ="* First Name is required")]
        public string? FirstName { get; set; }
        public string?  LastName { get; set; }
        [Required(ErrorMessage = "* Mobile No. is required")]
        [MinLength(10, ErrorMessage = "* Invalid Mobile Number")]
        public string? MobileNo { get; set; }
        [Required(ErrorMessage = "* Email is required")]
        [EmailAddress(ErrorMessage = "* Invalid Email Address")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "* Address is required")]
        public string? Address { get; set; }
    }
}
