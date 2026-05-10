using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TaskManager.BLL.Enums;

namespace TaskManager.BLL.DTOs
{
    public class TaskDto
    {
        [Required]
        [Range(1,int.MaxValue)]
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string? Title { get; set; }
        [StringLength(1000)]
        public string? Description { get; set; }
        [Required]
        public TaskStatusEnum Status { get; set; }
        [Required]
        public PriorityLevelEnum Priority { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreatedAt { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DueDate { get; set; }
        [Required]
        public required string UserName { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int UserId { get; set; }

    }
}
