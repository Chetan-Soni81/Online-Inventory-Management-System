﻿using Microsoft.EntityFrameworkCore;
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
                .HasForeignKey<UserModel>(e => e.Id)
                .IsRequired();
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<UserDetailsModel> UsersDetails { get; set; }
        public DbSet<RoleModel> Roles { get; set; }
        public DbSet<PermissionModel> Permissions { get; set; }
    }
}
