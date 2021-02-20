using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Phonebook.Common.ViewModel;

namespace PhoneBook.Services.Validators
{
    public class PhoneEntryValidator: AbstractValidator<PhoneEntryViewModel>
    {
        public PhoneEntryValidator()
        {
            RuleFor(phoneEntry => phoneEntry.Name)
                .NotEmpty().WithMessage("Name cannot be empty")
                .NotNull().WithMessage("Name cannot be empty")
                .Must(r=>r.Length <= 100).WithMessage("Name must be less than or equal to a 100 characters");

            RuleFor(phoneEntry => phoneEntry.PhoneNumber)
                .NotEmpty().WithMessage("Phone Number cannot be empty")
                .NotNull().WithMessage("Phone Number cannot be empty")
                .Must(r => r.Length <= 50).WithMessage("Name must be less than or equal to a 50 characters");
        }
    }
}
