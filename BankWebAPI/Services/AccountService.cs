using AutoMapper;
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

        public async Task AddAsync(CreateAccountDTO createAcount)
        {
            await _accountRepository.AddAsyncs(_mapper.Map<Account>(createAcount));
        }

        public async Task UpdateAccountTypesAsync(AccountTypesUpdateDTO cupdateAcountType)
        {
            await _accountRepository.UpdateAccountTypesAsync(_mapper.Map<Account>(cupdateAcountType));
        }

        public async Task UpdateAccountBalance(AccountBalanceTopopDTO accountBalanceTopopDTO)
        {
            await _accountRepository.UpdateAccountBalanceAsync(_mapper.Map<Account>(accountBalanceTopopDTO));
        }
    }
}
