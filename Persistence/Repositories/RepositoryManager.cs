using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Repositories;

namespace Persistence.Repositories
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<ICanvasRepository> _lazyCanvasRepository;
        private readonly Lazy<IMsToDoRepository> _lazyMsToDoRepository;

        public RepositoryManager(HttpClient httpClient, RepositoryDbContext repositoryDbContext)
        {
            _lazyCanvasRepository = new Lazy<ICanvasRepository>( () => new CanvasRepository(httpClient, repositoryDbContext));
            _lazyMsToDoRepository = new Lazy<IMsToDoRepository>(() => new MsToDoRepository(repositoryDbContext));
        }

        public ICanvasRepository CanvasRepository => _lazyCanvasRepository.Value;

        public IMsToDoRepository MsToDoRepository => _lazyMsToDoRepository.Value;
    }
}
