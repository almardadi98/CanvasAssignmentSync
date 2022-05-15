using Microsoft.EntityFrameworkCore;
using CanvasAssignmentSync.Models;

namespace CanvasAssignmentSync.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<List<Course>> Courses { get; set; }
    }
}
