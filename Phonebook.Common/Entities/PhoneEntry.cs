using Phonebook.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Phonebook.Common.Entities
{
    [Table("Entries", Schema = "dbo")]
    public class PhoneEntry : ICommonTableData
    {
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
