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
        Task<IEnumerable<OrderDetailsDto>>GetAllChartItem(string custID, bool trackChanges);
        Task<OrderDetailsDto> GetOrderDetailsById(int orderDetailId, bool trackChanges);
        Task<OrderDetailsDto>GetOrderDetails(int orderId, int productId,bool trackChanges);
        void Insert(OrderDetailsForCreateDto orderDetailsForCreateDto);
        void Edit(OrderDetailsDto orderDetailsDto);
        void Remove(OrderDetailsDto orderDetailsDto);
    }
}
