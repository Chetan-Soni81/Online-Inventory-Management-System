using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineInventory.Models;

namespace OnlineInventory.Repositories
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserDetailsModel>()
                .HasOne(e => e.User)
                .WithOne(e => e.UserDetails)
                .HasForeignKey<UserModel>(e => e.Id);

            modelBuilder.Entity<UserModel>()
                .HasOne(e => e.Role)
                .WithMany(e => e.Users)
                .HasForeignKey(e => e.RoleId);

            modelBuilder.Entity<RoleModel>()
                .HasMany(e => e.Permissions)
                .WithOne(e => e.Role)
                .HasForeignKey(e => e.RoleId);
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<UserDetailsModel> UsersDetails { get; set; }
        public DbSet<RoleModel> Roles { get; set; }
        public DbSet<PermissionModel> Permissions { get; set; }
    }
}
