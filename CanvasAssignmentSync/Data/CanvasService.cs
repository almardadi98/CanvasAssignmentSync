using CanvasAssignmentSync.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;

namespace CanvasAssignmentSync.Data
{
    /// <summary>
    /// A canvas httpclient with some attributes stored locally e.g. the ShouldSync bool of the courses
    /// </summary>
    public class CanvasService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly CourseDbContext _dbContext;

        public CanvasService(HttpClient httpClient, IConfiguration configuration, CourseDbContext dbContext)
        {

            _httpClient = httpClient;
            _configuration = configuration;
            _dbContext = dbContext;
            // TODO configuration injection (secret store)
            _httpClient.BaseAddress = new Uri(_configuration["Canvas:APIURI"]);

            _httpClient.DefaultRequestHeaders.Add(
                HeaderNames.Authorization, $"Bearer {_configuration["Canvas:APIKey"]}");


        }

        public async Task SeedDataBase()
        {
            var courses = await GetCoursesAsync();
            if (courses is null) return;
            foreach (var course in courses)
            {
                await _dbContext.AddAsync(course);
            } 
            await _dbContext.SaveChangesAsync();
        }

        private static void RandomizeShouldSync(List<Course> courses)
        {
            var random = new Random();
            foreach (var course in courses)
            {
                course.ShouldSync = random.Next(2) == 1;
            }
        }


        private static void SetShouldSyncStatus(IList<Course> coursesFromCanvas, IEnumerable<Course> coursesFromDb)
        {
            // Iterate over all sync enabled courses from Db
            foreach (var courseFromDb in coursesFromDb.Where(course => course.ShouldSync))
            {
                var courseFromCanvas = coursesFromCanvas.FirstOrDefault(c => c.Id == courseFromDb.Id);
                if (courseFromCanvas != null) courseFromCanvas.ShouldSync = true;
            }
        }

        public async Task<List<Course>?> GetCoursesAsync()
        {

            var coursesFromCanvas = await _httpClient.GetFromJsonAsync<List<Course>>("courses");
            if(coursesFromCanvas is null) return null;
            // The courses from the Db hold extra information e.g. the ShouldSync bool is stored only there.
            var coursesFromDb = await _dbContext.Courses.ToListAsync();
            SetShouldSyncStatus(coursesFromCanvas, coursesFromDb);
            return coursesFromCanvas;
        }

        // Get all assignments for courses that have synchronization enabled
        public async Task<List<Assignment>?> GetAssignmentListAsync()
        {
            var courses = await GetCoursesAsync();
            if (courses is null) return null;

            var assignmentList = new List<Assignment>();

            foreach (var course in courses)
            {
                var assignments = await _httpClient.GetFromJsonAsync<List<Assignment>>($"courses/{course.Id}/assignments");
                if (assignments is not null) assignmentList.AddRange(assignments);

            }
            return assignmentList;
        }

        // Ekki nota?
        // Betra að queryia alla í byrjun og geyma í minni
        public async Task<string?> GetCourseNameAsync(int Id)
        {
            var course = await _dbContext.Courses.FindAsync(Id);
            return course?.Name;
        }


        /// <summary>
        /// Gets all courses from the database.
        /// </summary>
        /// <returns>List of courses</returns>
        public async Task<List<Course>> GetCoursesDbAsync()
        {
            return await _dbContext.Courses.ToListAsync();
        }


        /// <summary>
        /// This method add a new product to the DbContext and saves it
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        public async Task<Course> AddCourseDbAsync(Course course)
        {
            try
            {
                await _dbContext.Courses.AddAsync(course);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return course;
        }

        public async Task<List<Course>> UpdateCoursesDbAsync(List<Course> courses)
        {
            foreach (var course in courses)
            {
                await UpdateCourseDbAsync(course);
            }
            return courses;
        }

        public async Task<Course> UpdateCourseDbAsync(Course course)
        {
            try
            {
                // Tracked db object
                var courseFromDb = await _dbContext.Courses.SingleOrDefaultAsync(c => c.Id == course.Id);
                if (courseFromDb != null)
                {
                    courseFromDb.ShouldSync = course.ShouldSync;
                }
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw;
            }

            return course;
        }



        public async Task DeleteCourseDbAsync(Course course)
        {
            try
            {
                _dbContext.Courses.Remove(course);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

    }
}
