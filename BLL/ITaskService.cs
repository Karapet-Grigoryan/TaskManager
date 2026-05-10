using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.BLL.DTOs;
using TaskManager.DAL.TaskManagerModel;

namespace TaskManager.BLL
{
    public interface ITaskService
    {
        Task<List<TaskDto>> GetAllTasksAsync();
        Task<TaskDto?> GetTaskByIdAsync(int id);

        Task<int> CreateTaskAsync(CreateTaskDto taskDto);
        Task<bool> UpdateTaskAsync(UpdateTaskDto taskDto);
        Task<bool> DeleteTaskAsync(int id);

        Task<List<TaskDto>> SearchTasksByNameAsync(string title);
    }
}
