using System;
using System.Collections.Generic;
using System.Text;

namespace FeroTransferApp.Models
{
    public class TransferModel : Entity<int>
    {
        public string SenderId { get; set; }
        public Recipient Recipient { get; set; }
        public string TransferType { get; set; }
        public double ExchangeRate { get; set; }
        public double AmountSending { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime TransferDate { get; set; }
        public double AmountReceiving { get; set; }
        public Currency CurrencySending { get; set; }
        public Currency CurrencyReceiving { get; set; }
    }
}
