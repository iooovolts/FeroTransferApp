using System;
using System.Collections.Generic;
using System.Text;

namespace FeroTransferApp.Models
{
    public class Transfer : Entity<int>
    {
        public string SenderId { get; set; }
        public string RecipientName { get; set; }
        public DateTime SentDate { get; set; }
        public string SenderAmount { get; set; }
        public string RecipientAmount { get; set; }
        public string SenderCurrency { get; set; }
        public string RecipientCurrency { get; set; }
    }
}
