using System;
using System.ComponentModel.DataAnnotations;
using IIS.Engine;

namespace IIS.Models
{
    public class Clients
    {
        public IDatabase<Clients> Connection { get; set; }
        
        [Key]
        public int? ModelId { get; set; }

        [Editable(false)]
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
    }
}