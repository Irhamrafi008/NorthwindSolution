using Microsoft.EntityFrameworkCore;
using Northwind.Domain.Models;
using Northwind.Domain.Repositories;
using Northwind.Persistence.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Persistence.Repositories
{
    internal class EmployeeRepository : RepositoryBase<Employee>, IEmployeesRepository
    {
        public EmployeeRepository(NorthwindContext dbContext) : base(dbContext)
        {
        }

        public void edit(Employee employee)
        {
            Update(employee);
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees(bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(c => c.EmployeeId).ToListAsync();
        }

        public async Task<Employee> GetEmployeeByID(int id, bool trackChanges)
        {
            return await FindByCondition(c => c.EmployeeId.Equals(id), trackChanges).SingleOrDefaultAsync();
        }

        public void insert(Employee employee)
        {
            Create(employee);
        }

        public void remove(Employee employee)
        {
            Delete(employee);
        }
    }
}
