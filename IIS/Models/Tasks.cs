using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using IIS.Engine;

namespace IIS.Models
{
    public class Tasks : Model<Tasks>
    {
        const int RateImplementation = 1000;
        const int RateStandard = 1500;
        const int RateUrgent = 2200;

        [Key]
        public int? ModelId { get; set; }

        [Required]
        public int? ClientModelId { get; set; }
        
        [Required]
        public int? UserModelId { get; set; }
        
        [Required]
        public DateTime? CreatedAt { get; set; }

        [Required]
        public DateTime? ModifiedAt { get; set; }

        [Required]
        public string Title { get; set; }
        
        [Required]
        public int? ExpectedTime { get; set; }
        
        [Required]
        public DateTime? ExpectedDate { get; set; }
        
        [Required]
        public int? Rate { get; set; }

        public Tasks(Connection connection) : base(connection) {}

        public int GetRealTime()
        {
            var tasksEvents = GetTasksEvents();
            return tasksEvents.Sum(tasksEvent => tasksEvent.Time.GetValueOrDefault());
        }

        public bool IsOverTime()
        {
            return ExpectedTime < GetRealTime();
        }

        public double GetPrice()
        {
            var ratePerMinute = Rate / 60;
            return ratePerMinute.GetValueOrDefault() * GetRealTime();
        }

        public IEnumerable<TasksEvents> GetTasksEvents()
        {
            return new TasksEvents(Connection) { TaskModelId = ModelId } .Load();
        }

        public TasksEvents GetNewestEvent()
        {
            return GetTasksEvents().LastOrDefault();
        }

        public void AddTaskEvent(TasksEvents taskEvent)
        {
            taskEvent.Save();
            
            ModifiedAt = DateTime.Now;
            UserModelId = taskEvent.UserModelId;
            
            Save();
        }
    }
}