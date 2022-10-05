using Northwind.Contracts.Dto;
using Northwind.Contracts.Dto.Category;
using Northwind.Contracts.Dto.Order;
using Northwind.Contracts.Dto.OrderDetails;
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

        ProductDto CreateProductId(ProductForCreateDto productForCreateDto);

        void CreateProductManyPhoto(ProductForCreateDto productForCreateDto, 
                                    List<ProductPhotoCreateDto>productPhotoCreateDtos);
        Task<IEnumerable<ProductDto>> GetProductOnSales(bool trackChanges);
        Task<ProductDto> GetAllProductOnSalesById(int productOnsalesId, bool trackChanges);
        void CreateOrder(OrdersForCreateDto ordersForCreateDto, OrderDetailsForCreateDto orderDetailsForCreateDto);
        void EditProductPhoto(ProductDto productDto, List<ProductPhotoDto> productPhotoDtos);

        void insert(ProductForCreateDto productForCreateDto);
        
        void edit(ProductDto productDto);

        void remove(ProductDto productDto);
    }
}