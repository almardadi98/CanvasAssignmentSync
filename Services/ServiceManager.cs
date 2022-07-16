using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Abstractions;
using Domain.Repositories;

namespace Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<ICanvasService> _lazyCanvasService;
        private readonly Lazy<IMsToDoService> _lazyMsToDoService;

        public ServiceManager(IRepositoryManager repositoryManager)
        {
            _lazyCanvasService = new Lazy<ICanvasService>(() => new CanvasService(repositoryManager));
            _lazyMsToDoService = new Lazy<IMsToDoService>(() => new MsToDoService(repositoryManager));
        }

        public ICanvasService CanvasService => _lazyCanvasService.Value;

        public IMsToDoService MsToDoService => _lazyMsToDoService.Value;


    }
}
