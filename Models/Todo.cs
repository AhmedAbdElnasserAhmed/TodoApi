using System.ComponentModel.DataAnnotations;

namespace TodoApi.Models
{
    public class Todo
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [MaxLength(100, ErrorMessage = "Title cannot exceed 100 characters")]
        public string Title { get; set; }

        public string Description { get; set; }

        public TodoStatus Status { get; set; }

        public TodoPriority Priority { get; set; }

        public DateTime? DueDate { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime LastModifiedDate { get; set; }
    }

    public enum TodoStatus
    {
        Pending,
        InProgress,
        Completed
    }

    public enum TodoPriority
    {
        Low,
        Medium,
        High
    }
}