using CanvasAssignmentSync.Models;
using CanvasAssignmentSync.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;

namespace CanvasAssignmentSync.Services
{

    public class CanvasService
    {
        private readonly IConfiguration _configuration;
        private readonly CanvasRepository _canvasRepository;

        public CanvasService(IConfiguration configuration, CanvasRepository canvasRepository)
        {
            _configuration = configuration;
            _canvasRepository = canvasRepository;

        }



    }
}
