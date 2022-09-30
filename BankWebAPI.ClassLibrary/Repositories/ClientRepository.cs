﻿using BankWebAPI.ClassLibrary.Entities;
using Dapper;
using Npgsql;

namespace BankWebAPI.ClassLibrary.Repositories
{
    public class ClientRepository
    {
        private readonly NpgsqlConnection _connection;

        public ClientRepository(NpgsqlConnection connection)
        {
            _connection = connection;
        }

        public async Task InsertClientDBAsync(Client client)
        {
            await _connection.ExecuteAsync("INSERT INTO clients(first_name, last_name, personal_code) VALUES(@first_name, @last_name, @personal_code)", new
            {
                first_name = client.FirstName,
                last_name = client.LastName,
                personal_code = client.PersonalCode,
            });
        }

        public async Task UpdateClientDBAsync(int id, Client client)
        {
            await _connection.ExecuteAsync("UPDATE clients SET first_name = @first_name, last_name = @last_name, personal_code = @personal_code WHERE id = @id", new
            {
                first_name = client.FirstName,
                last_name = client.LastName,
                personal_code = client.PersonalCode,
                id = id
            });
        }

        public async Task AssignAccountToClientDBAsync(int clientId, int accountId)
        {
            await _connection.ExecuteAsync("UPDATE account SET client_id=@client_id WHERE id = @account_id", new
            {
                client_id = clientId,
                account_id = accountId,
            });
        }

        public async Task<Client> GetClientByIdDBAsync(int id)
        {
            return _connection.QuerySingleOrDefault<Client>("SELECT first_name FirstName, last_name LastName, personal_code PersonalCode, address_id AddressId FROM clients WHERE id=@Id", new
            {
                id
            });
        }


        public async Task<Client> GetClientByPersonalCodeDBAsync(string personalCode)
        {
            return await _connection.QuerySingleOrDefaultAsync<Client>("SELECT first_name FirstName, last_name LastName, personal_code PersonalCode FROM clients WHERE personal_code=@personal_code", new
            {
                personal_code = personalCode
            });
        }
    }
}
