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
        public List<Course> CoursesLocal { get; set; } = new List<Course>();

        private Uri ApiUri { get; set; }
        private string ApiToken { get; set; }

        public CanvasRepository(HttpClient httpClient, IConfiguration configuration, CourseDbContext dbContext)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _courseDbContext = dbContext;

            ApiUri = new Uri(_configuration["Canvas:APIURI"]);
            ApiToken = _configuration["Canvas:APIKey"];

            InitHttpClient();
            GetCoursesFromDb();
        }

        public void SetApiToken(string token)
        {
            ApiToken = token;
        }

        public void SetApiUri(Uri uri)
        {
            ApiUri = uri;
        }

        /// <summary>
        /// Configure the API endpoint and authorization header.
        /// </summary>
        public void InitHttpClient()
        {
            _httpClient.BaseAddress = ApiUri;

            _httpClient.DefaultRequestHeaders.Add(
                HeaderNames.Authorization, $"Bearer {ApiToken}");

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
            GetCoursesFromDb(); // Update the CoursesLocal property in case any changes have been made to the db.
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
        public async Task<List<Course>?> GetCourses(CancellationToken cancellationToken)
        {
            var coursesFromCanvas = await _httpClient.GetFromJsonAsync<List<Course>?>("courses", cancellationToken: cancellationToken);
            if (coursesFromCanvas == null) return null;
            await CreateCoursesInLocalDb(coursesFromCanvas, cancellationToken); // If there are any new Courses, they get created here
            InjectCourseAttributes(coursesFromCanvas);
            return coursesFromCanvas;
        }


        /// <summary>
        /// Begins tracking all the courses in the list.
        /// </summary>
        /// <param name="coursesFromCanvas"></param>
        private async Task CreateCoursesInLocalDb(IEnumerable<Course> coursesFromCanvas, CancellationToken cancellationToken)
        {
            foreach (var course in coursesFromCanvas)
            {
                // If the course is already in the db, skip the iteration
                if (CoursesLocal.Contains(course)) continue;
                //_courseDbContext.Courses.Add(course);
            }
            await _courseDbContext.SaveChangesAsync(cancellationToken);

            GetCoursesFromDb();
        }

        public async Task<Course?> GetCourse(int id, CancellationToken cancellationToken)
        {
            return await _httpClient.GetFromJsonAsync<Course?>($"courses/{id}", cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Since the courses are tracked by EF core, we only need to update the course in the CoursesLocal to update it in the database
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        public Course UpdateCourse(Course course) // TODO course not updating in db
        {
            var courseToUpdate = CoursesLocal.FirstOrDefault(course);
            courseToUpdate.ShouldSync = course.ShouldSync;
            _courseDbContext.SaveChanges();
            return courseToUpdate;
        }


        /// <summary>
        /// Stop tracking the course and then save the changes to remove it from the database.
        /// </summary>
        /// <param name="course"></param>
        /// <returns>
        /// A task that represents the asynchronous save operation. The task result contains the
        /// number of state entries written to the database.
        /// </returns>
        public async Task<int> DeleteCourse(Course course, CancellationToken cancellationToken)
        {
            _courseDbContext.Courses.Remove(course);
            return await _courseDbContext.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Get assignments for all courses in local database.
        /// </summary>
        /// <returns>An IEnumerable of Assignment models</returns>
        public async Task<List<Assignment>?> GetAssignments(CancellationToken cancellationToken)
        {

            var assignments = new List<Assignment>();

            foreach (var course in CoursesLocal)
            {
                var courseAssignments = await _httpClient.GetFromJsonAsync<List<Assignment>?>($"courses/{course.Id}/assignments", cancellationToken: cancellationToken);
                if (courseAssignments is not null) assignments.AddRange(assignments);

            }
            return assignments;
        }

        public async Task<Assignment?> GetAssignment(int courseId, int id, CancellationToken cancellationToken)
        {
            return await _httpClient.GetFromJsonAsync<Assignment?>($"courses/{courseId}/assignments/{id}", cancellationToken: cancellationToken);
        }

    }
}
