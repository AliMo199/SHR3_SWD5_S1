using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class TaskItem
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [Display(Name = "Completed")]
        public bool IsCompleted { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? DueDate { get; set; }
    }
}
