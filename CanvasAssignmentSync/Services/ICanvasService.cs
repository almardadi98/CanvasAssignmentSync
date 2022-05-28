using CanvasAssignmentSync.Models;

namespace CanvasAssignmentSync.Services
{
    public interface ICanvasService
    {
        // Connection methods
        public Task<string> RequestApiToken(); // Method to automagically retrieve the token.
        public void SetApiToken(string token);
        public void SetApiUri(Uri uri); // Used by the logic layer to change the api endpoint during runtime.

        // Course methods
        public Task<IEnumerable<Course>?> GetCourses();
        public Task<Course?> GetCourse(int id);
        public Task<Course?> GetCourse(Course course);
        public Course UpdateCourse(Course course);
        public Task<int?> DeleteCourse(int id);
        public Task<int?> DeleteCourse(Course course);

        // Assignment methods
        public Task<IEnumerable<Assignment>?> GetAssignments();
        public Task<Assignment?> GetAssignment(int courseId, int id);
        public Task<Assignment?> GetAssignment(Course course, int id);
        public Task<Assignment?> GetAssignment(Assignment assignment);

    }
}
