using Microsoft.EntityFrameworkCore;
using Phonebook.Common.Entities;
using PhoneBook.DAL.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PhoneBook.DAL.Context
{
    public class PhoneBookContext : DbContext
    {
        private static bool _created = false;
        public PhoneBookContext()
        {
            if (!_created)
            {
                _created = true;
                Database.EnsureCreated();
            }
        }

        public override int SaveChanges()
        {
            this.InsertOrUpdateTimeStampsInContext();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            this.InsertOrUpdateTimeStampsInContext();
            return await base.SaveChangesAsync(cancellationToken);
        }

        public PhoneBookContext(DbContextOptions<PhoneBookContext> options) : base(options)
        {
            //any changes to the context options can now be done here
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PhoneEntry>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<PhoneEntry>()
                .HasIndex(p => new { p.Name, p.PhoneNumber })
                .IsUnique();
                
        }

        public DbSet<PhoneEntry> Entries { get; set; }
    }
}
