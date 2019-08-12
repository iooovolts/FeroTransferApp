using System;
using System.Collections.Generic;
using System.Text;

namespace FeroTransferApp.Validations
{
    public interface IValidator
    {
        string Message { get; set; }
        bool Check(string value);

    }
}
