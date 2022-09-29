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
    public class ProductPhotoServices : IProductPhotoServices
    {
        private IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public ProductPhotoServices(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductPhotoDto>> GetAllProductPhoto(bool trackChanges)
        {
            var productPhotoMdl = await _repositoryManager.ProductPhotoRepository.GetAllProductPhoto(trackChanges);
            var productPhotoDto = _mapper.Map<IEnumerable<ProductPhotoDto>>(productPhotoMdl);
            return productPhotoDto;
        }

        public Task<ProductPhotoDto> GetproductPhotoById(int categoryID, bool trackChanges)
        {
            throw new NotImplementedException();
        }


        public void edit(ProductPhotoDto productPhotoDto)
        {
            throw new NotImplementedException();
        }

        public void remove(ProductPhotoDto productPhotoDto)
        {
            var remove = _mapper.Map<ProductPhoto>(productPhotoDto);
            _repositoryManager.ProductPhotoRepository.Remove(remove);
            _repositoryManager.save();
        }

        public void insert(ProductPhotoCreateDto productPhotoCreateDto)
        {
            var insert = _mapper.Map<ProductPhoto>(productPhotoCreateDto);
            _repositoryManager.ProductPhotoRepository.Insert(insert);
            _repositoryManager.save();
        }

        Task<IEnumerable<ProductDto>> IProductPhotoServices.GetAllProductPhoto(bool trackChanges)
        {
            throw new NotImplementedException();
        }
    }
}
