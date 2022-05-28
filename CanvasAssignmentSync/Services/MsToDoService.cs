using CanvasAssignmentSync.Models;
using Microsoft.Net.Http.Headers;

namespace CanvasAssignmentSync.Data
{
    public class MsToDoService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;


        public MsToDoService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;

            _httpClient.BaseAddress = new Uri(_configuration["MSToDo:APIURI"]);

            //_httpClient.DefaultRequestHeaders.Add
            // TODO skoða Graph pakka vs Normal httpclient
        }

        public async Task<MsToDoTask> GetTask()
        {
            return new MsToDoTask(); //TODO finish
        }
    }
}
