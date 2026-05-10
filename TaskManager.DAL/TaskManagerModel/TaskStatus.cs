using System;
using System.Collections.Generic;

namespace TaskManager.DAL.TaskManagerModel;

public partial class TaskStatus
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<TodoTask> TodoTasks { get; set; } = new List<TodoTask>();
}
