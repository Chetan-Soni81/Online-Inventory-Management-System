using OnlineInventory.Models;
using OnlineInventory.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineInventory.Repositories.User
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public int CreateUser(RegisterViewModel model)
        {
            try
            {
                var user = new UserModel
                {
                    Username = model.Username,
                    Password = model.Password,
                    RoleId = model.RoleId,
                };

                _context.Users.Add(user);
                _context.SaveChanges();

                return user.Id;
            } catch
            {
                return 0;
            }
        }

        public int CreateUserDetails(RegisterDetailViewModel model)
        {
            try
            {
                var userDetails = new UserDetailsModel
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    MobileNo = model.MobileNo,
                    Address = model.Address,
                    UserId = model.UserId,
                };

                _context.UsersDetails.Add(userDetails);
                _context.SaveChanges();

                return userDetails.UserDetailId;
            } 
            catch
            {
                return 0;
            }
        }
    }

    public interface IUserRepository
    {
        public int CreateUser(RegisterViewModel model);
        public int CreateUserDetails(RegisterDetailViewModel model);
    }
}
