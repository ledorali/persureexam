using System;
using System.Collections.Generic;

namespace PetsureWebApiExamRodel.Data.Models
{
    public class Customer
    {
        public Customer()
        {
            Address = new List<Address>();
        }
        public int Id { get; set; }
        public string FullName { get; set; }
        public string DateOfBirth { get; set; }
        public int Age { get; set; }

        public List<Address> Address { get; set; }
    }
}
