using PineappleFanSite.Models;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace PineappleFanSite.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Messages> Messages { get; set; }
        // TODO: Remove Users when we add Identity
        public override DbSet<IdentityUser> Users { get; set; }
        public DbSet<Stories> Stories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUser>()
                .ToTable("AspNetUsers")
                .HasNoDiscriminator();
            
            modelBuilder.Entity<AppUser>()
                .ToTable("AspNetUsers")
                .HasNoDiscriminator();

            modelBuilder.Entity<Messages>()
                .ToTable("Messages");
        }
    }
}