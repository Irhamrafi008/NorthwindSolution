using Microsoft.EntityFrameworkCore;
using Northwind.Domain.Models;
using Northwind.Domain.Repositories;
using Northwind.Persistence.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Persistence.Repositories
{
    internal class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(NorthwindContext dbContext) : base(dbContext)
        {
        }

        public async void edit(Customer customer)
        {
            Update(customer);
        }

        public async Task<IEnumerable<Customer>> GetAllCustomer(bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(c => c.CompanyName).ToListAsync();
        }

        public async Task<Customer> GetCustomerById(string customerId, bool trackChanges)
        {
            return await FindByCondition(c => c.CustomerId.Equals(customerId), trackChanges).SingleOrDefaultAsync();
        }

        public void insert(Customer customer)
        {
            Create(customer);
        }

        public void remove(Customer customer)
        {
            Delete(customer);
        }
    }
}
