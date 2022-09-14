using AutoMapper;
using Northwind.Contracts.Dto.Category;
using Northwind.Domain.Base;
using NorthwindServicesAbstraction;
using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategories(bool trackChanges)
        {
            var categoryMdl = await _repositoryManager.CategoryRepository.GetAllCategories(trackChanges);
            var categoryDto = _mapper.Map<IEnumerable<CategoryDto>>(categoryMdl);
            return categoryDto;
        }

        public Task<CategoryDto> GetCategoryById(int categoryId, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public void insert(CategoryForCreateDto categoryForCreateDto)
        {
            throw new NotImplementedException();
        }

        public void remove(CategoryDto categoryDto)
        {
            throw new NotImplementedException();
        }
    }
}
