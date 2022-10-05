using AutoMapper;
using Northwind.Contracts.Dto.Suppliers;
using Northwind.Domain.Base;
using Northwind.Domain.Models;
using NorthwindServicesAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindServices
{
    internal class SuppliersServices : ISuppliersServices
    {
        private IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public SuppliersServices(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public void Edit(SuppliersDto suppliersDto)
        {
            var supplierMdl = _mapper.Map<Supplier>(suppliersDto);
            _repositoryManager.SuppliersRepository.Edit(supplierMdl);
            _repositoryManager.save();
        }

        public async Task<IEnumerable<SuppliersDto>> GetAllSuppliers(bool trackChanges)
        {
            var suppliersMdl = await _repositoryManager.SuppliersRepository.GetAllSuppliers(trackChanges);
            var suppliersDto = _mapper.Map<IEnumerable<SuppliersDto>>(suppliersMdl);
            return suppliersDto;
        }

        public async Task<SuppliersDto> GetSuppliersById(int suppliersId, bool trackChanges)
        {
            var suppliersMdl = await _repositoryManager.SuppliersRepository.GetAllSuppliersById(suppliersId, trackChanges);
            var suppliersDto = _mapper.Map<SuppliersDto>(suppliersMdl);
            return suppliersDto;
        }

        public void Insert(SuppliersForCreateDto suppliersForCreateDto)
        {
            var suppliersMdl = _mapper.Map<Supplier>(suppliersForCreateDto);
            _repositoryManager.SuppliersRepository.Insert(suppliersMdl);
            _repositoryManager.save();
        }

        public void Remove(SuppliersDto suppliersDto)
        {
            var suppliersMdl = _mapper.Map<Supplier>(suppliersDto);
            _repositoryManager.SuppliersRepository.Remove(suppliersMdl);
            _repositoryManager.save();
        }
    }
}
