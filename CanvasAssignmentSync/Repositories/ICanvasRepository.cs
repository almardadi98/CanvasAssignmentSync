using CanvasAssignmentSync.Models;

namespace CanvasAssignmentSync.Repositories
{
    public interface ICanvasRepository
    {
        // Connection methods
        public void SetApiToken(string token); 
        public void SetApiUri(Uri uri); // Used by the logic layer to change the api endpoint during runtime.
        public void InitHttpClient();

        // Course methods
        public Task<IEnumerable<Course>?> GetCourses();
        public Task<Course?> GetCourse(int id);
        public Course UpdateCourse(Course course);
        public Task<int> DeleteCourse(Course course);

        // Assignment methods
        public Task<IEnumerable<Assignment>?> GetAssignments();
        public Task<Assignment?> GetAssignment(int courseId, int id);

    }
}
