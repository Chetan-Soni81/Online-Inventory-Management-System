﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineInventory.Models
{
    public class PermissionModel
    {
        public int PermissionId { get; set; }
        public RoleModel? Role { get; set; }
        public string? PermissionName { get; set; }
        public string? Module {  get; set; }
    }
}