using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankWebAPI.DTOs
{
    public class CreateAccountDTO
    {
        public string AccountNumber { get; set; }
        public int AccountType { get; set; }
        public double Balance { get; set; }

    }
}
