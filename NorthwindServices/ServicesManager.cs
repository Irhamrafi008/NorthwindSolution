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
        

        public ServicesManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _lazyCategoryServices = new Lazy<ICategoryServices>(
                ()=> new CategoryServices(repositoryManager, mapper)
                );  
            _lazyProductServices = new Lazy<IProductServices>(

                () => new ProductServices(repositoryManager, mapper)
                );
        }

        public ICategoryServices CategoryServices => _lazyCategoryServices.Value;

        public IProductServices ProductServices => _lazyProductServices.Value;
    }
}
