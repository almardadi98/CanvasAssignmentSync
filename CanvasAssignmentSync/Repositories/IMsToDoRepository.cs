using CanvasAssignmentSync.Models;

namespace CanvasAssignmentSync.Repositories
{
    public interface IMsToDoRepository
    {
        public Task<IEnumerable<MsToDoTask>?> GetTasks();
        public Task<MsToDoTask?> GetTask(int id);
        public Task<MsToDoTask?> GetTask(MsToDoTask task);
        public Task<MsToDoTask> CreateTask(MsToDoTask task);
        public Task<MsToDoTask> UpdateTask(MsToDoTask task);
        public Task<MsToDoTask> DeleteTask(int id);
        public Task<MsToDoTask> DeleteTask(MsToDoTask task);

        public Task<IEnumerable<MsToDoTaskList>?> GetTaskLists();
        public Task<MsToDoTaskList?> GetTaskList(int id);
        public Task<MsToDoTaskList?> CreateTaskList(MsToDoTaskList taskList);
        public Task<MsToDoTaskList> UpdateTaskList(MsToDoTaskList taskList);
        public Task<MsToDoTaskList> DeleteTaskList(int id);
        public Task<MsToDoTaskList> DeleteTaskList(MsToDoTaskList taskList);
    }
}
