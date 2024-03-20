using Microsoft.EntityFrameworkCore;
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

        public UserViewModel LoginUser(LoginViewModel model)
        {
            var user = new UserViewModel();
                user.UserName = model.Username;
            try
            {
                var obj = _context.Users.Where(e => e.Username == model.Username && e.Password == model.Password).Include(user => user.Role).Select(s => new { Id = s.Id, Role = s.Role!.RoleName }).FirstOrDefault();
                if (obj == null) return user;
                
                user.UserId = obj.Id;
                user.Role = obj.Role;
                return user;
            } catch { return user; }
        }
        public ProfileVIewModel GetUserProfile(int userId)
        {
            try
            {
                var profile = _context.Users
                    .Where(w => w.Id == userId)
                    .Include(u => u.UserDetails)
                    .Include(u => u.Role)
                    .Select( s => new ProfileVIewModel{
                        Username = s.Username,
                        Name = $"{s.UserDetails!.FirstName} {s.UserDetails!.LastName}",
                        MobileNo = s.UserDetails.MobileNo ?? "N/A",
                        Email = s.UserDetails.Email ?? "N/A",
                        Address = s.UserDetails.Address,
                        Role = s.Role!.RoleDescription
                    }).First();

                return profile;
            } catch
            {
                return new ProfileVIewModel();
            }
        }
    }

    public interface IUserRepository
    {
        public int CreateUser(RegisterViewModel model);
        public int CreateUserDetails(RegisterDetailViewModel model);
        public UserViewModel LoginUser(LoginViewModel model);
        public ProfileVIewModel GetUserProfile(int userId);
    }
}
