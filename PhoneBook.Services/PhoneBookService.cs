using Ardalis.GuardClauses;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Phonebook.Common.Entities;
using Phonebook.Common.Interfaces;
using Phonebook.Common.Model;
using Phonebook.Common.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Services
{
    public class PhoneBookService : IPhoneBookService
    {
        private readonly IPhoneBookDAL _phoneBookDAL;
        private readonly IMapper _mapper;
        private readonly IValidator<PhoneEntryViewModel> _phoneEntryValidator;

        public PhoneBookService(IPhoneBookDAL phoneBookDAL, IMapper mapper, IValidator<PhoneEntryViewModel> phoneEntryValidator)
        {
            _phoneBookDAL = phoneBookDAL;
            _mapper = mapper;
            _phoneEntryValidator = phoneEntryValidator;

            Guard.Against.Null(_phoneBookDAL, nameof(IPhoneBookDAL));
            Guard.Against.Null(_mapper, nameof(IMapper));
            Guard.Against.Null(_phoneEntryValidator, nameof(IValidator<PhoneEntryViewModel>));
        }

        public async Task<ServiceResponse<Boolean>> CreateEntry(PhoneEntryViewModel viewModel)
        {
            ServiceResponse<Boolean> result = new ServiceResponse<bool>();
            result.PayLoad = false;
            result.Error = false;
            result.ErrorMessage = "";

            try
            {
                ValidationResult validResult = _phoneEntryValidator.Validate(viewModel);

                if (!validResult.IsValid)
                {
                    result.Error = true;
                    StringBuilder sb = new StringBuilder("");
                    foreach (var failure in validResult.Errors)
                    {
                        sb.Append("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage + "\n");
                    }
                    result.ErrorMessage = sb.ToString();

                    return result;
                }

                PhoneEntry entry = _mapper.Map<PhoneEntryViewModel, PhoneEntry>(viewModel);
                await _phoneBookDAL.CreateEntry(entry);

            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
                result.Error = true;
                return result;
            }

            return result;
        }

        public async Task<ServiceResponse<ICollection<PhoneEntryViewModel>>> ViewAllPhoneEntries()
        {
            ServiceResponse<ICollection<PhoneEntryViewModel>> result = new ServiceResponse<ICollection<PhoneEntryViewModel>>();
            
            result.Error = false;
            result.ErrorMessage = "";

            try
            {
                List<PhoneEntry> dbEntries = await _phoneBookDAL.GetAllEntries();
                result.PayLoad = _mapper.Map<List<PhoneEntry>, List<PhoneEntryViewModel>>(dbEntries);

            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
                result.Error = true;
                return result;
            }

            return result;
        }

        public async Task<ServiceResponse<ICollection<PhoneEntryViewModel>>> ViewFilteredPhoneEntries(string search)
        {
            ServiceResponse<ICollection<PhoneEntryViewModel>> result = new ServiceResponse<ICollection<PhoneEntryViewModel>>();

            result.Error = false;
            result.ErrorMessage = "";

            try
            {
                List<PhoneEntry> dbEntries = await _phoneBookDAL.GetEntries(search);
                result.PayLoad = _mapper.Map<List<PhoneEntry>, List<PhoneEntryViewModel>>(dbEntries);
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
                result.Error = true;
                return result;
            }

            return result;
        }
    }
}
