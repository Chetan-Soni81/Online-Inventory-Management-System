using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineInventory.Models
{ 
    [Table("tbl_role")]
    public class RoleModel
    {
        [Key]
        public int RoleId { get; set; }
        public string? RoleName { get; set; }
        public string? RoleDescription { get; set; }
        public virtual ICollection<UserModel>? Users { get; set; }
        public virtual ICollection<PermissionModel>? Permissions { get; set; }
    }
}
