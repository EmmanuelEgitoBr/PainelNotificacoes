using AutoMapper;
using RealTimeNotificationApp.Application.Dtos;
using RealTimeNotificationApp.Application.Interfaces;
using RealTimeNotificationApp.Domain.Entities;
using RealTimeNotificationApp.Domain.Enums;
using RealTimeNotificationApp.Domain.Interfaces;

namespace RealTimeNotificationApp.Application.Services
{
    public class DeliveryService : IDeliveryService
    {
        private readonly IDeliveryRepository _deliveryRepository;
        private readonly IMapper _mapper;

        public DeliveryService(IDeliveryRepository deliveryRepository,
                            IMapper mapper)
        {
            _deliveryRepository = deliveryRepository;
            _mapper = mapper;
        }

        public async Task<DeliveryDto> RegisterDelivery(string orderNumber, 
                                                        DateTime creationDate, 
                                                        CancellationToken cancellationToken = default)
        {
            var deliveryStatusList = new List<DeliveryStatus>();
            var firstStatus = new DeliveryStatus(Status.Registrada, creationDate);
            deliveryStatusList.Add(firstStatus);

            var deliveryEntity = new Delivery
            {
                Id = new Guid(),
                NumeroPedido = orderNumber,
                ListaStatus = deliveryStatusList
            };

            await _deliveryRepository.CreateAsync(deliveryEntity);

            return _mapper.Map<DeliveryDto>(deliveryEntity);
        }

        public async Task<DeliveryDto> UpdateStatusDelivery(DeliveryDto delivery,
                                                            int statusFinal,
                                                            CancellationToken cancellationToken = default)
        {
            var deliveryEntity = _mapper.Map<Delivery>(delivery);
            
            var newStatus = new DeliveryStatus((Status)statusFinal, DateTime.Now);
            deliveryEntity.ListaStatus!.Add(newStatus);

            await _deliveryRepository.UpdateAsync(deliveryEntity, deliveryEntity.Id);

            return _mapper.Map<DeliveryDto>(deliveryEntity);
        }
    }
}
