using System.ComponentModel.DataAnnotations;

namespace ToDoListProject.Models
{
    public class TaskList
    {
        [Key]
        public int TaskId { get; set; }
        public string TaskDescription { get; set; }=string.Empty;
        public bool Status { get; set; }

    }
}
