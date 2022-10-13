using AutoMapper;
using Northwind.Contracts.Dto.OrderDetails;
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
    public class OrderDetailsServices : IOrdersDetailsServices
    {
        private IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public OrderDetailsServices(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderDetailsDto>> GetAllOrderDetails(bool trackChanges)
        {
            var orderDetailsMdl = await _repositoryManager.OrdersDetailsRepository.GetAllOrderDetails(trackChanges);
            var orderDetailsDto = _mapper.Map <IEnumerable<OrderDetailsDto>>(orderDetailsMdl);
            return orderDetailsDto;
        }

        public async Task<OrderDetailsDto> GetOrderDetailsById(int orderDetailId, bool trackChanges)
        {
            var orderDetailsMdl = await _repositoryManager.OrdersDetailsRepository.GettAllOrderDetailsById(orderDetailId, trackChanges);
            var ordersDetailsDto = _mapper.Map<OrderDetailsDto>(orderDetailsMdl);
            return ordersDetailsDto;
        }

        public void Insert(OrderDetailsForCreateDto orderDetailsForCreateDto)
        {
            var orderDetailMdl = _mapper.Map<OrderDetail>(orderDetailsForCreateDto);
            _repositoryManager.OrdersDetailsRepository.Insert(orderDetailMdl);
            _repositoryManager.save();
        }

        public void Edit(OrderDetailsDto orderDetailsDto)
        {
            var orderDetailsMdl = _mapper.Map<OrderDetail>(orderDetailsDto);
            _repositoryManager.OrdersDetailsRepository.Edit(orderDetailsMdl);
            _repositoryManager.save();
        }

        public void Remove(OrderDetailsDto orderDetailsDto)
        {
            var ordersDetailsMdl = _mapper.Map<OrderDetail>(orderDetailsDto);
            _repositoryManager.OrdersDetailsRepository.Remove(ordersDetailsMdl);
            _repositoryManager.save();
        }

        public async Task<OrderDetailsDto> GetOrderDetails(int orderId, int productId, bool trackChanges)
        {
            var mdl = await _repositoryManager.OrdersDetailsRepository.GetOrderDetails(orderId, productId, trackChanges);
            var dto = _mapper.Map<OrderDetailsDto>(mdl);
            return dto;
        }

        public async Task<IEnumerable<OrderDetailsDto>> GetAllChartItem(string custID, bool trackChanges)
        {
            var mdl = await _repositoryManager.OrdersDetailsRepository.GetAllCartItem(custID, trackChanges);
            var dto = _mapper.Map<IEnumerable<OrderDetailsDto>>(mdl);
            return dto;
        }
    }
}
