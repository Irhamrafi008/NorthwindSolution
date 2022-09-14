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

        public ServicesManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _lazyCategoryServices = new Lazy<ICategoryServices>(
                ()=> new CategoryServices(repositoryManager, mapper)
                );
        }

        public ICategoryServices CategoryServices => _lazyCategoryServices.Value;
    }
}
