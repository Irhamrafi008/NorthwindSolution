using Northwind.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProduct(bool trackChanges);
        Task<Product>GetProductByID(int productID, bool trackChanges);
        Task<IEnumerable<Product>> GetProductPaged(int pageIndex, int pageSize, bool trackChanges);
        Task<IEnumerable<Product>> GetProductOnSales(bool trackChanges);     
        Task<Product>GetProductOnSalesById(int productOnSalesById, bool trackChanges);
        void Insert(Product product);
        void Edit(Product product);
        void Remove(Product product);
    }
}
