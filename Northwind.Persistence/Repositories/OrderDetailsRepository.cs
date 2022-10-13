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

        public async Task<IEnumerable<OrderDetail>> GetAllCartItem(string CartID, bool trackChanges)
        {
            return await FindAll(trackChanges)
                .Where(o => o.Order.CustomerId == CartID && o.Order.ShippedDate == null
                && o.Product.ProductPhotos.Any(x => x.PhotoProductId == o.ProductId))
                .Include(o => o.Order)
                .Include(p => p.Product)
                .Include(a => a.Product.ProductPhotos)
                .OrderBy(c => c.OrderId)
                .ToListAsync();
        }

        public async Task<IEnumerable<OrderDetail>> GetAllOrderDetails(bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(c => c.OrderId)
                .Include(p => p.Product)
                .Include(o => o.Order)
                .ToListAsync();
        }

        public async Task<OrderDetail> GetOrderDetailById(int orderDetailID, bool trackChanges)
        {
            var orderDetails = await FindByCondition(c => c.ProductId.Equals(orderDetailID), trackChanges)
                .Include(p => p.Product)
                .Include(o => o.Order)
                .Where(c => c.OrderId == orderDetailID)
                .SingleOrDefaultAsync();
            return orderDetails;
        }

        public async Task<OrderDetail> GetOrderDetails(int orderId, int productId, bool trackChanges)
        {
            return await FindByCondition(c => c.OrderId.Equals(orderId) && c.ProductId.Equals(productId), trackChanges)
                .Include(p =>p.Product)
                .Include(o => o.Order)
                .SingleOrDefaultAsync();
        }

        public async Task<OrderDetail> GettAllOrderDetailsById(int orderDetailId, bool trackChanges)
        {
            return await FindByCondition(c => c.OrderId.Equals(orderDetailId), trackChanges)
                .Include(p => p.Product)
                .Include(o => o.Order)
                .SingleOrDefaultAsync();
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
