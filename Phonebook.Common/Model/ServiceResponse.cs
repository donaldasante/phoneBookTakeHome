using System;
using System.Collections.Generic;
using System.Text;

namespace Phonebook.Common.Model
{
    public class ServiceResponse<T>
    {
        public bool Error { get; set; }
        public string ErrorMessage { get; set; }
        public T PayLoad { get; set; }
    }

}
