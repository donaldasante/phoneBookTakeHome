using Phonebook.Common.Model;
using Phonebook.Common.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook.Common.Interfaces
{
    public interface IPhoneBookService
    {
        Task<ServiceResponse<Boolean>> CreateEntry(PhoneEntryViewModel viewModel);
        Task<ServiceResponse<ICollection<PhoneEntryViewModel>>> ViewAllPhoneEntries();

        Task<ServiceResponse<ICollection<PhoneEntryViewModel>>> ViewFilteredPhoneEntries(string search);
    }
}
