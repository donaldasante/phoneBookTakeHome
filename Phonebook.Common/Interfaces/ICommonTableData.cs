using System;
using System.Collections.Generic;
using System.Text;

namespace Phonebook.Common.Interfaces
{
    public interface ICommonTableData
    {
        DateTime DateCreated { get; set; }
        DateTime? DateModified { get; set; }
    }
}
