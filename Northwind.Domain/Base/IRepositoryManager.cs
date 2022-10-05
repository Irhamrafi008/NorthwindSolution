﻿using Northwind.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Domain.Base
{
    public interface IRepositoryManager
    {


        ICategoryRepository CategoryRepository { get; }
        ICustomerRepository CustomerRepository { get; }
        IEmployeesRepository EmployeesRepository { get; }
        IProductRepository ProductRepository { get; }
        IProductPhotoRepository ProductPhotoRepository { get; }
        ISuppliersRepository SuppliersRepository { get; }
        IOrderDetailsRepository OrdersDetailsRepository { get; }
        IOrdersRepository OrdersRepository { get; }
        void save();
        Task SaveAsync();
    }
}
