using OnlineInventory.Models;
using OnlineInventory.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineInventory.Repositories.Role
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDbContext _context;

        public RoleRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<RoleViewModel> GetAllRoles()
        {
            var roles = _context.Roles.Select( r => new RoleViewModel
            {
                RoleId = r.RoleId,
                RoleName = r.RoleName
            }).ToList();
            return roles;
        }
    }

    public interface IRoleRepository
    {
        List<RoleViewModel> GetAllRoles();
    }
}
