using System;
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
        
        [Editable(false)]
        public DateTime? CreatedAt { get; set; }

        [Editable(false)]
        public DateTime? ModifiedAt { get; set; }

        [Required]
        public string Title { get; set; }
        
        [Required]
        public int? ExpectedTime { get; set; }
        
        [Required]
        public DateTime? ExpectedDate { get; set; }
        
        public int? Rate { get; set; }

        public Tasks(Database<Tasks> connection) : base(connection) {}

        public int GetRealTime()
        {
            var tasksEvents = new TasksEvents {TaskModelId = ModelId}.Connection.Load();
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
    }
}