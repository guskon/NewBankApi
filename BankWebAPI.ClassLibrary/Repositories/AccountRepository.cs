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
        public async Task AddAsync(Account account)
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

        public async Task UpdateAccountBalanceAsync(Account account)
        {
            var commandText = $@"UPDATE account
                SET balance = balance + @balance WHERE id = @id";

            var queryArgs = new
            {
                id = account.Id,
                balance = account.Balance
            };

            await _connection.ExecuteAsync(commandText, queryArgs);
        }


        public async Task<Account> GetAccountByIdDBAsync(int id)
        {
            return await _connection.QuerySingleOrDefaultAsync<Account>("SELECT account_number AccountNumber, creation_date CreationDate, account_type AccountType, balance, client_id ClientId FROM account WHERE id=@Id", new
            {
                id
            });
        }

        public async Task<Account> GetAccountByAccountNumberDBAsync(string accountNumber)
        {
            return await _connection.QuerySingleOrDefaultAsync<Account>("SELECT account_number AccountNumber, creation_date CreationDate, account_type AccountType, balance, client_id ClientId FROM account WHERE account_number = @account_number", new
            {
                account_number = accountNumber
            }); ;
        }
    }

}

