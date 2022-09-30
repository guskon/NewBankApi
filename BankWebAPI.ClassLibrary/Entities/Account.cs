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
        public string AccountNumber { get; set; }
        public int AccountType { get; set; }
        public DateTime CreationDate { get; set; }    
        public double Balance { get; set; }
        public int ClientId { get; set; }
    }
}
