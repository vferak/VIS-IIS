using System;
using System.ComponentModel.DataAnnotations;
using IIS.Engine;

namespace IIS.Models
{
    public class Users
    {
        public IDatabase<Users> Connection { get; set; }
        
        [Key]
        public int? ModelId { get; set; }

        [Editable(false)]
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
        
        public int? IsManager { get; set; }
    }
}