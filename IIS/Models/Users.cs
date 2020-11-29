using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using IIS.Engine;
using Microsoft.VisualBasic.FileIO;

namespace IIS.Models
{
    public class Users : Model<Users>
    {
        [Key]
        public int? ModelId { get; set; }

        [Required]
        public DateTime? CreatedAt { get; set; }

        [Required]
        public string Username { get; set; }
        
        [Required]
        public string Password { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        
        [Required]
        public string Email { get; set; }
        
        public int? PhoneNumber { get; set; }
        
        [Required]
        public int? IsManager { get; set; }

        public int? SeniorModelId { get; set; }

        [Required]
        public int? Deleted { get; set; }

        public Users(Connection connection) : base(connection) {}

        public new Users LoadOne()
        {
            return Load().FirstOrDefault();
        }
        
        public new IEnumerable<Users> Load()
        {
            Deleted = 0;
            return base.Load();
        }

        public new void Delete()
        {
            if (!HasSeniorAssigned()) return;
            
            AssignTasksToSenior();
            Deleted = 1;
            Save();
        }

        public bool HasSeniorAssigned()
        {
            return LoadOne().SeniorModelId != null;
        }
        
        private void AssignTasksToSenior()
        {
            var tasks = new Tasks(Connection) { ClientModelId = ModelId } .Load();

            foreach (var task in tasks)
            {
                var taskEvent = new TasksEvents(Connection)
                {
                    TaskModelId = task.ModelId,
                    UserModelId = SeniorModelId,
                    CreatedAt = DateTime.Now,
                    Status = task.GetNewestEvent().Status,
                    Time = 0,
                    Text = "Přenos na seniora"
                };
                
                task.AddTaskEvent(taskEvent);
            }
        }
    }
}