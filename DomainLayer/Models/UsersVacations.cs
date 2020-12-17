using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using DomainLayer.Engine;

namespace DomainLayer.Models
{
    public class UsersVacations : Model<UsersVacations>
    {
        [Key] public int? ModelId { get; set; }

        [Required] public int? UserModelId { get; set; }

        public DateTime? CreatedAt { get; set; }

        public string IsAccepted { get; set; }

        [Required] public DateTime? DateFrom { get; set; }

        [Required] public DateTime? DateTo { get; set; }

        [Required] public string Text { get; set; }

        public UsersVacations(Connection connection) : base(connection) {}

        public new void Save()
        {
            if (Database.IsInsert())
            {
                CreatedAt = DateTime.Now;
            }

            IsAccepted = false.ToString().ToLower();
            base.Save();
        }

        public bool IsDateValid()
        {
            return DateFrom != null && DateTo != null && DateFrom <= DateTo && DateFrom >= DateTime.Now;
        }

        public void Accept()
        {
            IsAccepted = true.ToString().ToLower();
            base.Save();
        }
    }
}