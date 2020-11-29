using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using IIS.Engine;

namespace IIS.Models
{
    public class Clients : Model<Clients>
    {
        [Key]
        public int? ModelId { get; set; }

        [Required]
        public DateTime? CreatedAt { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string ContactFirstName { get; set; }

        [Required]
        public string ContactLastName { get; set; }
        
        [Required]
        public string ContactEmail { get; set; }
        
        public int? ContactPhoneNumber { get; set; }
        
        [Required]
        public int? Deleted { get; set; }

        public Clients(Connection connection) : base(connection) {}
        
        public new Clients LoadOne()
        {
            return Load().FirstOrDefault();
        }
        
        public new IEnumerable<Clients> Load()
        {
            Deleted = 0;
            return Database.Load();
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