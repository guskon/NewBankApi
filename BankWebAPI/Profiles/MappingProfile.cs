using AutoMapper;
using BankWebAPI.ClassLibrary.Entities;
using BankWebAPI.DTOs;

namespace BankWebAPI.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ClientInsertDTO, Client>();
            CreateMap<Client, ClientInsertDTO>();
        }
    }
}
