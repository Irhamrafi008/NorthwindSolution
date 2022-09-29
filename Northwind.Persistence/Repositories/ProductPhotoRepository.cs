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
    internal class ProductPhotoRepository : RepositoryBase<ProductPhoto>, IProductPhotoRepository
    {
        public ProductPhotoRepository(NorthwindContext dbContext) : base(dbContext)
        {
        }

        public void Edit(ProductPhoto productPhoto)
        {
            Update(productPhoto);
        }

        public async Task<IEnumerable<ProductPhoto>> GetAllProductPhoto(bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(c => c.PhotoProductId).ToListAsync();
        }

        public async Task<ProductPhoto> GetProductPhotoById(int productPhotoId, bool trackChanges)
        {
            return await FindByCondition(c => c.PhotoProductId.Equals(productPhotoId), trackChanges).SingleOrDefaultAsync();
        }

        public void Insert(ProductPhoto productPhoto)
        {
            Create(productPhoto);
        }

        public void Remove(ProductPhoto productPhoto)
        {
            Delete(productPhoto);
        }
    }
}
