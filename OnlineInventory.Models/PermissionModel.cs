using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineInventory.Models
{
    [Table("tbl_permission")]
    public class PermissionModel
    {
        [Key]
        public int PermissionId { get; set; }
        public int RoleId { get; set; }
        public string? PermissionName { get; set; }
        public string? Module {  get; set; }
        public virtual RoleModel? Role { get; set; }
    }
}
