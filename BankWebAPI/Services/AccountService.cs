﻿using AutoMapper;
using BankWebAPI.ClassLibrary.DTOs;
using BankWebAPI.ClassLibrary.Entities;
using BankWebAPI.ClassLibrary.Repositories;
using BankWebAPI.DTOs;

namespace BankWebAPI.Services
{
    public class AccountService
    {
        private readonly AccountRepository _accountRepository;
        private readonly IMapper _mapper;
        public AccountService(AccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(CreateAccountDTO createAccount)
        {
            if (await _accountRepository.GetAccountByAccountNumberDBAsync(createAccount.AccountNumber) != null)
            {
                throw new Exception("Account by this account code already exists!");
            }

            await _accountRepository.AddAsync(_mapper.Map<Account>(createAccount));
        }

        public async Task UpdateAccountBalance(AccountBalanceTopopDTO accountBalanceTopopDTO)
        {
            await _accountRepository.UpdateAccountBalanceAsync(_mapper.Map<Account>(accountBalanceTopopDTO));
        }

        public async Task<AccountDTO> GetAccountByIdAsync(int id)
        {
            if (await _accountRepository.GetAccountByIdDBAsync(id) == null)
            {
                throw new ArgumentNullException("Account was not found!");
            }
            else
            {
                return _mapper.Map<AccountDTO>(await _accountRepository.GetAccountByIdDBAsync(id));
            }
        }
    }
}
