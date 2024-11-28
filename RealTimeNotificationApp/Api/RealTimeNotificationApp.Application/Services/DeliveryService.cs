using AutoMapper;
using RealTimeNotificationApp.Application.Dtos;
using RealTimeNotificationApp.Application.Interfaces;
using RealTimeNotificationApp.Domain.Entities;
using RealTimeNotificationApp.Domain.Enums;
using RealTimeNotificationApp.Domain.Interfaces;
using RealTimeNotificationApp.Infra.Repositories;

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

        public async Task DeleteDelivery(string orderNumber)
        {
            await _deliveryRepository.DeleteAsync(d => d.NumeroPedido == orderNumber);
        }

        public async Task<DeliveryDto> GetDelivery(string orderNumber, CancellationToken cancellationToken = default)
        {
            var deliveryEntity = await _deliveryRepository.FindAsync(d => d.NumeroPedido == orderNumber, cancellationToken);

            return _mapper.Map<DeliveryDto>(deliveryEntity);
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

        public async Task<DeliveryDto> UpdateStatusDelivery(string orderNumber,
                                                            int statusFinal,
                                                            CancellationToken cancellationToken = default)
        {

            var deliveryEntity = await _deliveryRepository.FindAsync(d => d.NumeroPedido == orderNumber,
                                                                    cancellationToken);
            
            var newStatus = new DeliveryStatus((Status)statusFinal, DateTime.Now);
            deliveryEntity.ListaStatus!.Add(newStatus);

            await _deliveryRepository.UpdateAsync(deliveryEntity, deliveryEntity.Id);

            return _mapper.Map<DeliveryDto>(deliveryEntity);
        }
    }
}
