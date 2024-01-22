using PineappleFanSite.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace PineappleFanSite.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Messages> Messages { get; set; }
        // TODO: Remove Users when we add Identity
        public DbSet<AppUser> Users { get; set; }
        public DbSet<Stories> Stories { get; set; }
    }
}