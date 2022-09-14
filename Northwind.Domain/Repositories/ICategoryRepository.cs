using Northwind.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Domain.Repositories
{
    public interface ICategoryRepository
    {
        //TrackChange adalah fitur untuk mendeteksi perubahan data  di object Category
        Task<IEnumerable<Category>> GetAllCategories(bool trackChanges);

        Task<Category> GetCategoryById(int categoryId, bool trackChanges);

        void insert(Category category);

        void edit(Category category);

        void remove(Category category);


    }
}
