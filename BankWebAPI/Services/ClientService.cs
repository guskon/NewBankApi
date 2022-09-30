using AutoMapper;
using BankWebAPI.ClassLibrary.Entities;
using BankWebAPI.ClassLibrary.Repositories;
using BankWebAPI.DTOs;

namespace BankWebAPI.Services
{
    public class ClientService
    {
        private readonly ClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public ClientService(ClientRepository clientRepository, IMapper mapper)
        {
            _mapper = mapper;
            _clientRepository = clientRepository;
        }


        public async Task InsertClientAsync(ClientInsertDTO client)
        {
            if (await _clientRepository.GetClientByPersonalCodeDBAsync(client.PersonalCode) != null)
            {
                throw new Exception("Client by this personal code already exists!");
            }
            else
            {
                Client mappedClient = _mapper.Map<Client>(client);
                await _clientRepository.InsertClientDBAsync(mappedClient);
            }
        }

        public async Task UpdateClientAsync(int id, ClientInsertDTO client)
        {
            if (await GetClientByIdAsync(id) == null)
            {
                throw new ArgumentNullException("Client not found!");
            }
            else
            {
                await _clientRepository.UpdateClientDBAsync(id, _mapper.Map<Client>(client));
            }
        }

        public async Task<ClientInsertDTO> GetClientByIdAsync(int id)
        {
            Client client = await _clientRepository.GetClientByIdDBAsync(id);

            if (client != null)
            {
                return _mapper.Map<ClientInsertDTO>(client);
            }
            else
            {
                throw new ArgumentNullException("Client not found!");
            }
        }
    }
}
