using Northwind.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Domain.Repositories
{
    public interface IOrderDetailsRepository
    {
        Task<IEnumerable<OrderDetail>> GetAllOrderDetails(bool trackChanges);
        Task<OrderDetail>GettAllOrderDetailsById(int orderDetailId, bool trackChanges);
        Task<OrderDetail>GetOrderDetailById(int orderDetailID,bool trackChanges);
        void Insert(OrderDetail orderDetail);
        void Edit(OrderDetail orderDetail);
        void Remove(OrderDetail orderDetail);
    }
}
