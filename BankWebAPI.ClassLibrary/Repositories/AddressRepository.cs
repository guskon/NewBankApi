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
    public class AddressRepository
    {
        private readonly NpgsqlConnection _connection;

        public AddressRepository(NpgsqlConnection connection)
        {
            _connection = connection;
        }

        public async Task InsertAddressDBAsync(Address address)
        {
            await _connection.ExecuteAsync("INSERT INTO addresses(house_number, street, city, country_code) VALUES(@house_number, @street, @city, @country_code)", new
            {
                house_number = address.HouseNumber,
                street = address.Street,
                city = address.City,
                country_code = address.CountryCode
            });
        }

        public async Task UpdateAddressDBAsync(int id, Address address)
        {
            await _connection.ExecuteAsync("UPDATE addresses SET house_number = @house_number, street = @street, city = @city, country_code = @country_code WHERE id = @id", new
            {
                country_code = address.CountryCode,
                house_number = address.HouseNumber,
                street = address.Street,
                city = address.City,
                id = id
            });
        }

        public async Task DeleteAddressDBAsync(int id)
        {
            await _connection.ExecuteAsync("DELETE FROM addresses WHERE id = @id");
        }

        public async Task AssignPersonToAddressDBAsync(int clientId, int addressId)
        {
            await _connection.ExecuteAsync("UPDATE clients SET address_id = @address_id WHERE id = @client_id", new
            {
                client_id = clientId,
                address_id = addressId,
            });
        }

        public async Task<Address> GetAddressByIdDBAsync(int id)
        {
            return await _connection.QuerySingleOrDefaultAsync<Address>("SELECT house_number HouseNumber, street Street, city City, country_code CountryCode FROM addresses WHERE id = @id", new
            {
                id = id
            });
        }

        public async Task<List<Address>> GetAddressesDBAsync()
        {
            var list = await _connection.QueryAsync<Address>("SELECT house_number HouseNumber, street Street, city City, country_code CountryCode FROM addresses");
            return list.ToList();
        }


        public async Task<Address> DoesAddressExistDBAsync(Address address)
        {
            var existingAddress = await _connection.QuerySingleOrDefaultAsync<Address>("SELECT house_number, street, city, country_code FROM addresses " +
                "WHERE (country_code = @country_code AND house_number = @house_number AND street = @street AND city = @city)", new
                {
                    country_code = address.CountryCode,
                    house_number = address.HouseNumber,
                    street = address.Street,
                    city = address.City,
                });

            return existingAddress;
        }
    }
}
