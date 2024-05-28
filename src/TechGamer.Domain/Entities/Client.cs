using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechGamer.Core.DomainObjects;

namespace TechGamer.Domain.Entities
{
    public class Client : Entity
    {
        protected Client() { }
        public Client(string name, DateTime birth, Address clientAddress, string email, string password, bool active, Cpf cpf)
        {
            Name = name;
            Birth = birth;
            ClientAddress = clientAddress;
            AddressId = clientAddress.Id;
            Email = email;
            Password = password;
            Active = active;
            Cpf = cpf.Number;
        }

        public string Name { get; private set; }
        public DateTime Birth { get; private set; }
        public Address ClientAddress { get; private set; }
        public Guid AddressId { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public bool Active { get; private set; }
        public string Cpf { get; private set; }

        public void SetAddress(Address address)
        {
            AddressId = address.Id;
            ClientAddress = address;
        }

        public void SetEmail(string email)
        {
            Email = email;
        }
    }
}
