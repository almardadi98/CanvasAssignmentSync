using CanvasAssignmentSync.Data;
using CanvasAssignmentSync.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;

namespace CanvasAssignmentSync.Repositories
{
    /// <summary>
    /// Hybrid implementation for courses.
    /// Some attributes are stored in a local database and injected into the models when they are requested.
    /// </summary>
    public class CanvasRepository : ICanvasRepository
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly CourseDbContext _courseDbContext;
        private readonly CancellationToken _cancellationToken;
        public List<Course> CoursesLocal { get; set; } = new List<Course>();

        public CanvasRepository(HttpClient httpClient, IConfiguration configuration, CourseDbContext dbContext, CancellationToken cancellationToken)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _courseDbContext = dbContext;
            _cancellationToken = cancellationToken;

            _httpClient.BaseAddress = new Uri(_configuration["Canvas:APIURI"]);

            _httpClient.DefaultRequestHeaders.Add(
                HeaderNames.Authorization, $"Bearer {_configuration["Canvas:APIKey"]}");


            GetCoursesFromDb();
        }

        private void GetCoursesFromDb()
        {
            CoursesLocal = _courseDbContext.Courses.ToList();
        }


        /// <summary>
        /// Currently the ShouldSync attribute is the only one that needs to be stored and injected
        /// </summary>
        /// <param name="coursesFromCanvas"></param>
        /// <returns>Nothing. Modifies the list directly</returns>
        private void InjectCourseAttributes(List<Course> coursesFromCanvas)
        {
            // Iterate over all sync enabled courses from Db
            foreach (var courseFromDb in CoursesLocal.Where(course => course.ShouldSync))
            {
                var courseFromCanvas = coursesFromCanvas.FirstOrDefault(c => c.Id == courseFromDb.Id);
                if (courseFromCanvas != null) courseFromCanvas.ShouldSync = true;
            }
        }


        /// <summary>
        /// Gets the courses from Canvas API. Creates the courses in the local db to store additional attributes.
        /// Injects the stored attributes to the models e.g. ShouldSync
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Course>?> GetCourses()
        {
            var coursesFromCanvas = await _httpClient.GetFromJsonAsync<List<Course>?>("courses", cancellationToken: _cancellationToken);
            if (coursesFromCanvas == null) return null;
            await CreateCoursesInLocalDb(coursesFromCanvas); // If there are any new Courses, they get created here
            InjectCourseAttributes(coursesFromCanvas);
            return coursesFromCanvas;
        }


        /// <summary>
        /// Begins tracking all the courses in the list.
        /// </summary>
        /// <param name="coursesFromCanvas"></param>
        private async Task CreateCoursesInLocalDb(IEnumerable<Course> coursesFromCanvas)
        {
            foreach (var course in coursesFromCanvas)
            {
                _courseDbContext.Courses.Add(course);
            }
            await _courseDbContext.SaveChangesAsync(_cancellationToken);

            GetCoursesFromDb();
        }

        public async Task<Course?> GetCourse(int id)
        {
            return await _httpClient.GetFromJsonAsync<Course?>($"courses/{id}", cancellationToken: _cancellationToken);
        }

        public async Task<Course?> GetCourse(Course course)
        {
            var id = course.Id;
            return await GetCourse(id);
        }

        /// <summary>
        /// Since the courses are tracked by EF core, we only need to update the course in the CoursesLocal to update it in the database
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        public Course UpdateCourse(Course course)
        {
            var courseToUpdate = CoursesLocal.FirstOrDefault(course);
            courseToUpdate.ShouldSync = course.ShouldSync;
            return courseToUpdate;
        }

        public void DeleteCourse(int id)
        {
            var courseToRemove = CoursesLocal.FirstOrDefault(course => course.Id == id);
            if (courseToRemove == null) return;
            _courseDbContext.Courses.Remove(courseToRemove);
            GetCoursesFromDb();
        }

        public void DeleteCourse(Course course)
        {
            _courseDbContext.Courses.Remove(course);
            GetCoursesFromDb();
        }

        /// <summary>
        /// Get assignments for all courses in local database.
        /// </summary>
        /// <returns>An IEnumerable of Assignment models</returns>
        public async Task<IEnumerable<Assignment>?> GetAssignments()
        {

            var assignments = new List<Assignment>();

            foreach (var course in CoursesLocal)
            {
                var courseAssignments = await _httpClient.GetFromJsonAsync<List<Assignment>?>($"courses/{course.Id}/assignments", cancellationToken: _cancellationToken);
                if (courseAssignments is not null) assignments.AddRange(assignments);

            }
            return assignments;
        }

        public async Task<Assignment?> GetAssignment(int courseId, int id)
        {
            return await _httpClient.GetFromJsonAsync<Assignment?>($"courses/{courseId}/assignments/{id}", cancellationToken: _cancellationToken);
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
