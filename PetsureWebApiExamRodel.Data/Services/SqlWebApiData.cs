using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetsureWebApiExamRodel.Data.Models;

namespace PetsureWebApiExamRodel.Data.Services
{
    public class SqlWebApiData : IServices
    {
        private readonly WebapiDbContext db;

        public SqlWebApiData(WebapiDbContext db)
        {
            this.db = db;
        }
        public void Add(Customer customer)
        {
            db.Customers.Add(customer);
            db.SaveChanges();
        }

        public async Task<Customer> CreateCustomer(Customer customer)
        {
            if(db !=null )
            {
                 db.Customers.Add(customer);
               await  db.SaveChangesAsync();

                return customer;
            }
            return customer;
        }

        

        public async Task<int> DeleteCustomer(int? id)
        {
            int result = 0;

            if(db != null)
            {
                var customer = await db.Customers.FirstOrDefaultAsync(x => x.Id == id);
                if(customer != null)
                {
                    db.Customers.Remove(customer);

                    result = await db.SaveChangesAsync();
                }
                return result;
            }
            return result;


        }

        public Customer Get(int id)
        {
            return db.Customers.FirstOrDefault(r =>  r.Id == id);
        }

        public async Task<Customer> GetCustomer(int? id)
        {
            if(db != null)
            {
                return await db.Customers.
                    Include(a => a.Address).
                    FirstOrDefaultAsync(r => r.Id == id);
            }
            return null;
        }

        public async Task<List<Customer>> GetCustomerList()
        {
            //var customers = db.Customers.Include(a => a.Address).ToList();
            //return customers;
            if(db!=null)
            {
                return await db.Customers.Include(a => a.Address).ToListAsync();
            }
            return null;
            
        }

       

        public async Task UpdateCustomer(Customer customer)
        {
            //var entry = db.Entry(customer);
            //entry.State = EntityState.Modified;
            //db.SaveChanges();



            if(db != null)
            {

                int id = customer.Id;
                var cust = await db.Customers.FirstOrDefaultAsync(x => x.Id == id);
                if (cust != null)
                {
                   
                    db.Customers.Remove(cust);
                  await  db.SaveChangesAsync();
                   
                }
                if(cust != null)
                {
                    
                    db.Customers.Add(customer);
                    await db.SaveChangesAsync();
                }
            }

        }
    }
}
