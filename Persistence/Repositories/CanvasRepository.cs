using System.Net.Http.Json;
using Domain.Models.Canvas;
using Domain.Repositories;
using Microsoft.Extensions.Configuration;
using Persistence.Settings;
using System.Net.Http.Headers;
using System.Security.Claims;
using Domain.Exceptions;
using Domain.Settings;
using Microsoft.AspNetCore.Identity;

namespace Persistence.Repositories
{
    public class CanvasRepository : ICanvasRepository
    {
        private readonly HttpClient _httpClient;
        private CanvasOptions? _canvasOptions;


        public CanvasRepository(HttpClient httpClient, CanvasOptions? canvasOptions)
        {
            _httpClient = httpClient;
            _canvasOptions = canvasOptions;
            InitHttpClient(_canvasOptions);
        }


        /// <summary>
        /// Try initializing the httpclient.
        /// </summary>
        /// <param name="canvasOptions"></param>
        /// <returns></returns>
        public bool Connect(CanvasOptions? canvasOptions)
        {
            try
            {
                InitHttpClient(canvasOptions ?? _canvasOptions);
                return true;
            }
            catch (NotConfiguredException e)
            {
                return false;
            }
        }

        /// <summary>
        /// Configure the API endpoint and authorization header.
        /// </summary>
        public void InitHttpClient(CanvasOptions canvasOptions)
        {
            if (canvasOptions == null)
            {
                throw new NotConfiguredException("Configuration for Canvas API is null.");
            }
            _httpClient.BaseAddress = canvasOptions.ApiUri;

            _httpClient
                .DefaultRequestHeaders
                .Authorization = new AuthenticationHeaderValue($"Bearer", $"{canvasOptions.ApiKey}");

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
        public async Task<IEnumerable<Assignment>> GetAssignments(int courseId, CancellationToken cancellationToken = default)
        {
            var assignments =  await _httpClient.GetFromJsonAsync<List<Assignment>?>($"courses/{courseId}/assignments", cancellationToken);
            return assignments ?? Enumerable.Empty<Assignment>();
        }

        public async Task<Assignment?> GetAssignment(int courseId, string id, CancellationToken cancellationToken = default)
        {
            return await _httpClient.GetFromJsonAsync<Assignment?>($"courses/{courseId}/assignments/{id}", cancellationToken);
        }
    }
}
