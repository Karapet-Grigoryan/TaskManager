using Microsoft.EntityFrameworkCore;
using TaskManager.DAL.TaskManagerModel;

namespace TaskManager.DAL
{
    internal class TaskRepository : ITaskRepository
    {
        private readonly TaskManagerContext _context;

        public TaskRepository(TaskManagerContext context)
        {
            _context = context; // ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<TodoTask>> GetAllTasksAsync()
        {
            return await _context.TodoTasks
                .Include(t => t.Status)
                .Include(t => t.Priority)
                .Include(t => t.User)
                .ToListAsync();
        }

        public async Task<TodoTask?> GetTaskByIdAsync(int id)
        {
            return await _context.TodoTasks
                .Include(t => t.Status)
                .Include(t => t.Priority)
                .Include(t => t.User)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<int> CreateTaskAsync(TodoTask task)
        {
            await _context.TodoTasks.AddAsync(task);
            await _context.SaveChangesAsync();
            return task.Id;
        }

        public async Task<bool> UpdateTaskAsync(TodoTask task)
        {
            _context.TodoTasks.Update(task);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteTaskAsync(int id)
        {
            if (id < 0)
            {
                return false;
            }

            var task = await _context.TodoTasks.FindAsync(id);

            if (task == null) return false;

            _context.TodoTasks.Remove(task);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<TodoTask>> SearchTasksByNameAsync(string title)
        {
            return await _context.TodoTasks
                .Include(t => t.Status)
                .Include(t => t.Priority)
                .Include(t => t.User)
                .Where(t => t.Title.Contains(title))
                .ToListAsync();
        }

    }
}