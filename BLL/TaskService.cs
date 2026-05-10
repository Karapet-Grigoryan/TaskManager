using TaskManager.DAL;
using TaskManager.DAL.TaskManagerModel;
using TaskManager.BLL.DTOs;
using TaskManager.BLL.Enums;
using TaskManager.BLL.Extensions;
using System.ClientModel.Primitives;

namespace TaskManager.BLL
{
    internal class TaskService : ITaskService
    {
        private readonly ITaskRepository _repository;

        public TaskService(ITaskRepository repository)
        {
            _repository = repository;
        }

        // ===================== GET ALL =====================
        public async Task<List<TaskDto>> GetAllTasksAsync()
        {
            var tasks = await _repository.GetAllTasksAsync();

            return tasks.Select(t => MapToDto(t)).ToList();     //tasks.Select(MapToDto).ToList();
        }

        // ===================== GET BY ID =====================
        public async Task<TaskDto?> GetTaskByIdAsync(int id)
        {
            var task = await _repository.GetTaskByIdAsync(id);

            return task == null ? null : MapToDto(task);
        }

        // ===================== CREATE =====================
        public async Task<int> CreateTaskAsync(CreateTaskDto dto)
        {
            if (dto.DueDate.HasValue && dto.DueDate.Value < DateTime.Now)
            {
                throw new Exception("Due date cannot be in the past.");
            }

            var task = new TodoTask
            {
                Title = dto.Title,
                Description = dto.Description,
                StatusId = dto.Status.ToInt(),       //(int)dto.Status,
                PriorityId = dto.Priority.ToInt(),   //(int)dto.Priority,
                DueDate = dto.DueDate,
                UserId = dto.UserId,
                CreatedAt = DateTime.Now
            };

            return await _repository.CreateTaskAsync(task);
        }

        // ===================== UPDATE =====================
        public async Task<bool> UpdateTaskAsync(UpdateTaskDto dto)
        {
            if (dto.DueDate.HasValue && dto.DueDate.Value < DateTime.Now)
            {
                return false;
            }

            var task = await _repository.GetTaskByIdAsync(dto.Id);

            if (task == null)
                return false;

            task.Title = dto.Title;
            task.Description = dto.Description;
            task.StatusId = dto.Status.ToInt();       //(int)dto.Status;
            task.PriorityId = dto.Priority.ToInt();   //(int)dto.Priority;
            task.DueDate = dto.DueDate;
            task.UserId = dto.UserId;

            return await _repository.UpdateTaskAsync(task);
        }

        // ===================== DELETE =====================
        public async Task<bool> DeleteTaskAsync(int id)
        {
            if (id <= 0)
            {
                return false;
            }

            return await _repository.DeleteTaskAsync(id);
        }

        // ===================== SEARCH =====================
        public async Task<List<TaskDto>> SearchTasksByNameAsync(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                var ollTasks = await _repository.GetAllTasksAsync();

                return ollTasks.Select(t => MapToDto(t)).ToList(); ;
            }

            title = title.Trim();

            if (title.Length > 200)
            {
                return new List<TaskDto>();
            }

            var tasks = await _repository.SearchTasksByNameAsync(title);

            return tasks.Select(t => MapToDto(t)).ToList();    //return tasks.Select(MapToDto).ToList();
        }

        // ===================== MAPPING =====================
        private TaskDto MapToDto(TodoTask t)
        {
            return new TaskDto
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                CreatedAt = t.CreatedAt,
                DueDate = t.DueDate,

                Status = t.StatusId.ToStatusEnum(),        //(TaskStatusEnum)t.StatusId,
                Priority = t.PriorityId.ToPriorityEnum(),  //(PriorityLevelEnum)t.PriorityId,

                UserId = t.UserId,
                UserName = t.User?.UserName ?? "Unknown"
            };
        }
    }
}

