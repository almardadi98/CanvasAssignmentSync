﻿using CanvasAssignmentSync.Models;
using CanvasAssignmentSync.Repositories;

namespace CanvasAssignmentSync.Services
{
    public class MsToDoService : IMsToDoService
    {
        private readonly IConfiguration _configuration;
        private readonly IMsToDoRepository _repository;

        public MsToDoService(IConfiguration configuration, IMsToDoRepository repository)
        {
            _configuration = configuration;
            _repository = repository;
        }


        public async Task<List<MsToDoTask>?> GetTasks()
        {
            return await _repository.GetTasks();
        }

        public async Task<MsToDoTask?> GetTask(int id)
        {
            return await _repository.GetTask(id);
        }

        public async Task<MsToDoTask?> GetTask(MsToDoTask task)
        {
            return await _repository.GetTask(task);
        }

        public async Task<MsToDoTask> CreateTask(MsToDoTask task)
        {
            return await _repository.CreateTask(task);
        }

        public async Task<MsToDoTask> UpdateTask(MsToDoTask task)
        {
            return await _repository.UpdateTask(task);
        }

        public async Task<MsToDoTask> DeleteTask(int id)
        {
            return await _repository.DeleteTask(id);
        }

        public async Task<MsToDoTask> DeleteTask(MsToDoTask task)
        {
            throw new NotImplementedException();
        }

        public async Task<List<MsToDoTaskList>?> GetTaskLists()
        {
            return await _repository.GetTaskLists();
        }

        public async Task<MsToDoTaskList?> GetTaskList(int id)
        {
            return await _repository.GetTaskList(id);
        }

        public async Task<MsToDoTaskList?> GetTaskList(MsToDoTaskList id)
        {
            throw new NotImplementedException();
        }

        public async Task<MsToDoTaskList?> CreateTaskList(MsToDoTaskList taskList)
        {
            return await _repository.CreateTaskList(taskList);
        }

        public async Task<MsToDoTaskList> UpdateTaskList(MsToDoTaskList taskList)
        {
            return await _repository.UpdateTaskList(taskList);
        }

        public async Task<MsToDoTaskList> DeleteTaskList(int id)
        {
            return await _repository.DeleteTaskList(id);
        }

        public async Task<MsToDoTaskList> DeleteTaskList(MsToDoTaskList taskList)
        {
            throw new NotImplementedException();
        }

        public async Task CheckIfTaskExists(int id)
        {
            throw new NotImplementedException();
        }

        public async Task ConvertCourseToTask(Course course)
        {
            throw new NotImplementedException();
        }

        public async Task ConvertCoursesToTasks(List<Course> courses)
        {
            throw new NotImplementedException();
        }

        public async Task SyncTasks()
        {
            throw new NotImplementedException();
        }
    }
}