using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineInventory.Models
{
    [Table("tbl_userDetail")]
    public class UserDetailsModel
    {
        [Key]
        public int UserDetailId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MobileNo { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public int UserId { get; set; }
        public virtual UserModel? User { get; set; }
    }
}
