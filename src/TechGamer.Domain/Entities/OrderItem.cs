using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechGamer.Core.DomainObjects;

namespace TechGamer.Domain.Entities
{
    public class OrderItem : Entity
    {
        public OrderItem(int amount, decimal unitPrice, Order order, Product product)
        {
            OrderId = order.Id;
            ProductId = product.Id;
            ProductName = product.Name;
            Amount = amount;
            UnitPrice = unitPrice;
            ProductImage = product.Image;
            Order = order;
            Product = product;
        }

        protected OrderItem() { }
        public Guid OrderId { get; private set; }
        public Guid ProductId { get; private set; }
        public string ProductName { get; private set; }
        public int Amount { get; private set; }
        public decimal UnitPrice { get; private set; }
        public string ProductImage { get; private set; }
        public Order Order { get; private set; }
        public Product Product { get; private set; }

        public void SetAddAmount(int Amount) 
        {
            Amount += Amount;
        }

        public decimal TotalValueItem()
        {
            return UnitPrice * Amount;
        }
    }
}
