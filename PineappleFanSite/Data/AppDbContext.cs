using PineappleFanSite.Models;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace PineappleFanSite.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Messages> Messages { get; set; }
        // TODO: Remove Users when we add Identity
        public DbSet<AppUser> Users { get; set; }
        public DbSet<Stories> Stories { get; set; }
    }
}