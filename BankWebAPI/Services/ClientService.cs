using AutoMapper;
using BankWebAPI.ClassLibrary.Entities;
using BankWebAPI.ClassLibrary.Repositories;
using BankWebAPI.DTOs;

namespace BankWebAPI.Services
{
    public class ClientService
    {
        private readonly ClientRepository _clientRepository;
        private readonly AccountService _accountService;
        private readonly IMapper _mapper;

        public ClientService(ClientRepository clientRepository, IMapper mapper, AccountService accountService)
        {
            _mapper = mapper;
            _clientRepository = clientRepository;
            _accountService = accountService;
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
                throw new ArgumentNullException("Client was not found!");
            }
            else
            {
                await _clientRepository.UpdateClientDBAsync(id, _mapper.Map<Client>(client));
            }
        }

        public async Task<ClientGetDTO> GetClientByIdAsync(int id)
        {
            Client client = await _clientRepository.GetClientByIdDBAsync(id);

            if (client != null)
            {
                return _mapper.Map<ClientGetDTO>(client);
            }
            else
            {
                throw new ArgumentNullException("Client was not found!");
            }
        }

        public async Task MakeTransaction(TransactionDTO values)
        {
            if (await _clientRepository.MakeTransactionDBAsync(values.AccountId1, values.AccountId2, values.Sum))
            {
                await _clientRepository.MakeTransactionDBAsync(values.AccountId1, values.AccountId2, values.Sum);
            }
            else
            {
                throw new Exception("Sum is larger than account balance!");
            }
        }

        public async Task AssignAccountToClientAsync(AssignAccountClientDTO ids)
        {
            if (await GetClientByIdAsync(ids.ClientId) != null)
            {
                if (await _accountService.GetAccountByIdAsync(ids.AccountId) != null)
                {
                    await _clientRepository.AssignAccountToClientDBAsync(ids.ClientId, ids.AccountId);
                }
                else
                {
                    throw new ArgumentNullException("Account was not found!");
                }
            }
            else
            {
                throw new ArgumentNullException("Client was not found!");
            }
        }
    }
}
