using CanvasAssignmentSync.Models;
using Microsoft.EntityFrameworkCore;



namespace CanvasAssignmentSync.Data
{
    public class CourseDbContext : DbContext
    {
        public CourseDbContext(DbContextOptions<CourseDbContext> options) : base(options)
        {

        }

        public DbSet<Course> Courses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().HasData(GetCourses());
            base.OnModelCreating(modelBuilder);
        }



        private List<Course> GetCourses()
        { 
            return new List<Course>();
        }
    }
}
