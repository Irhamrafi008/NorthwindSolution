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
    }
}
