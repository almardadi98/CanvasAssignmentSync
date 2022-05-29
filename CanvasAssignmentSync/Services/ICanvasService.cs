using CanvasAssignmentSync.Models;

namespace CanvasAssignmentSync.Services
{
    public interface ICanvasService
    {
        // Connection methods
        public Task<string> RequestApiToken(); // Method to automagically retrieve the token.
        public string GetApiToken();
        public void SetApiToken(string token);
        public Uri GetApiUri();
        public void SetApiUri(Uri uri); // Used by the logic layer to change the api endpoint during runtime.

        // Course methods
        public Task<List<Course>?> GetCourses(CancellationToken cancellationToken);
        public Task<Course?> GetCourse(int id, CancellationToken cancellationToken);
        public Task<Course?> GetCourse(Course course, CancellationToken cancellationToken);
        public Course UpdateCourse(Course course);
        public List<Course> UpdateCourses(List<Course> courses);
        public Task<int?> DeleteCourse(int id, CancellationToken cancellationToken);
        public Task<int?> DeleteCourse(Course course, CancellationToken cancellationToken);

        // Assignment methods
        public Task<List<Assignment>?> GetAssignments(CancellationToken cancellationToken);
        public Task<Assignment?> GetAssignment(int courseId, int id, CancellationToken cancellationToken);
        public Task<Assignment?> GetAssignment(Course course, int id, CancellationToken cancellationToken);
        public Task<Assignment?> GetAssignment(Assignment assignment, CancellationToken cancellationToken);

    }
}
