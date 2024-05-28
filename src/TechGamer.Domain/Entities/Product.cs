using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechGamer.Core.DomainObjects;

namespace TechGamer.Domain.Entities
{
    public class Product : Entity
    {
        protected Product() { }
        public Product(Guid id, string brand, string name, string description, int amount, decimal price, bool active, string image)
        {
            Id = id;
            Brand = brand;
            Name = name;
            Description = description;
            StockQuantity = amount;
            Price = price;
            Active = active;
            Image = image;
        }

        public string Brand { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int StockQuantity { get; private set; }
        public decimal Price { get; private set; }
        public bool Active { get; private set; }
        public string Image { get; private set; }

        public void SetAddRemoveStock(int amount)
        {
            StockQuantity += amount;
        }
    }
}
