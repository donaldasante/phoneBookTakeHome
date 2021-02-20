using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Phonebook.Common.Interfaces;
using Phonebook.Common.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBookApp.Controllers
{
    [ApiController]
    public class PhoneBookController : ControllerBase
    {
        private readonly IPhoneBookService _phoneBookService;


        public PhoneBookController(IPhoneBookService phoneBookService)
        {
            _phoneBookService = phoneBookService;
            Guard.Against.Null(_phoneBookService, nameof(IPhoneBookService));
        }

        [HttpGet]
        [Route("api/[controller]/[action]")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _phoneBookService.ViewAllPhoneEntries();
            return Ok(result);
        }

        [HttpGet]
        [Route("api/[controller]/[action]")]
        public async Task<IActionResult> FindEntry(string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                return await this.GetAll();
            }
            else
            {
                var result = await _phoneBookService.ViewFilteredPhoneEntries(search);
                return Ok(result);
            }
        }

        [HttpPost]
        [Route("api/[controller]/[action]")]
        public async Task<IActionResult> AddEntry([FromBody] PhoneEntryViewModel vm)
        {

            var result = await _phoneBookService.CreateEntry(vm);
            return Ok(result);
        }
    }
}
