using Northwind.Contracts.Dto.Category;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NorthwindServicesAbstraction
{
    public interface ICategoryServices
    {
        //TrackChange adalah fitur untuk mendeteksi perubahan data  di object Category
        Task<IEnumerable<CategoryDto>> GetAllCategories(bool trackChanges);

        Task<CategoryDto> GetCategoryById(int categoryId, bool trackChanges);

        void insert(CategoryForCreateDto categoryForCreateDto);

        void edit(CategoryDto categoryDto);

        void remove(CategoryDto categoryDto);
    }
}
