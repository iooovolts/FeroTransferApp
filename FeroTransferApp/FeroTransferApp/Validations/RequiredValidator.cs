using System;
using System.Collections.Generic;
using System.Text;

namespace FeroTransferApp.Validations
{
    public class RequiredValidator : IValidator
    {
        public string Message { get; set; } = "This field is required";
        public bool Check(string value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }
    }
}
