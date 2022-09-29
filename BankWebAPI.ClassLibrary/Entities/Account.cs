﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankWebAPI.ClassLibrary.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public int AccountNumber { get; set; }
        public string AccountType { get; set; }
        public int Balance { get; set; }
        public int ClientId { get; set; }
    }
}
