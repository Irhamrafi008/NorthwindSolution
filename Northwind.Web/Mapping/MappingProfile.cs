using AutoMapper;
using Northwind.Contracts.Dto.Category;
using Northwind.Contracts.Dto.Order;
using Northwind.Contracts.Dto.OrderDetails;
using Northwind.Contracts.Dto.Product;
using Northwind.Contracts.Dto.Suppliers;
using Northwind.Domain.Models;

namespace Northwind.Test.Maping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryForCreateDto>().ReverseMap();

            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, ProductForCreateDto>().ReverseMap();

            CreateMap<ProductPhoto, ProductPhotoDto>().ReverseMap();
            CreateMap<ProductPhoto, ProductPhotoCreateDto>().ReverseMap();

            CreateMap<Order, OrdersDto>().ReverseMap();
            CreateMap<Order, OrdersForCreateDto>().ReverseMap();

            CreateMap<Supplier, SuppliersDto>().ReverseMap();
            CreateMap<Supplier, SuppliersForCreateDto>().ReverseMap();

            CreateMap<OrderDetail, OrderDetailsDto>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailsForCreateDto>().ReverseMap();

        }
    }
}
