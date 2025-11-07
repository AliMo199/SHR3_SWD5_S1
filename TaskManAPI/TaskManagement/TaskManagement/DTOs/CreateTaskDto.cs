using System.ComponentModel.DataAnnotations;

namespace TaskManagement.API.DTOs
{
    public class CreateTaskDto
    {
        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters")]
        public string Title { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        public string? Description { get; set; }

        public bool IsCompleted { get; set; } = false;

        public DateTime? DueDate { get; set; }
    }
}