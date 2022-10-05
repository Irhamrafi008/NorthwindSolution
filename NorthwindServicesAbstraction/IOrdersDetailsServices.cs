using Northwind.Contracts.Dto.OrderDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindServicesAbstraction
{
    public interface IOrdersDetailsServices
    {
        Task<IEnumerable<OrderDetailsDto>> GetAllOrderDetails(bool trackChanges);
        Task<OrderDetailsDto> GetOrderDetailsById(int orderDetailId, bool trackChanges);
        void Insert(OrderDetailsForCreateDto orderDetailsForCreateDto);
        void Edit(OrderDetailsDto orderDetailsDto);
        void Remove(OrderDetailsDto orderDetailsDto);
    }
}
