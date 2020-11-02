using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Backend.Core.Models;
using Backend.Core.Models.Auth;
using Backend.Data.Configurations;

namespace Backend.Data
{
    public class RaiseAndReviewDbContext : IdentityDbContext<User, Role, Guid>
    {
        public DbSet<Color> Colors { get; set; }
        public RaiseAndReviewDbContext(DbContextOptions<RaiseAndReviewDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ColorConfiguration());
        }
    }
}