using System;
using System.Collections.Generic;

namespace TaskManager.DAL.TaskManagerModel;

public partial class TodoTask
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public int PriorityId { get; set; }

    public int StatusId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? DueDate { get; set; }

    public int UserId { get; set; }

    public virtual PriorityLevel Priority { get; set; } = null!;

    public virtual TaskStatus Status { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
