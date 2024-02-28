using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineInventory.Models
{
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
