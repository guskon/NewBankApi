using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankWebAPI.DTOs
{
    public class CreateAccountDTO
    {
        public int AccountNumber { get; set; }
        public string AccountType { get; set; }
        public int Balance { get; set; }

    }
}
