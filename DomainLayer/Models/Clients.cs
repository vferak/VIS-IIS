using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using DomainLayer.Engine;

namespace DomainLayer.Models
{
    public class Clients : Model<Clients>
    {
        [Key] public int? ModelId { get; set; }
        
        public DateTime? CreatedAt { get; set; }

        [Required] [DisplayName("Název")] public string Name { get; set; }

        [Required] [DisplayName("Jméno kontaktu")] public string ContactFirstName { get; set; }

        [Required] [DisplayName("Příjmení kontaktu")] public string ContactLastName { get; set; }
        
        [Required] [EmailAddress] [DisplayName("Email kontaktu")] public string ContactEmail { get; set; }
        
        [DisplayName("Telefon kontaktu")] public int? ContactPhoneNumber { get; set; }
        
        public string Deleted { get; set; }

        public Clients(Connection connection) : base(connection) {}
        
        public new Clients LoadOne()
        {
            return Load().FirstOrDefault();
        }
        
        public new IEnumerable<Clients> Load()
        {
            Deleted = false.ToString().ToLower();
            return base.Load();
        }

        public new void Save()
        {
            CreatedAt = DateTime.Now;
            Deleted = false.ToString().ToLower();
            base.Save();
        }
        
        public new void Delete()
        {
            Deleted = true.ToString().ToLower();
            base.Save();
        }

        public double GetPaymentAmountForMonth(int month)
        {
            double result = 0;
            
            var tasks = new Tasks(Connection) {ClientModelId = ModelId} .Load();

            foreach (var task in tasks)
            {
                if (task.GetNewestEvent().CreatedAt?.Month == month)
                {
                    result += task.GetPrice();
                }
            }
            
            return result;
        }
    }
}