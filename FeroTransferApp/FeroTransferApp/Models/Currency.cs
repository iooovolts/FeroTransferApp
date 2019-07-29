using System;
using System.Collections.Generic;
using System.Text;

namespace FeroTransferApp.Models
{
    public class Currency : Entity
    {
        public enum Currencies
        {
            GBP = '£',
            USD = '$'
        }
    }
}
