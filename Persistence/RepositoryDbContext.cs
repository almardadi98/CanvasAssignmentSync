using System.Reflection;
using Domain;
using Domain.Models.Canvas;
using Domain.Models.MsToDo;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public sealed class RepositoryDbContext : DbContext
    {
        public RepositoryDbContext(DbContextOptions options)
            : base(options)
        {
        }


        public Uri CanvasApiUri;

        public string CanvasApiKey;

        public DbSet<Course> CourseSyncBlacklist;

        protected override void OnModelCreating(ModelBuilder modelBuilder) =>
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RepositoryDbContext).Assembly);
    }
}
