using CanvasAssignmentSync.Models;

namespace CanvasAssignmentSync.Repositories
{
    public interface ICanvasRepository
    {
        // Course methods
        public Task<IEnumerable<Course>?> GetCourses();
        public Task<Course?> GetCourse(int id);
        public Task<Course?> GetCourse(Course course);
        public Course UpdateCourse(Course course);
        public void DeleteCourse(int id);
        public void DeleteCourse(Course course);

        // Assignment methods
        public Task<IEnumerable<Assignment>?> GetAssignments();
        public Task<Assignment?> GetAssignment(int courseId, int id);
        public Task<Assignment?> GetAssignment(Course course, int id);
        public Task<Assignment?> GetAssignment(Assignment assignment);
    }
}
