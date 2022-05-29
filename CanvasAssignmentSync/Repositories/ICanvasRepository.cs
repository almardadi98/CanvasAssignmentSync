using CanvasAssignmentSync.Models;

namespace CanvasAssignmentSync.Repositories
{
    public interface ICanvasRepository
    {
        // Connection methods
        public string GetApiToken();
        public void SetApiToken(string token);
        public Uri GetApiUri();
        public void SetApiUri(Uri uri); // Used by the logic layer to change the api endpoint during runtime.
        public void InitHttpClient();

        // Course methods
        public Task<List<Course>?> GetCourses(CancellationToken cancellationToken);
        public Task<Course?> GetCourse(int id, CancellationToken cancellationToken);
        public Course UpdateCourse(Course course);
        public Task<int> DeleteCourse(Course course, CancellationToken cancellationToken);

        // Assignment methods
        public Task<List<Assignment>?> GetAssignments(CancellationToken cancellationToken);
        public Task<Assignment?> GetAssignment(int courseId, int id, CancellationToken cancellationToken);

    }
}
