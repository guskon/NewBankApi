using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankWebAPI.ClassLibrary.Entities
{
    public class Address
    {
        public int id { get ; set; }
        public int HouseNumber { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string CountryCode { get; set; }
    }
}
