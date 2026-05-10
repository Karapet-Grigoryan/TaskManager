using System.ComponentModel.DataAnnotations;
using TaskManager.BLL.Enums;

namespace TaskManager.BLL.DTOs
{
    public class CreateTaskDto
    {
        [Required(ErrorMessage = "Title is required.")]
        [StringLength(200,ErrorMessage = "Maximum 200 characters")]
        public required string Title { get; set; }
        [StringLength(1000,ErrorMessage = "Maximum 1000 characters")]
        public string? Description { get; set; }
        [Required]
        public TaskStatusEnum Status { get; set; }
        [Required]
        public PriorityLevelEnum Priority { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DueDate { get; set; }
        [Required(ErrorMessage = "UserId is required.")]
        [Range(1, int.MaxValue)]
        public int UserId { get; set; }
    }
}
