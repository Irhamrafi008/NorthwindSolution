using Microsoft.EntityFrameworkCore;
using Northwind.Domain.Models;
using Northwind.Domain.Repositories;
using Northwind.Persistence.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Persistence.Repositories
{
    internal class OrdersRepository : RepositoryBase<Order>, IOrdersRepository
    {
        public OrdersRepository(NorthwindContext dbContext) : base(dbContext)
        {
        }

        public void Edit(Order order)
        {
            Update(order);
        }

        public async Task<IEnumerable<Order>> GetAllOrders(bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(c => c.OrderId).ToListAsync();
        }

        public async Task<Order> GetOrderById(int OrderId, bool trackChanges)
        {
            return await FindByCondition(c => c.OrderId.Equals(OrderId), trackChanges).SingleOrDefaultAsync();
        }

        public void Insert(Order order)
        {
            Create(order);
        }

        public void Remove(Order order)
        {
            Delete(order);
        }
    }
}
