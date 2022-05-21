using CanvasAssignmentSync.Models;
using Microsoft.Net.Http.Headers;

namespace CanvasAssignmentSync.Data
{
    public class CanvasService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public CanvasService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            // TODO configuration injection (secret store)
            _httpClient.BaseAddress = new Uri(_configuration["Canvas:APIURI"]);

            _httpClient.DefaultRequestHeaders.Add(
                HeaderNames.Authorization, $"Bearer {_configuration["Canvas:APIKey"]}");
        }
        private void RandomizeShouldSync(List<Course> courses)
        {
            var random = new Random();
            foreach (var course in courses)
            {
                course.ShouldSync = random.Next(2) == 1;
            }
        }
        public async Task<List<Course>?> GetCoursesAsync()
        {

            var courses = await _httpClient.GetFromJsonAsync<List<Course>>("courses");
            RandomizeShouldSync(courses);
            return courses;
        }

        // Get all assignments for courses that have synchronization enabled
        public async Task<List<Assignment>?> GetAssignmentListAsync()
        {
            var courses = await GetCoursesAsync();
            if (courses is null)
            {
                return null;
            }
            List<Assignment> assignmentList = new List<Assignment>();

            foreach (var course in courses)
            {
                var assignments = await _httpClient.GetFromJsonAsync<List<Assignment>>($"courses/{course.ID}/assignments");
                if (assignments is not null)
                {
                    assignmentList.AddRange(assignments);
                }
            }
            return assignmentList;
        }

        // Ekki nota?
        // Betra að queryia alla í byrjun og geyma í minni
        public async Task<string?> GetCourseNameAsync(int Id)
        {
            var course = await _httpClient.GetFromJsonAsync<Course>($"courses/{Id}");
            return course?.Name;
        }

    }
}
