using System.Net.Http.Json;
using Domain.Models.Canvas;
using Domain.Repositories;
using Microsoft.Extensions.Configuration;
using Persistence.Settings;
using System.Net.Http.Headers;

namespace Persistence.Repositories
{
    public class CanvasRepository : ICanvasRepository
    {
        private readonly HttpClient _httpClient;
        private readonly RepositoryDbContext _repositoryDbContext;
        private readonly CanvasOptions _canvasOptions = new();

        public CanvasRepository(HttpClient httpClient, RepositoryDbContext dbContext)
        {
            _httpClient = httpClient;
            _repositoryDbContext = dbContext;

            _canvasOptions.ApiUri = _repositoryDbContext.CanvasApiUri;
            _canvasOptions.ApiKey = _repositoryDbContext.CanvasApiKey;


            InitHttpClient();
        }


        /// <summary>
        /// Configure the API endpoint and authorization header.
        /// </summary>
        public void InitHttpClient()
        {
            _httpClient.BaseAddress = _canvasOptions.ApiUri;

            _httpClient
                .DefaultRequestHeaders
                .Authorization = new AuthenticationHeaderValue($"Bearer", $"{_canvasOptions.ApiKey}");

        }




        public async Task<IEnumerable<Course>> GetCourses(CancellationToken cancellationToken = default)
        {
            var courses =  await _httpClient.GetFromJsonAsync<IEnumerable<Course>>($"courses", cancellationToken);
            return courses ?? Enumerable.Empty<Course>();
        }

        public async Task<Course?> GetCourse(string id, CancellationToken cancellationToken = default)
        {
            return await _httpClient.GetFromJsonAsync<Course?>($"courses/{id}", cancellationToken);
        }


        /// <summary>
        /// Warning! This gets all assignments from all courses. 
        /// </summary>
        /// <param name="courseId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Assignment>> GetAssignments(string courseId, CancellationToken cancellationToken = default)
        {
            var assignments =  await _httpClient.GetFromJsonAsync<List<Assignment>?>($"courses/{courseId}/assignments", cancellationToken);
            return assignments ?? Enumerable.Empty<Assignment>();
        }

        public async Task<Assignment?> GetAssignment(string courseId, string id, CancellationToken cancellationToken = default)
        {
            return await _httpClient.GetFromJsonAsync<Assignment?>($"courses/{courseId}/assignments/{id}", cancellationToken);
        }
    }
}
