using Northwind.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Domain.Repositories
{
    public interface ISuppliersRepository
    {
        Task<IEnumerable<Supplier>> GetAllSuppliers(bool trackChanges);
        Task<Supplier> GetAllSuppliersById(int supplierId, bool trackChanges);
        void Insert(Supplier supplier);
        void Edit(Supplier supplier);
        void Remove(Supplier supplier);
    }
}
