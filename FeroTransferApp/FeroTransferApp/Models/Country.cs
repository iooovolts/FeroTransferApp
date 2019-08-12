using System;
using System.Collections.Generic;
using System.Text;

namespace FeroTransferApp.Models
{
    public class Country : Entity<int>
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
    }
}
