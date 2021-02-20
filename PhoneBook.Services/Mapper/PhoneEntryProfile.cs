using AutoMapper;
using Phonebook.Common.Entities;
using Phonebook.Common.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Services.Mapper
{
    public class PhoneEntryProfile : Profile
    {
        public PhoneEntryProfile()
        {
            CreateMap<PhoneEntry, PhoneEntryViewModel>();
            CreateMap<PhoneEntryViewModel,PhoneEntry>();
        }
    }
}
