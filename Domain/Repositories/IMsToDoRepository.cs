using Domain.Models.MsToDo;

namespace Domain.Repositories
{
    public interface IMsToDoRepository
    {
        Task<List<MsToDoTask>> GetTasks(CancellationToken cancellationToken = default);

        Task<MsToDoTask> GetTask(string id, CancellationToken cancellationToken = default);

        Task CreateTask(MsToDoTask task);

        Task UpdateTask(MsToDoTask task);

        Task DeleteTask(string id);


        Task<List<MsToDoTaskList>> GetTaskLists(CancellationToken cancellationToken = default);

        Task<MsToDoTaskList> GetTaskList(string id, CancellationToken cancellationToken = default);

        Task CreateTaskList(MsToDoTaskList taskList);

        Task UpdateTaskList(MsToDoTaskList taskList);

        Task DeleteTaskList(string id);
    }
}
