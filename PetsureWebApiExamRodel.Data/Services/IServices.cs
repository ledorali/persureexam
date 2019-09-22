using PetsureWebApiExamRodel.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsureWebApiExamRodel.Data.Services
{
    public interface IServices
    {
       Task<List<Customer>> GetCustomerList();
       Task <Customer> GetCustomer (int? id);
       Task <Customer> CreateCustomer(Customer customer);
        Task UpdateCustomer(Customer customer);
        Task<int> DeleteCustomer(int? id);
    }
}
