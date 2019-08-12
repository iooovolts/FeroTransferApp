using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace FeroTransferApp.Validations
{
    public class SortCodeValidator : IValidator
    {
        public string Message { get; set; } = "A sort code must be 8 digits";
        public bool Check(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                var format = new Regex(@"\d\d\d\d\d\d\d\d");
                return format.IsMatch(value);
            }
            return false;
        }
    }
}
