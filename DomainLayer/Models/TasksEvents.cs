using System;
using System.ComponentModel.DataAnnotations;
using DomainLayer.Engine;

namespace DomainLayer.Models
{
    public class TasksEvents : Model<TasksEvents>
    {
        const string StatusEntered = "entered";
        const string StatusInProgress = "inProgress";
        const string StatusFinished = "finished";

        [Key]
        public int? ModelId { get; set; }
        
        [Required]
        public int? TaskModelId { get; set; }
        
        [Required]
        public int? UserModelId { get; set; }
        
        [Required]
        public DateTime? CreatedAt { get; set; }

        [Required]
        public string Status { get; set; }
        
        [Required]
        public int? Time { get; set; }
        
        [Required]
        public string Text { get; set; }

        public TasksEvents(Connection connection) : base(connection) {}
    }
}