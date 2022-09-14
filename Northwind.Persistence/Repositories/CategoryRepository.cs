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
    internal class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(NorthwindContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Category>> GetAllCategories(bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(c => c.CategoryName).ToListAsync();
        }

        public async Task<Category> GetCategoryById(int categoryId, bool trackChanges)
        {
            return await FindByCondition(c => c.CategoryId.Equals(categoryId), trackChanges).SingleOrDefaultAsync();
        }

        public void insert(Category category)
        {
            Create(category);
        }

        public void remove(Category category)
        {
            Delete(category);
        }

        public void edit(Category category)
        {
            Update(category);
        }
    }
}
