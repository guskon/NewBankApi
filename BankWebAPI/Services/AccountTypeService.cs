using AutoMapper;
using BankWebAPI.ClassLibrary.DTOs;
using BankWebAPI.ClassLibrary.Entities;
using BankWebAPI.ClassLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankWebAPI.Services
{
    public class AccountTypeService
    {
        private readonly AccountTypeRepository _accountTypeRepository;
        private readonly IMapper _mapper;
        public AccountTypeService(AccountTypeRepository accountTypeRepository, IMapper mapper)
        {
            _accountTypeRepository = accountTypeRepository;
            _mapper = mapper;
        }

        public async Task AddAcountTypeAsync(CreateAccountTypeDTOs createAccountType)
        {
            await _accountTypeRepository.AddAcountTypeAsync(_mapper.Map<AccountType>(createAccountType));
        }

        public async Task<List<AccountType>> GetAccountTypeAsync()
        {
            var data = await _accountTypeRepository.GetAllTypesAsyncs();
            return data;
        }
        public async Task UpdateAccountTypeAsync(int id, CreateAccountTypeDTOs createAccountTypeDTOs)
        {
            if (await _accountTypeRepository.GetAccountTypeByIdDBAsync(id) == null)
            {
                throw new ArgumentNullException("Account type not found!");
            }
            else
            {
                await _accountTypeRepository.UpdateAccountTypeAsync(id, _mapper.Map<AccountType>(createAccountTypeDTOs));
            }
        }

        public async Task DeleteAccountTypeById(int id)
        {
            if (await _accountTypeRepository.GetAccountTypeByIdDBAsync(id) == null)
            {
                throw new ArgumentNullException("Account type not found!");
            }
            else
            {
                await _accountTypeRepository.DeleteAccountTypeById(id);
            }
        }

    }
}
