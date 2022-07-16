using Domain.Models.MsToDo;
using Domain.Repositories;
using Persistence.Settings;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace Persistence.Repositories
{
    public class MsToDoRepository : IMsToDoRepository
    {
        private readonly RepositoryDbContext _repositoryDbContext;

        public MsToDoRepository(RepositoryDbContext repositoryDbContext)
        {
            _repositoryDbContext = repositoryDbContext;
        }

        public async Task<List<MsToDoTask>> GetTasks(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<MsToDoTask> GetTask(string id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task CreateTask(MsToDoTask task)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateTask(MsToDoTask task)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteTask(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<MsToDoTaskList>> GetTaskLists(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<MsToDoTaskList> GetTaskList(string id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task CreateTaskList(MsToDoTaskList taskList)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateTaskList(MsToDoTaskList taskList)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteTaskList(string id)
        {
            throw new NotImplementedException();
        }
    }
}
