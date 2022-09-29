using Northwind.Contracts.Dto;
using Northwind.Contracts.Dto.Category;
using Northwind.Contracts.Dto.Product;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NorthwindServicesAbstraction
{
    public interface IProductPhotoServices
    {
        //TrackChange adalah fitur untuk mendeteksi perubahan data  di object Category
        Task<IEnumerable<ProductDto>> GetAllProductPhoto(bool trackChanges);

        Task<ProductPhotoDto> GetproductPhotoById(int categoryID, bool trackChanges);

        void insert(ProductPhotoCreateDto productPhotoCreateDto);

        void edit(ProductPhotoDto productPhotoDto);

        void remove(ProductPhotoDto productPhotoDto);
    }
}
