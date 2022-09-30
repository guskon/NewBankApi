using BankWebAPI.ClassLibrary.Entities;
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


        public async Task UpdateAccountTypesAsync(Account account)
        {
            var commandText = $@"UPDATE account
                SET account_type = @account_type WHERE id = @id";

            var queryArgs = new
            {
                id = account.Id,
                account_type = account.AccountType
            };

            await _connection.ExecuteAsync(commandText, queryArgs);
        }

        public async Task UpdateAccountBalanceAsync(int id, Account account)
        {
            var commandText = $@"UPDATE account
                SET balance = balance + @balance WHERE id = @id";

            var queryArgs = new
            {
                id = id,
                balance = account.Balance
            };

            await _connection.ExecuteAsync(commandText, queryArgs);
        }

        public async Task<AccountType> GetAccountByIdDBAsync(int id)
        {
            return _connection.QuerySingleOrDefault<AccountType>("SELECT * FROM account WHERE id=@Id", new
            {
                id
            });
        }

        public async Task<AccountType> GetAccountByAccountNumber(string accountNumber)
        {
            return _connection.QuerySingleOrDefault<AccountType>("SELECT * FROM account WHERE account_number=@accountNumber", new
            {
                accountNumber
            });
        }



    }

}

