using Northwind.Domain.Base;
using Northwind.Domain.Repositories;
using Northwind.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Persistence.Base
{
    public class RepositoryManager : IRepositoryManager
    {
        private NorthwindContext _dbContext;
        private ICategoryRepository _categoryRepository;
        private ICustomerRepository _customerRepository;
        private IEmployeesRepository _employeesRepository;

        public RepositoryManager(NorthwindContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ICategoryRepository CategoryRepository
        {
            get {
                if (_categoryRepository == null)
                {
                    _categoryRepository = new CategoryRepository(_dbContext);
                }         
                return _categoryRepository; 
                }
        }

        public ICustomerRepository CustomerRepository
        {
            get
            {
                if(_customerRepository == null)
                {
                    _customerRepository = new CustomerRepository(_dbContext);
                }
                return _customerRepository;
            }
  
        }

        public IEmployeesRepository EmployeesRepository
        {
            get
            {
                if(_employeesRepository == null)
                {
                    _employeesRepository = new EmployeeRepository(_dbContext);
                }
                return _employeesRepository;
            }
        }

        public void save() => _dbContext.SaveChanges();


        public async Task SaveAsync() => await _dbContext.SaveChangesAsync();
    
    }
}
