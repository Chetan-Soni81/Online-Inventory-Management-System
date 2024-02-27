using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineInventory.Models
{
    public class RoleModel
    {
        public int RoleId { get; set; }
        public string? RoleName { get; set; }
        public string? RoleDescription { get; set; }
        public ICollection<UserModel>? Users { get; set; }
        public ICollection<PermissionModel>? Permissions { get; set; }
    }
}
