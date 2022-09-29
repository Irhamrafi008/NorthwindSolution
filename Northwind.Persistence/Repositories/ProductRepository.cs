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
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(NorthwindContext dbContext) : base(dbContext)
        {
        }

        public void Edit(Product product)
        {
           Update(product); 
        }

        public async Task<IEnumerable<Product>> GetAllProduct(bool trackChanges)
        {
            return await FindAll(trackChanges).Include (c => c.Category)
                .OrderBy(c => c.ProductId).ToListAsync();
        }

        public async Task<Product> GetProductByID(int productID, bool trackChanges)
        {
            return await FindByCondition(c => c.ProductId.Equals(productID), trackChanges).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetProductPaged(int pageIndex, int pageSize, bool trackChanges)
        {
            return await FindAll(trackChanges)
                .OrderBy(c => c.ProductId)
                .Include(c => c.Category)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize).ToListAsync();
        }

        public void Insert(Product product)
        {
            Create(product);
        }

        public void Remove(Product product)
        {
            Delete(product);
        }
    }
}
