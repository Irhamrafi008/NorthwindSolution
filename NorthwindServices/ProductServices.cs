﻿using AutoMapper;
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

        public async Task<ProductDto> GetproductById(int categoryID, bool trackChanges)
        {
            var productMdl = await _repositoryManager.ProductRepository.GetProductByID(categoryID, trackChanges);
            var productDto = _mapper.Map<ProductDto>(productMdl);
            return productDto;
        }

        public void insert(ProductForCreateDto productForCreateDto)
        {
            var productMdl = _mapper.Map<Product>(productForCreateDto);
            _repositoryManager.ProductRepository.Insert(productMdl);
            _repositoryManager.save();
        }

        public void edit(ProductDto productDto)
        {
            var productMdl = _mapper.Map<Product>(productDto);
            _repositoryManager.ProductRepository.Edit(productMdl);
            _repositoryManager.save();
        }

        public void remove(ProductDto categoryDto)
        {
            var productMdl = _mapper.Map<Product>(categoryDto);
            _repositoryManager.ProductRepository.Remove(productMdl);
            _repositoryManager.save();
        }

        public async Task<IEnumerable<ProductDto>> GetProductPaged(int pageIndex, int pageSize, bool trackChanges)
        {
            var productMdl = await _repositoryManager
                .ProductRepository.GetProductPaged(pageIndex, pageSize  , trackChanges);

            var productDto = _mapper.Map<IEnumerable<ProductDto>>(productMdl);
            return productDto;
        }

        public ProductDto CreateProductId(ProductForCreateDto productForCreateDto)
        {
            var productMdl = _mapper.Map<Product>(productForCreateDto);
            _repositoryManager.ProductRepository.Insert(productMdl);
            _repositoryManager.save();
            var productDto = _mapper.Map<ProductDto>(productMdl);
            return productDto;
        }

        public void CreateProductManyPhoto(ProductForCreateDto productForCreateDto, List<ProductPhotoCreateDto> productPhotoCreateDtos)
        {
            //1. insert into table produk
            var productMdl = _mapper.Map<Product>(productForCreateDto);
            _repositoryManager.ProductRepository.Insert(productMdl);
            _repositoryManager.save();

            //insert into table productPhotos
            foreach (var item in productPhotoCreateDtos)
            {
                item.PhotoProductId = productMdl.ProductId;
                var photoModel = _mapper.Map<ProductPhoto>(item);
                _repositoryManager.ProductPhotoRepository.Insert(photoModel);
            }
            _repositoryManager.save();
            {

            }
        }
    }
}
