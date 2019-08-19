using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FeroTransferApp.Models
{
    public class Recipient: Entity<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public virtual string FullName { get => $"{FirstName} {LastName}"; }
        public string AccountNumber { get; set; }
        public string SortCode { get; set; }
    }
}
