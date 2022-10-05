using Northwind.Contracts.Dto.Suppliers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindServicesAbstraction
{
    public interface ISuppliersServices
    {
        Task<IEnumerable<SuppliersDto>> GetAllSuppliers(bool trackChanges);
        Task<SuppliersDto>GetSuppliersById(int suppliersId, bool trackChanges);
        void Insert(SuppliersForCreateDto suppliersForCreateDto);
        void Edit(SuppliersDto suppliersDto);
        void Remove(SuppliersDto suppliersDto);
    }
}
