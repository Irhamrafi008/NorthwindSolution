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
    internal class SuppliersRepository : RepositoryBase<Supplier>, ISuppliersRepository
    {
        public SuppliersRepository(NorthwindContext dbContext) : base(dbContext)
        {
        }

        public void Edit(Supplier supplier)
        {
            Update(supplier);
        }

        public async Task<IEnumerable<Supplier>> GetAllSuppliers(bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(c => c.SupplierId).ToListAsync();
        }

        public async Task<Supplier> GetAllSuppliersById(int supplierId, bool trackChanges)
        {
            return await FindByCondition(c => c.SupplierId.Equals(supplierId), trackChanges).SingleOrDefaultAsync();
        }

        public void Insert(Supplier supplier)
        {
            Create(supplier);
        }

        public void Remove(Supplier supplier)
        {
            Delete(supplier);

        }
    }
}
