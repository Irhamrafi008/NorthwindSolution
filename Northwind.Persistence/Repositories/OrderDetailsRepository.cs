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
    internal class OrderDetailsRepository : RepositoryBase<OrderDetail>, IOrderDetailsRepository
    {
        public OrderDetailsRepository(NorthwindContext dbContext) : base(dbContext)
        {
        }

        public void Edit(OrderDetail orderDetail)
        {
            Update(orderDetail);
        }

        public async Task<IEnumerable<OrderDetail>> GetAllOrderDetails(bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(c => c.OrderId).ToListAsync();
        }

        public async Task<OrderDetail> GetOrderDetailById(int orderDetailID, bool trackChanges)
        {
            var orderDetails = await FindByCondition(c => c.ProductId.Equals(orderDetailID), trackChanges)
                .Where(c => c.OrderId == orderDetailID).SingleOrDefaultAsync();
            return orderDetails;
        }

        public async Task<OrderDetail> GettAllOrderDetailsById(int orderDetailId, bool trackChanges)
        {
            return await FindByCondition(c => c.OrderId.Equals(orderDetailId), trackChanges).SingleOrDefaultAsync();
        }


        public void Insert(OrderDetail orderDetail)
        {
            Create(orderDetail);    
        }

        public void Remove(OrderDetail orderDetail)
        {
            Delete(orderDetail);
        }
    }
}
