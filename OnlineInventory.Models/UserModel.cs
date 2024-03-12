using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineInventory.Models
{
    [Table("tbl_user")]
    public class UserModel
    {
        [Key]
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public int RoleId { get; set; }
        public int UserDetailId { get; set; }
        public virtual RoleModel? Role { get; set; }
        public virtual UserDetailsModel? UserDetails { get; set; }
    }
}
