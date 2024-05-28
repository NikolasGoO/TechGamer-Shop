﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechGamer.Application.ViewModel;
using TechGamer.Core.Enums;

namespace TechGamer.Application.Interfaces
{
    public interface IOrderAppService
    {
        OrderViewModel SetCreateNewOrder(OrderViewModel viewModel);
        IEnumerable<OrderItemViewModel> SetInsertNewItem(OrderItemViewModel model,
            Guid orderId);
        IEnumerable<OrderItemViewModel> DeleteItemInOrder(Guid orderItemId, Guid orderId);
        void UpdateQuantityItemInOrder(Guid orderItemId, int newQuantity);
        OrderViewModel UpdateStatusOrder(Guid orderId, OrderStatus newStatus);
        OrderViewModel SetAddressDelivery(Guid orderId, AddressViewModel addresViewModel);
        OrderViewModel SetApplyVoucher(Guid orderId, string code);

        OrderViewModel GetById(Guid orderId);

        OrderViewModel GetLastOrderByClient(Guid clientId);

        IEnumerable<OrderViewModel> GetOrdersByClient(Guid clientId);
    }
}
