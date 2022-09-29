using AutoMapper;
using Northwind.Contracts.Dto.Category;
using Northwind.Domain.Base;
using Northwind.Domain.Models;
using NorthwindServicesAbstraction;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NorthwindServices
{
    public class CategoryServices : ICategoryServices
    {
        private IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        //depedency Imapper
        public CategoryServices(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public void edit(CategoryDto categoryDto)
        {
            var categoryMdl = _mapper.Map<Category>(categoryDto);
            _repositoryManager.CategoryRepository.edit(categoryMdl);
            _repositoryManager.save();
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategories(bool trackChanges)
        {
            var categoryMdl = await _repositoryManager.CategoryRepository.GetAllCategories(trackChanges);
            var categoryDto = _mapper.Map<IEnumerable<CategoryDto>>(categoryMdl);
            return categoryDto;
        }

        public async Task<CategoryDto> GetCategoryById(int categoryId, bool trackChanges)
        {
            var categoryMdl = await _repositoryManager.CategoryRepository.GetCategoryById(categoryId, trackChanges);
            var categoryDto = _mapper.Map<CategoryDto>(categoryMdl);
            return categoryDto;
        }

        public void insert(CategoryForCreateDto categoryForCreateDto)
        {
            var categoryMdl = _mapper.Map<Category>(categoryForCreateDto);
            _repositoryManager.CategoryRepository.insert(categoryMdl);
            _repositoryManager.save();
        }

        public void remove(CategoryDto categoryDto)
        {
            var categoryMdl = _mapper.Map<Category>(categoryDto);
            _repositoryManager.CategoryRepository.remove(categoryMdl);
            _repositoryManager.save();
        }
    }
}
