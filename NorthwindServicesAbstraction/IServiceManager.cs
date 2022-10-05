using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindServicesAbstraction
{
    public interface IServiceManager
    {
        ICategoryServices CategoryServices { get; }
        IProductServices ProductServices { get; }
        IProductPhotoServices ProductPhotoServices { get; }
        ISuppliersServices SuppliersServices { get; }
        IOrdersDetailsServices OrdersDetailsServices { get; }
        IOrdersServices OrdersServices { get; }
        
    }
}
