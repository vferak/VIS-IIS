using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using DomainLayer.Engine;

namespace DomainLayer.Models
{
    public class Tasks : Model<Tasks>
    {
        public const int RateImplementation = 1000;
        public const int RateStandard = 1500;
        public const int RateUrgent = 2200;

        [Key] public int? ModelId { get; set; }

        [Required] [DisplayName("Klient")] public int? ClientModelId { get; set; }
        
        [Required] public int? UserModelId { get; set; }
        
        public DateTime? CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }

        [Required] [DisplayName("Název")] public string Title { get; set; }
        
        [Required] [DisplayName("Očekávaný čas")] public int? ExpectedTime { get; set; }
        
        [Required] [DisplayName("Očekávané datum")] public DateTime? ExpectedDate { get; set; }
        
        [Required] [DisplayName("Sazba")] public int? Rate { get; set; }

        public Tasks(Connection connection) : base(connection) {}

        public new void Save()
        {
            if (Database.IsInsert())
            {
                CreatedAt = DateTime.Now;
            }
            
            ModifiedAt = DateTime.Now;
            base.Save();
        }
        
        public new void Delete()
        {
            foreach (var tasksEvent in GetTasksEvents())
            {
                tasksEvent.Delete();
            }
            
            base.Delete();
        }
        
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

        public Dictionary<string, int> GetRates()
        {
            return new Dictionary<string, int>
            {
                {"Standardní", RateStandard},
                {"Implementační", RateImplementation},
                {"Urgentní", RateUrgent}
            };
        }

        public string GetStatus(bool translated = false)
        {
            var newestEvent = GetNewestEvent();
            var result = newestEvent?.Status;

            if (translated)
            {
                result = newestEvent?.GetStatuses().FirstOrDefault(i => i.Value == result).Key;
            }
            
            return result;
        }

        public Clients GetClient()
        {
            return new Clients(Connection) { ModelId = ClientModelId }.LoadOne();
        }

        public Users GetUser()
        {
            return new Users(Connection) { ModelId = UserModelId }.Database.LoadOne();
        }
    }
}