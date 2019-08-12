using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace FeroTransferApp.Models
{
    public class Currency : Entity<string>
    {
        public string CurrencyName { get; set; }
        public string CurrencySymbol { get; set; }
    }
}
