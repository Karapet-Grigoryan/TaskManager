using System;
using System.Collections.Generic;

namespace TaskManager.DAL.TaskManagerModel;

public partial class User
{
    public int Id { get; set; }

    public string UserName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<TodoTask> TodoTasks { get; set; } = new List<TodoTask>();
}
