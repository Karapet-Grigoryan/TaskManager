using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.DAL.TaskManagerModel;

namespace TaskManager.DAL
{
    public interface ITaskRepository
    {
        Task<List<TodoTask>> GetAllTasksAsync();
        Task<TodoTask?> GetTaskByIdAsync(int id);

        Task<int> CreateTaskAsync(TodoTask task);
        Task<bool> UpdateTaskAsync(TodoTask task);
        Task<bool> DeleteTaskAsync(int id);

        Task<List<TodoTask>> SearchTasksByNameAsync(string title);
    }
}
