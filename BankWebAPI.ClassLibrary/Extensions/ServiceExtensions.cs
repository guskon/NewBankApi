using BankWebAPI.ClassLibrary.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankWebAPI.ClassLibrary.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Default");

            services.AddTransient((sp) => new NpgsqlConnection(connectionString));

            services.AddTransient<ClientRepository>();
            services.AddTransient<AccountRepository>();
            services.AddTransient<AddressRepository>();
        }
    }
}
