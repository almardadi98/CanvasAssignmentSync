using CanvasAssignmentSync.Models;
using CanvasAssignmentSync.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;

namespace CanvasAssignmentSync.Services
{

    public class CanvasService : ICanvasService
    {
        private readonly IConfiguration _configuration;
        private readonly ICanvasRepository _repository;

        public CanvasService(IConfiguration configuration, ICanvasRepository repository)
        {
            _configuration = configuration;
            _repository = repository;

        }

        /// <summary>
        /// Request api token from canvas. User logs in and accepts.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<string> RequestApiToken()
        {
            throw new NotImplementedException();
        }

        public string GetApiToken()
        {
            return _repository.GetApiToken();
        }

        public void SetApiToken(string token)
        {
            _repository.SetApiToken(token);
        }

        public Uri GetApiUri()
        {
            return _repository.GetApiUri();
        }

        public void SetApiUri(Uri uri)
        {
            _repository.SetApiUri(uri);
        }

        public async Task<List<Course>?> GetCourses(CancellationToken cancellationToken)
        {
            return await _repository.GetCourses(cancellationToken);
        }

        public async Task<Course?> GetCourse(int id, CancellationToken cancellationToken)
        {
            return await _repository.GetCourse(id, cancellationToken);
        }

        public async Task<Course?> GetCourse(Course course, CancellationToken cancellationToken)
        {
            var id = course.Id;
            return await GetCourse(id, cancellationToken);
        }

        public Course UpdateCourse(Course course)
        {
            return _repository.UpdateCourse(course);
        }

        public List<Course> UpdateCourses(List<Course> courses)
        {
            foreach (var course in courses)
            {
                UpdateCourse(course);
            }
            return courses;
        }

        public async Task<int?> DeleteCourse(int id, CancellationToken cancellationToken)
        {
            var courseToDelete = await _repository.GetCourse(id, cancellationToken);
            if (courseToDelete is null) return null;
            return await DeleteCourse(courseToDelete, cancellationToken);
        }

        public async Task<int?> DeleteCourse(Course course, CancellationToken cancellationToken)
        {
            return await _repository.DeleteCourse(course, cancellationToken);
        }

        public async Task<List<Assignment>?> GetAssignments(CancellationToken cancellationToken)
        {
            return await _repository.GetAssignments(cancellationToken);
        }

        public async Task<Assignment?> GetAssignment(int courseId, int id, CancellationToken cancellationToken)
        {
            return await _repository.GetAssignment(courseId, id, cancellationToken);
        }

        public async Task<Assignment?> GetAssignment(Course course, int id, CancellationToken cancellationToken)
        {
            var courseId = course.Id;
            return await GetAssignment(courseId, id, cancellationToken);
        }

        public async Task<Assignment?> GetAssignment(Assignment assignment, CancellationToken cancellationToken)
        {
            var courseId = assignment.CourseId;
            var id = assignment.Id;
            return await GetAssignment(courseId, id, cancellationToken);
        }


    }
}
