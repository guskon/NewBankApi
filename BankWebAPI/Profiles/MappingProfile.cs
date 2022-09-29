﻿using AutoMapper;
using BankWebAPI.ClassLibrary.DTOs;
using BankWebAPI.ClassLibrary.Entities;
using BankWebAPI.DTOs;

namespace BankWebAPI.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateAccountDTO, Account>();
            CreateMap<Account, CreateAccountDTO>();
            CreateMap<AccountTypesUpdateDTO, Account>();
            CreateMap<Account, AccountTypesUpdateDTO>();
        }
    }
}
