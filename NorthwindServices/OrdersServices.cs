using AutoMapper;
using Northwind.Contracts.Dto.Order;
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
    internal class OrdersServices : IOrdersServices
    {
        private IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public OrdersServices(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrdersDto>> GetAllOrders(bool trackChanges)
        {
            var ordersMdl = await _repositoryManager.OrdersRepository.GetAllOrders(trackChanges);
            var ordersDto = _mapper.Map<IEnumerable<OrdersDto>>(ordersMdl);
            return ordersDto;
        }

        public async Task<OrdersDto> GetAllOrderById(int orderId, bool trackChanges)
        {
            var ordersMdl = await _repositoryManager.OrdersRepository.GetOrderById(orderId, trackChanges);
            var ordersDto = _mapper.Map<OrdersDto>(ordersMdl);
            return ordersDto;
        }

        public void Insert(OrdersForCreateDto ordersForCreateDto)
        {
            var ordersMdl = _mapper.Map<Order>(ordersForCreateDto);
            _repositoryManager.OrdersRepository.Insert(ordersMdl);
            _repositoryManager.save();
        }

        public void Edit(OrdersDto ordersDto)
        {
            var ordersMdl = _mapper.Map<Order>(ordersDto);
            _repositoryManager.OrdersRepository.Edit(ordersMdl);
            _repositoryManager.save();
        }

        public void Remove(OrdersDto ordersDto)
        {
            var ordersMdl = _mapper.Map<Order>(ordersDto);
            _repositoryManager.OrdersRepository.Remove(ordersMdl);
            _repositoryManager.save();
        }

        public async Task<OrdersDto> FilterCustId(string custId, bool trackChanges)
        {
            var orderMdl = await _repositoryManager.OrdersRepository.FilterCustId(custId, trackChanges);
            var orderDto = _mapper.Map<OrdersDto>(orderMdl);
            return orderDto;
        }

        public OrdersDto createOrderId(OrdersForCreateDto ordersForCreateDto)
        {
            var orderMdl = _mapper.Map<Order>(ordersForCreateDto);
            _repositoryManager.OrdersRepository.Insert(orderMdl);
            _repositoryManager.save();
            var orderDto = _mapper.Map<OrdersDto>(orderMdl);
            return orderDto;
        }

        public async Task<OrdersDto> GetOrderById(int orderId, bool trackChanges)
        {
            var orderMdl = await _repositoryManager.OrdersRepository.GetOrderById(orderId, trackChanges);
            var orderDto = _mapper.Map<OrdersDto>(orderMdl);
            return orderDto;
        }
    }
}
