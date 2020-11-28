using System;
using System.ComponentModel.DataAnnotations;
using IIS.Engine;

namespace IIS.Models
{
    public class TasksEvents
    {
        const string StatusEntered = "entered";
        const string StatusInProgress = "inProgress";
        const string StatusFinished = "finished";
        
        public IDatabase<TasksEvents> Connection { get; set; }
        
        [Key]
        public int? ModelId { get; set; }
        
        [Required]
        public int? TaskModelId { get; set; }
        
        [Required]
        public int? UserModelId { get; set; }
        
        [Editable(false)]
        public DateTime? CreatedAt { get; set; }

        [Required]
        public string Status { get; set; }
        
        [Required]
        public int? Time { get; set; }
        
        [Required]
        public string Text { get; set; }
    }
}