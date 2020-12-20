using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using DomainLayer.Engine;
using Microsoft.VisualBasic.FileIO;

namespace DomainLayer.Models
{
    public class Users : Model<Users>
    {
        [Key] public int? ModelId { get; set; }
        
        public DateTime? CreatedAt { get; set; }

        [Required] [DisplayName("Přihlašovací jméno")] public string Username { get; set; }
        
        [Required] [DisplayName("Heslo")] public string Password { get; set; }

        [Required] [DisplayName("Jméno")] public string FirstName { get; set; }

        [Required] [DisplayName("Příjmení")] public string LastName { get; set; }
        
        [Required] [EmailAddress] [DisplayName("Email")] public string Email { get; set; }
        
        [DisplayName("Telefon")] public int? PhoneNumber { get; set; }
        
        public string IsManager { get; set; }

        [DisplayName("Nadřízený")] public int? SeniorModelId { get; set; }
        
        public string Deleted { get; set; }

        public Users(Connection connection) : base(connection) {}

        public new Users LoadOne()
        {
            return Load().FirstOrDefault();
        }
        
        public new IEnumerable<Users> Load()
        {
            Deleted = false.ToString().ToLower();
            return base.Load();
        }
        
        public new void Save()
        {
            CreatedAt = DateTime.Now;
            Deleted = false.ToString().ToLower();
            IsManager = false.ToString().ToLower();
            base.Save();
        }

        public new void Delete()
        {
            if (!HasSeniorAssigned()) return;
            
            AssignTasksToSenior();
            Deleted = true.ToString().ToLower();
            base.Save();
        }

        public string GetFullName()
        {
            return FirstName + " " + LastName;
        }

        public bool HasSeniorAssigned()
        {
            return LoadOne().SeniorModelId != null;
        }

        public List<Users> LoadSeniors()
        {
            return Load().Where(user => !user.HasSeniorAssigned()).ToList();
        }

        public Users GetSenior()
        {
            return SeniorModelId == null ? null : new Users(Connection) {ModelId = SeniorModelId}.LoadOne();
        }
        
        private void AssignTasksToSenior()
        {
            var tasks = new Tasks(Connection) { UserModelId = ModelId } .Load();

            foreach (var task in tasks)
            {
                var newestTask = task.GetNewestEvent();
                
                var taskEvent = new TasksEvents(Connection)
                {
                    TaskModelId = task.ModelId,
                    UserModelId = SeniorModelId,
                    CreatedAt = DateTime.Now,
                    Status = newestTask == null ? TasksEvents.StatusInProgress : newestTask.Status,
                    Time = 0,
                    Text = "Předáno na kolegu"
                };
                
                task.AddTaskEvent(taskEvent);
            }
        }

        public void Promote()
        {
            IsManager = true.ToString().ToLower();
            base.Save();
        }

        public bool Manager()
        {
            return IsManager == true.ToString().ToLower();
        }
    }
}