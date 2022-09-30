using BankWebAPI.ClassLibrary.DTOs;
using BankWebAPI.ClassLibrary.Entities;
using BankWebAPI.DTOs;
using BankWebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BankWebAPI.Controllers
{
    [ApiController]
    [Route("Account")]
    public class AccountController : ControllerBase
    {
        private readonly AccountService _accountService;

        public AccountController(AccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(CreateAccountDTO createAcount)
        {
            await _accountService.AddAsync(createAcount);
            return StatusCode(201);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAccountTypesAsync(AccountTypesUpdateDTO accountTypesUpdateDTO)
        {
            await _accountService.UpdateAccountTypesAsync(accountTypesUpdateDTO);
            return StatusCode(201);
        }

        [HttpPut("balance/{id}")]
        public async Task<IActionResult> UpdateAccountBalance(int id, AccountBalanceTopopDTO accountBalanceTopopDTO)
        {
            await _accountService.UpdateAccountBalance(id, accountBalanceTopopDTO);
            return StatusCode(201);
        }

    }
}
