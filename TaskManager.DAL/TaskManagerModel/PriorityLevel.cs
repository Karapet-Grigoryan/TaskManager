using System;
using System.Collections.Generic;

namespace TaskManager.DAL.TaskManagerModel;

public partial class PriorityLevel
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? ColorHexCode { get; set; }

    public virtual ICollection<TodoTask> TodoTasks { get; set; } = new List<TodoTask>();
}
