using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechGamer.Application.ViewModel;
using TechGamer.Domain.Entities;

namespace TechGamer.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {

            CreateMap<Address, AddressViewModel>()
                .ReverseMap();
            CreateMap<Basket, BasketViewModel>()
                .ReverseMap();
            CreateMap<BasketItem, BasketItemViewModel>()
                .ReverseMap();
            CreateMap<Client, ClientViewModel>()
                .ReverseMap();
            CreateMap<Order, OrderViewModel>()
                .ReverseMap();
            CreateMap<OrderItem, OrderItemViewModel>()
                .ReverseMap();
            CreateMap<PaymentMethod, PaymentMethodViewModel>()
                .ReverseMap();
            CreateMap<Product, ProductViewModel>()
                .ReverseMap();
            CreateMap<Voucher, VoucherViewModel>()
                .ReverseMap();

        }
    }
}
