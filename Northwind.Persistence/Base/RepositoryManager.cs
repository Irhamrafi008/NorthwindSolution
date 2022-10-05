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
        private IProductRepository _productRepository;
        private IProductPhotoRepository _productPhotoRepository;
        private ISuppliersRepository _suppliersRepository;
        private IOrderDetailsRepository _orderDetailsRepository;
        private IOrdersRepository _ordersRepository;

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
        public IProductRepository ProductRepository
        {
            get
            {
                if (_productRepository == null)
                {
                    _productRepository = new ProductRepository(_dbContext);
                }
                return _productRepository;
            }
        }

        public IProductPhotoRepository ProductPhotoRepository
        {
            get
            {
                if(_productPhotoRepository == null)
                {
                    _productPhotoRepository = new ProductPhotoRepository(_dbContext);
                }
                return _productPhotoRepository;
            }
        }

        public ISuppliersRepository SuppliersRepository
        {
            get
            {
                if(_suppliersRepository == null)
                {
                    _suppliersRepository = new SuppliersRepository(_dbContext);
                }
                return _suppliersRepository;
            }
        }

        public IOrderDetailsRepository OrdersDetailsRepository
        {
            get
            {
                if(_orderDetailsRepository == null)
                {
                    _orderDetailsRepository = new OrderDetailsRepository(_dbContext);
                }
                return _orderDetailsRepository;
            }
        }

        public IOrdersRepository OrdersRepository
        {
            get
            {
                if(_ordersRepository == null)
                {
                    _ordersRepository = new OrdersRepository(_dbContext);
                }
                return _ordersRepository;
            }
        }

        public void save() => _dbContext.SaveChanges();


        public async Task SaveAsync() => await _dbContext.SaveChangesAsync();
    
    }
}
