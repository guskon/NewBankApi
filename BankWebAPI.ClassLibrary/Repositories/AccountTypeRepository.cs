using BankWebAPI.ClassLibrary.Entities;
using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankWebAPI.ClassLibrary.Repositories
{
    public class AccountTypeRepository
    {
        private readonly NpgsqlConnection _connection;
        public AccountTypeRepository(NpgsqlConnection connection)
        {
            _connection = connection;
        }

        public async Task AddAcountTypeAsync(AccountType accountType)
        {
            var insertQuery = "INSERT INTO account_type (account_type) VALUES(@account_type)";

            var queryArguments = new
            {
                account_type = accountType.Type,
            };

            await _connection.ExecuteAsync(insertQuery, queryArguments);

        }

        public async Task<AccountType> GetAccountTypeAsync()
        {
            return _connection.QuerySingleOrDefault<AccountType>("SELECT account_type Type from account_type");
        }


        public async Task UpdateAccountTypeAsync(int id, AccountType accountType)
        {
            var commandText = $@"UPDATE account_type
                SET account_type = @account_type WHERE id = @id";

            var queryArgs = new
            {
                id = id,
                account_type = accountType.Type
            };

            await _connection.ExecuteAsync(commandText, queryArgs);
        }

        public async Task<AccountType> GetAccountTypeByIdDBAsync(int id)
        {
            return _connection.QuerySingleOrDefault<AccountType>("SELECT * FROM account_type WHERE id=@Id", new
            {
                id
            });
        }
        public async Task DeleteAccountTypeById(int id)
        {
            Console.WriteLine(id);
            string commandText = $"DELETE FROM account_type WHERE ID=@id";

            var queryArguments = new
            {
                id = id,
            };

            await _connection.ExecuteAsync(commandText, queryArguments);

        }

        public async Task<List<AccountType>> GetAllTypesAsyncs()
        {
            var getAllQuery = "select id Id, account_type Type from account_type";
            var ShopItemEntity = getAllQuery;
            var entities = await _connection.QueryAsync<AccountType>(getAllQuery);
            return entities.ToList();
        }

    }
}
