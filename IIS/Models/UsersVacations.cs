using System;
using System.ComponentModel.DataAnnotations;
using IIS.Engine;

namespace IIS.Models
{
    public class UsersVacations
    {
        public IDatabase<UsersVacations> Connection { get; set; }
        
        [Key]
        public int? ModelId { get; set; }

        [Required]
        public int? UserModelId { get; set; }
        
        [Editable(false)]
        public DateTime? CreatedAt { get; set; }

        [Required]
        public int? IsAccepted { get; set; }
        
        [Editable(false)]
        public DateTime? DateFrom { get; set; }
        
        [Editable(false)]
        public DateTime? DateTo { get; set; }
        
        [Required]
        public string Text { get; set; }
    }
}