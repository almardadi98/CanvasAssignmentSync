using CanvasAssignmentSync.Models;
using Microsoft.Net.Http.Headers;

namespace CanvasAssignmentSync.Data
{
    public class MSToDoService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;


        public MSToDoService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;

            _httpClient.BaseAddress = new Uri(_configuration["MSToDo:APIURI"]);

            //_httpClient.DefaultRequestHeaders.Add
        }
    }
}
