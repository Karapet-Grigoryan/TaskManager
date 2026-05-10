using Microsoft.AspNetCore.Mvc;
using TaskManager.BLL;
using TaskManager.BLL.DTOs;

namespace TaskManager.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService service)
        {
            _taskService = service;
        }

        // ===================== INDEX =====================
        public async Task<IActionResult> Index()
        {
            var tasks = await _taskService.GetAllTasksAsync();

            return View(tasks);
        }

        // ===================== DETAILS =====================
        public async Task<IActionResult> Detalis(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }

            var task = await _taskService.GetTaskByIdAsync(id);

            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        // ===================== CREATE =====================
        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreateTaskDto() { Title = string.Empty });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateTaskDto dto)
        {
            if (dto.DueDate.HasValue && dto.DueDate.Value < DateTime.Now)
            {
                ModelState.AddModelError(nameof(dto.DueDate), "Due date cannot be in the past.");
            }

            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            await _taskService.CreateTaskAsync(dto);

            return RedirectToAction(nameof(Index));
        }

        // ===================== EDIT =====================
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var task = await _taskService.GetTaskByIdAsync(id);

            if (task == null)
            {
                return NotFound();
            }

            var dto = new UpdateTaskDto
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                Status = task.Status,
                Priority = task.Priority,
                DueDate = task.DueDate,
                UserId = task.UserId
            };

            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateTaskDto dto)
        {
            if (dto.DueDate.HasValue && dto.DueDate.Value < DateTime.Now)
            {
                ModelState.AddModelError(nameof(dto.DueDate),"Due date cannot be in the past.");
            }

            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            var updated = await _taskService.UpdateTaskAsync(dto);

            if (!updated)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }

        // ===================== DELETE =====================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delet(int id)
        {
            var deleted = await _taskService.DeleteTaskAsync(id);

            if (!deleted)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }

        // ===================== SEARCH =====================
        [HttpGet]
        public async Task<IActionResult> Search(string title)
        {
            var tasks = await _taskService.SearchTasksByNameAsync(title);

            return PartialView("_TaskTablePartial", tasks);
        }
    }
}
