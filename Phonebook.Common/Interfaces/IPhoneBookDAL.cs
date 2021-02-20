using Phonebook.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook.Common.Interfaces
{
    public interface IPhoneBookDAL
    {
        Task<List<PhoneEntry>> GetAllEntries();
        Task<List<PhoneEntry>> GetEntries(string searchParam);
        Task CreateEntry(PhoneEntry entry);
        Task EditEntry(PhoneEntry entry);

        Task DeleteEntry(PhoneEntry entry);
    }
}
