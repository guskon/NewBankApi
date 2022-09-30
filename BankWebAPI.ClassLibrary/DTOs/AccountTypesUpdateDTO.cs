using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankWebAPI.ClassLibrary.DTOs
{
    public class AccountTypesUpdateDTO
    {
        public int Id { get; set; }
        public string AccountType { get; set; }
        public int ClientId { get; set; }
    }
}
