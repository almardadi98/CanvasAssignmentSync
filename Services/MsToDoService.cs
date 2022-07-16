using Contracts;
using Domain.Repositories;
using Services.Abstractions;

namespace Services
{
    internal sealed class MsToDoService : IMsToDoService
    {
        private readonly IRepositoryManager _repositoryManager;
        public MsToDoService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<IEnumerable<MsToDoTaskDto>?> GetTasks(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<MsToDoTaskDto?> GetTask(string id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task CreateTask(MsToDoTaskCreateDto task)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateTask(MsToDoTaskUpdateDto task)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteTask(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<MsToDoTaskListDto>?> GetTaskLists(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<MsToDoTaskListDto?> GetTaskList(string id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task CreateTaskList(MsToDoTaskListCreateDto taskList)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateTaskList(MsToDoTaskListUpdateDto taskList)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteTaskList(string id)
        {
            throw new NotImplementedException();
        }
    }
}
