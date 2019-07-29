using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FeroTransferApp.Models
{
    public class Recipient: Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public virtual string FullName { get => $"{FirstName} {LastName}"; }
        public int? AccountNumber { get; set; }
        public int? SortCode { get; set; }
        public bool IsSaved { get; set; }
        public int CountryId { get; set; }
        [ForeignKey(nameof(CountryId))]
        public Country Country { get; set; }
    }
}
