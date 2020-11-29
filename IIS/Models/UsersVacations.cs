using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using IIS.Engine;

namespace IIS.Models
{
    public class UsersVacations : Model<UsersVacations>
    {
        [Key] public int? ModelId { get; set; }

        [Required] public int? UserModelId { get; set; }

        [Required] public DateTime? CreatedAt { get; set; }

        [Required] public int? IsAccepted { get; set; }

        [Required] public DateTime? DateFrom { get; set; }

        [Required] public DateTime? DateTo { get; set; }

        [Required] public string Text { get; set; }

        public UsersVacations(Connection connection) : base(connection) {}

        public bool IsDateValid()
        {
            return DateFrom != null && DateTo != null && DateFrom <= DateTo && DateFrom >= DateTime.Now;
        }
    }
}