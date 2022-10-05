using AutoMapper;
using Northwind.Domain.Base;
using NorthwindServicesAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindServices
{
    public class ServicesManager : IServiceManager
    {
        private readonly Lazy<ICategoryServices> _lazyCategoryServices;
        private readonly Lazy<IProductServices> _lazyProductServices;
        private readonly Lazy<IProductPhotoServices> _lazyProductPhotoServices;
        private readonly Lazy<ISuppliersServices> _lazySuppliersServices;
        private readonly Lazy<IOrdersDetailsServices> _lazyOrdersDetailsServices;
        private readonly Lazy<IOrdersServices> _lazyOrdersServices;

     

        public ServicesManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _lazyCategoryServices = new Lazy<ICategoryServices>(
                ()=> new CategoryServices(repositoryManager, mapper)
                );  
            _lazyProductServices = new Lazy<IProductServices>(

                () => new ProductServices(repositoryManager, mapper)
                );
            _lazyProductPhotoServices = new Lazy<IProductPhotoServices>(
                () => new ProductPhotoServices(repositoryManager, mapper)
                );
            _lazySuppliersServices = new Lazy<ISuppliersServices>(
                () => new SuppliersServices(repositoryManager, mapper)
                );
            _lazyOrdersDetailsServices = new Lazy<IOrdersDetailsServices>(
                () => new OrderDetailsServices(repositoryManager, mapper)
                );
            _lazyOrdersServices = new Lazy<IOrdersServices>(
                () => new OrdersServices(repositoryManager, mapper)
                );
               
        }

        public ICategoryServices CategoryServices => _lazyCategoryServices.Value;

        public IProductServices ProductServices => _lazyProductServices.Value;

        public IProductPhotoServices ProductPhotoServices => _lazyProductPhotoServices.Value;

        public ISuppliersServices SuppliersServices => _lazySuppliersServices.Value;

        public IOrdersDetailsServices OrdersDetailsServices => _lazyOrdersDetailsServices.Value;

        public IOrdersServices OrdersServices => _lazyOrdersServices.Value;
    }
}
