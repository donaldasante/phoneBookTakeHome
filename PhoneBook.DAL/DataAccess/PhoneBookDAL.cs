using Ardalis.GuardClauses;
using Microsoft.EntityFrameworkCore;
using Phonebook.Common.Entities;
using Phonebook.Common.Interfaces;
using PhoneBook.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.DAL.DataAccess
{
    public class PhoneBookDAL : IPhoneBookDAL
    {
        private readonly PhoneBookContext _context;

        public PhoneBookDAL(PhoneBookContext context)
        {
            _context = context;
            Guard.Against.Null(_context, nameof(PhoneBookContext));
        }

        public async Task CreateEntry(PhoneEntry entryToBeCreated)
        {
            var checkDupQuery = from entry in _context.Entries
                                where entry.Name == entryToBeCreated.Name && entry.PhoneNumber == entryToBeCreated.PhoneNumber
                                select entry;

            if (checkDupQuery.Count() > 0)
            {
                throw new Exception($"Duplicates for name {entryToBeCreated.Name} and phone number {entryToBeCreated.PhoneNumber} found in db");
            }

            await _context.Entries.AddAsync(entryToBeCreated);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEntry(PhoneEntry entry)
        {
            _context.Entries.Remove(entry);
            await _context.SaveChangesAsync();
        }

        public async Task EditEntry(PhoneEntry entry)
        {
            _context.Entries.Update(entry);
            await _context.SaveChangesAsync();
        }

        public async Task<List<PhoneEntry>> GetAllEntries()
        {
            List<PhoneEntry> result = await _context.Entries.ToListAsync();

            return result;
        }

        public async Task<List<PhoneEntry>> GetEntries(string searchParam)
        {
            var query = from phoneBookEntry in _context.Entries
                        where EF.Functions.Like(phoneBookEntry.Name, $"%{searchParam}%") || EF.Functions.Like(phoneBookEntry.PhoneNumber, $"%{searchParam}%")
                        select phoneBookEntry;

            var result = await query.ToListAsync();

            return result;
        }
    }
}
