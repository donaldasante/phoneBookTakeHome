using Microsoft.EntityFrameworkCore;
using Phonebook.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneBook.DAL.Extensions
{
    public static class DbContextExtensions
    {
        public static void InsertOrUpdateTimeStampsInContext(this DbContext context)
        {
            var trackables = context.ChangeTracker.Entries<ICommonTableData>();

            if (trackables != null)
            {
                // added
                foreach (var item in trackables.Where(t => t.State == EntityState.Added))
                {
                    item.Entity.DateCreated = System.DateTime.Now;
                    item.Entity.DateModified = System.DateTime.Now;
                }

                // modified
                foreach (var item in trackables.Where(t => t.State == EntityState.Modified))
                {
                    item.Entity.DateModified = System.DateTime.Now;
                }
            }
        }
    }
}
