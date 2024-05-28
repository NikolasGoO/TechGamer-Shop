using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechGamer.Core.DomainObjects;

namespace TechGamer.Domain.Entities
{
    public class Address : Entity
    {
        public Address(string street, string city, string state, string postalCode, string complement, string number, string neighborhood)
        {
            Street = street;
            City = city;
            State = state;
            PostalCode = postalCode;
            Complement = complement;
            Number = number;
            Neighborhood = neighborhood;
        }

        protected Address() { }
        public string Street { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string PostalCode { get; private set; }
        public string Complement { get; private set; }
        public string Number { get; private set; }
        public string Neighborhood { get; private set; }
    }
}
