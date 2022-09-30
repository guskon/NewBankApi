
using BankWebAPI.ClassLibrary.DTOs;
using BankWebAPI.ClassLibrary.Entities;
using BankWebAPI.Services;
using Microsoft.AspNetCore.Mvc;


namespace BankWebAPI.Controllers
{
    [ApiController]
    [Route("Account type")]
    public class AccountTypeController : ControllerBase
    {
        private readonly AccountTypeService _accountTypeService;

        public AccountTypeController(AccountTypeService accountTypeService)
        {
            _accountTypeService = accountTypeService;
        }

        [HttpPost()]
        public async Task<IActionResult> AddAcountTypeAsync(CreateAccountTypeDTOs createAccountType)
        {
            await _accountTypeService.AddAcountTypeAsync(createAccountType);
            return StatusCode(201);
        }

        [HttpGet()]
        public async Task<IActionResult> GetAccountTypeAsync()
        {
            return Ok(await _accountTypeService.GetAccountTypeAsync());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAccountTypeAsync(int id, CreateAccountTypeDTOs areateAccountTypeDTOs)
        {
            await _accountTypeService.UpdateAccountTypeAsync(id, areateAccountTypeDTOs);
            return StatusCode(201);
        }

    }
}
