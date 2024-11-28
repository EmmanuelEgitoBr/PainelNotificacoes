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

        public async Task DeleteOrder(string orderNumber)
        {
            await _orderRepository.DeleteAsync(o => o.NumeroPedido == orderNumber);
        }

        public async Task<OrderDto> GetOrder(string orderNumber, CancellationToken cancellationToken = default)
        {
            var orderEntity = await _orderRepository.FindAsync(o => o.NumeroPedido == orderNumber, cancellationToken);

            return _mapper.Map<OrderDto>(orderEntity);
        }

        public async Task<OrderDto> RegisterOrder(OrderDto orderDto, CancellationToken cancellationToken = default)
        {
            string numPedido = Validations.GenerateOrderNumber(DateTime.Now, orderDto.Telefone);

            orderDto.NumeroPedido = numPedido;
            orderDto.CriadoEm = DateTime.Now;

            var orderEntity = _mapper.Map<Order>(orderDto);

            await _orderRepository.CreateAsync(orderEntity);

            return orderDto;
        }

        public async Task<OrderDto> UpdateContactNumber(string orderNumber, string newPhone, CancellationToken cancellationToken = default)
        {
            var orderEntity = await _orderRepository.FindAsync(o => o.NumeroPedido == orderNumber, cancellationToken);
            orderEntity.Telefone = newPhone;

            await _orderRepository.UpdateAsync(orderEntity, orderEntity.Id);

            return _mapper.Map<OrderDto>(orderEntity);
        }
    }
}
