using AutoMapper;
using RealTimeNotificationApp.Application.Dtos;
using RealTimeNotificationApp.Domain.Entities;
using RealTimeNotificationApp.Domain.Enums;

namespace RealTimeNotificationApp.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<Delivery, DeliveryDto>().ReverseMap();
            CreateMap<DeliveryStatus, DeliveryStatusDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<Status, StatusDto>().ReverseMap();
        }
    }
}
