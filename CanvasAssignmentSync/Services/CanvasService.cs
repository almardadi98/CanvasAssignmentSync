using CanvasAssignmentSync.Models;
using CanvasAssignmentSync.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;

namespace CanvasAssignmentSync.Services
{

    public class CanvasService : ICanvasService
    {
        private readonly IConfiguration _configuration;
        private readonly CanvasRepository _repository;

        public CanvasService(IConfiguration configuration, CanvasRepository repository)
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

        public void SetApiToken(string token)
        {
            throw new NotImplementedException();
        }

        public void SetApiUri(Uri uri)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Course>?> GetCourses()
        {
            return await _repository.GetCourses();
        }

        public async Task<Course?> GetCourse(int id)
        {
            return await _repository.GetCourse(id);
        }

        public async Task<Course?> GetCourse(Course course)
        {
            var id = course.Id;
            return await GetCourse(id);
        }

        public Course UpdateCourse(Course course)
        {
            return _repository.UpdateCourse(course);
        }

        public async Task<int?> DeleteCourse(int id)
        {
            var courseToDelete = await _repository.GetCourse(id);
            if (courseToDelete is null) return null;
            return await DeleteCourse(courseToDelete);
        }

        public async Task<int?> DeleteCourse(Course course)
        {
            return await _repository.DeleteCourse(course);
        }

        public async Task<IEnumerable<Assignment>?> GetAssignments()
        {
            return await _repository.GetAssignments();
        }

        public async Task<Assignment?> GetAssignment(int courseId, int id)
        {
            return await _repository.GetAssignment(courseId, id);
        }

        public async Task<Assignment?> GetAssignment(Course course, int id)
        {
            var courseId = course.Id;
            return await GetAssignment(courseId, id);
        }

        public async Task<Assignment?> GetAssignment(Assignment assignment)
        {
            var courseId = assignment.CourseId;
            var id = assignment.Id;
            return await GetAssignment(courseId, id);
        }


    }
}
