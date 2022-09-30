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

            if (await _accountRepository.GetAccountByAccountNumber(createAcount.AccountNumber) == null)
            {
                throw new ArgumentNullException("Cant create account with same account number");
            }
            else
            {
                await _accountRepository.AddAsyncs(_mapper.Map<Account>(createAcount));
            }
            
        }

        public async Task UpdateAccountTypesAsync(AccountTypesUpdateDTO cupdateAcountType)
        {
            await _accountRepository.UpdateAccountTypesAsync(_mapper.Map<Account>(cupdateAcountType));
        }

        public async Task UpdateAccountBalance(int id, AccountBalanceTopopDTO accountBalanceTopopDTO)
        {
            if (await _accountRepository.GetAccountByIdDBAsync(id) == null)
            {
                throw new ArgumentNullException("Account not found!");
            }
            else
            {
                await _accountRepository.UpdateAccountBalanceAsync(id, _mapper.Map<Account>(accountBalanceTopopDTO));
            }
            
        }



    }
}
