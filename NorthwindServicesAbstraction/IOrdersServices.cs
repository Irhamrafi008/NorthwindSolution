﻿using Northwind.Contracts.Dto.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindServicesAbstraction
{
    public interface IOrdersServices
    {
        Task<IEnumerable<OrdersDto>> GetAllOrders(bool trackChanges);
        Task<OrdersDto>GetAllOrderById(int orderId, bool trackChanges);
        void Insert(OrdersForCreateDto ordersForCreateDto);
        void Edit(OrdersDto ordersDto);
        void Remove(OrdersDto ordersDto);
    }
}