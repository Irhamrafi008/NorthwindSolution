using AutoMapper;
using Northwind.Contracts.Dto.Category;
using Northwind.Contracts.Dto.Product;
using Northwind.Domain.Base;
using Northwind.Domain.Models;
using NorthwindServicesAbstraction;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NorthwindServices
{
    public class ProductServices : IProductServices
    {
        private IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public ProductServices(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProduct(bool trackChanges)
        {
            var pproductMdl = await _repositoryManager.ProductRepository.GetAllProduct(trackChanges);
            var productDto = _mapper.Map<IEnumerable<ProductDto>>(pproductMdl);
            return productDto;
       
        }

        public Task<ProductDto> GetproductById(int categoryID, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public void insert(ProductForCreateDto productForCreateDto)
        {
            throw new NotImplementedException();
        }

        public void edit(ProductDto productDto)
        {
            throw new NotImplementedException();
        }

        public void remove(ProductDto categoryDto)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductDto>> GetProductPaged(int pageIndex, int pageSize, bool trackChanges)
        {
            var pproductMdl = await _repositoryManager
                .ProductRepository.GetProductPaged(pageIndex, pageSize  , trackChanges);

            var productDto = _mapper.Map<IEnumerable<ProductDto>>(pproductMdl);
            return productDto;
        }
    }
}
