using AutoMapper;
using BankWebAPI.ClassLibrary.Entities;
using BankWebAPI.ClassLibrary.Repositories;
using BankWebAPI.DTOs;

namespace BankWebAPI.Services
{
    public class AddressService
    {
        private readonly AddressRepository _addressRepository;
        private readonly IMapper _mapper;
        private readonly ClientService _clientService;

        public AddressService(AddressRepository addressRepository, IMapper mapper, ClientService clientService)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
            _clientService = clientService;
        }

        public async Task InsertAddressAsync(AddressDTO address)
        {
            var mappedAddress = _mapper.Map<Address>(address);
            if (await DoesAddressExistAsync(mappedAddress) == null)
            {
                await _addressRepository.InsertAddressDBAsync(mappedAddress);
            }
            else
            {
                throw new Exception("This address already exists!");
            }
        }

        public async Task UpdateAddressAsync(int id, AddressDTO address)
        {
            if (GetAddressById(id) == null)
            {
                throw new ArgumentNullException("Address was not found!");
            }
            else
            {
                await _addressRepository.UpdateAddressDBAsync(id, _mapper.Map<Address>(address));
            }
        }

        public async Task DeleteAddressAsync(int id)
        {
            if (GetAddressById(id) == null)
            {
                throw new ArgumentNullException("Address was not found!");
            }
            else
            {
                await _addressRepository.DeleteAddressDBAsync(id);
            }
        }

        public async Task AssignPersonToAddressAsync(AssignPersonToAddressDTO ids)
        {
            if (await GetAddressById(ids.AddressId) != null)
            {
                if (await _clientService.GetClientByIdAsync(ids.ClientId) != null)
                {
                    await _addressRepository.AssignPersonToAddressDBAsync(ids.ClientId, ids.AddressId);
                }
                else
                {
                    throw new ArgumentNullException("Client was not found!");
                }
            }
            else
            {
                throw new ArgumentNullException("Address was not found!");
            }
        }

        public async Task<List<AddressDTO>> GetAdressesAsync()
        {
            var addresses = await _addressRepository.GetAddressesDBAsync();
            return addresses.Select(p => _mapper.Map<AddressDTO>(p)).ToList();
        }

        public async Task<AddressDTO> GetAddressById(int id)
        {
            Address address = await _addressRepository.GetAddressByIdDBAsync(id);

            if (address == null)
            {
                throw new ArgumentNullException("Address was not found!");
            }
            else
            {
                return _mapper.Map<AddressDTO>(address);
            }
        }

        public async Task<Address> DoesAddressExistAsync(Address address)
        {
            var existingAddress = await _addressRepository.DoesAddressExistDBAsync(address);
            if (existingAddress != null)
            {
                throw new Exception("This address already exists!");
            }
            else
            {
                return existingAddress;
            }
        }
    }
}
