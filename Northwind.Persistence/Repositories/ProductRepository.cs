using Microsoft.EntityFrameworkCore;
using Northwind.Domain.Dto;
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
            return await FindAll(trackChanges)
                .Include(c => c.Category)
                .Include(c => c.Supplier)
                .OrderBy(c => c.ProductId).ToListAsync();
        }

        public async Task<Product> GetProductByID(int productID, bool trackChanges)
        {
            return await FindByCondition(c => c.ProductId.Equals(productID), trackChanges)
                .Include(c=> c.Category)
                .Include(c=> c.Supplier)
                .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetProductOnSales(bool trackChanges)
        {
            var products = await _dbContext.Products
                .Where(x => x.ProductPhotos.Any(y => y.PhotoProductId == x.ProductId))
                .Include(x => x.ProductPhotos)
                .ToListAsync();
            return products;
        }

        public async Task<Product> GetProductOnSalesById(int productOnSalesById, bool trackChanges)
        {
            var productOnsalesMdl = await FindByCondition(c => c.ProductId.Equals(productOnSalesById), trackChanges)
                .Where(p => p.ProductPhotos.Any(p => p.PhotoProductId == productOnSalesById))
                .Include(z => z.ProductPhotos)
                .SingleOrDefaultAsync();
            return productOnsalesMdl;
        }

        public async Task<IEnumerable<Product>> GetProductPaged(int pageIndex, int pageSize, bool trackChanges)
        {
            return await FindAll(trackChanges)
                .OrderBy(c => c.ProductId)
                .Include(c => c.Category)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize).ToListAsync();
        }

        public IEnumerable<TotalproductByCategory> GetTotalProductBycategory()
        {
            var rawSQL = _dbContext.TotalProductByCategorySQL
                .FromSqlRaw("select c.CategoryName, count(p.productId)TotalProduct " +
                 "from Products p join Categories c on p.CategoryID = c.CategoryID " +
                 "group by c.CategoryName")
                .Select(x => new TotalproductByCategory
                {
                    CategoryName = x.CategoryName,
                    TotalProduct = x.TotalProduct
                })
                .OrderBy(x => x.TotalProduct)
                .ToList();
            return rawSQL;
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
