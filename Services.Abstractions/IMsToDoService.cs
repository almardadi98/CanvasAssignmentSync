using Contracts;

namespace Services.Abstractions
{
    public interface IMsToDoService
    {
        // Task methods
        Task<IEnumerable<MsToDoTaskDto>?> GetTasks(CancellationToken cancellationToken = default);
        Task<MsToDoTaskDto?> GetTask(string id, CancellationToken cancellationToken = default);
        Task CreateTask(MsToDoTaskCreateDto task);
        Task UpdateTask(MsToDoTaskUpdateDto task);
        Task DeleteTask(string id);

        // Task list methods
        Task<IEnumerable<MsToDoTaskListDto>?> GetTaskLists(CancellationToken cancellationToken = default);
        Task<MsToDoTaskListDto?> GetTaskList(string id, CancellationToken cancellationToken = default);
        Task CreateTaskList(MsToDoTaskListCreateDto taskList);
        Task UpdateTaskList(MsToDoTaskListUpdateDto taskList);
        Task DeleteTaskList(string id);

    }
}
