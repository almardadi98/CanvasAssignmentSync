using System.Reflection;
using Domain;
using Domain.Models;
using Domain.Models.Canvas;
using Domain.Models.MsToDo;
using Domain.Settings;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Persistence.Settings;

namespace Persistence
{
    public sealed class RepositoryDbContext : IdentityDbContext
    {
        public RepositoryDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Owner> Owners { get; set; }

        public DbSet<CanvasOptions> CanvasOptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<CanvasOptions>()
                .Property(b => b.Id)
                .ValueGeneratedOnAdd();

            base.OnModelCreating(modelBuilder);
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(RepositoryDbContext).Assembly);
        }
    }
}
