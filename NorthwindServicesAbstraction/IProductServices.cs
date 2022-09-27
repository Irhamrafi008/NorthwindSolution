using Northwind.Contracts.Dto;
using Northwind.Contracts.Dto.Category;
using Northwind.Contracts.Dto.Product;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NorthwindServicesAbstraction
{
    public interface IProductServices
    {
        //TrackChange adalah fitur untuk mendeteksi perubahan data  di object Category
        Task<IEnumerable<ProductDto>> GetAllProduct(bool trackChanges);

        Task<ProductDto> GetproductById(int categoryID, bool trackChanges);
        Task<IEnumerable<ProductDto>> GetProductPaged(int pageIndex, int pageSize, bool trackChanges);

        void insert(ProductForCreateDto productForCreateDto);

        void edit(ProductDto productDto);

        void remove(ProductDto categoryDto);
    }
}
