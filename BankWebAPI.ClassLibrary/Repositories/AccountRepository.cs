using BankWebAPI.ClassLibrary.Entities;
using BankWebAPI.DTOs;
using Dapper;
using Npgsql;

namespace BankWebAPI.ClassLibrary.Repositories
{
    public class AccountRepository
    {
        private readonly NpgsqlConnection _connection;
        public AccountRepository(NpgsqlConnection connection)
        {
            _connection = connection;
        }
        public async Task AddAsyncs(Account account)
        {
            var insertQuery = "INSERT INTO account (account_number, creation_date, account_type, balance) VALUES(@account_number, @creation_date, @account_type, @balance)";

            var queryArguments = new
            {
                account_number = account.AccountNumber,
                creation_date = DateTime.Now,
                account_type = account.AccountType,
                balance = account.Balance
            };

            await _connection.ExecuteAsync(insertQuery, queryArguments);

        }

    }
}
