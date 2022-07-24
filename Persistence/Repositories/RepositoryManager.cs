using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Persistence.Settings;

namespace Persistence.Repositories
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private Lazy<ICanvasRepository> _lazyCanvasRepository;
        private readonly Lazy<IMsToDoRepository> _lazyMsToDoRepository;
        private readonly  IUserAccessor _userAccessor;
        private readonly IDatabaseRepository _databaseRepository;

        public RepositoryManager(HttpClient httpClient, RepositoryDbContext repositoryDbContext, IHttpContextAccessor accessor, UserManager<IdentityUser> userManager)
        {
            _userAccessor = new UserAccessorRepository(accessor);
            _lazyMsToDoRepository = new Lazy<IMsToDoRepository>(() => new MsToDoRepository(repositoryDbContext));
            _databaseRepository = new DatabaseRepository(repositoryDbContext, _userAccessor, userManager);
            _lazyCanvasRepository = new Lazy<ICanvasRepository>(() => new CanvasRepository(httpClient, null));
        }


        public async Task InitializeCanvasRepository(HttpClient httpClient, UserManager<IdentityUser> userManager, RepositoryDbContext repositoryDbContext)
        {
            var canvasOptions = await _databaseRepository.GetCanvasOptions(); // TODO
            var result = CanvasRepository.Connect(canvasOptions);
        }


        public ICanvasRepository CanvasRepository => _lazyCanvasRepository.Value;

        public IMsToDoRepository MsToDoRepository => _lazyMsToDoRepository.Value;

        public IDatabaseRepository DatabaseRepository => _databaseRepository;
    }
}
