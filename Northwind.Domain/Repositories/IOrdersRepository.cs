using Northwind.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Domain.Repositories
{
    public interface IOrdersRepository
    {
        Task<IEnumerable<Order>> GetAllOrders(bool trackChanges);
        Task<Order> GetOrderById(int OrderId, bool trackChanges);
        void Insert(Order order);
        void Edit(Order order);
        void Remove(Order order);
    }
}
