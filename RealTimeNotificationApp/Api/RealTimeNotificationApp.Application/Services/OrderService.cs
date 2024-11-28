using AutoMapper;
using RealTimeNotificationApp.Application.Dtos;
using RealTimeNotificationApp.Application.Interfaces;
using RealTimeNotificationApp.Application.Utils;
using RealTimeNotificationApp.Domain.Entities;
using RealTimeNotificationApp.Domain.Interfaces;

namespace RealTimeNotificationApp.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository,
                            IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<OrderDto> RegisterOrder(OrderDto orderDto, CancellationToken cancellationToken = default)
        {
            string numPedido = Validations.GenerateOrderNumber(DateTime.Now, orderDto.Telefone);

            orderDto.NumeroPedido = numPedido;

            var orderEntity = _mapper.Map<Order>(orderDto);

            await _orderRepository.CreateAsync(orderEntity);

            return orderDto;
        }
    }
}
