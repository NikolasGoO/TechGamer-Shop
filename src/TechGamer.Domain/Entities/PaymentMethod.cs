﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechGamer.Core.DomainObjects;

namespace TechGamer.Domain.Entities
{
    public class PaymentMethod : Entity
    {
        public PaymentMethod(string alias,
            string cardId,
            string last4,
            Client client)
        {
            Alias = alias;
            CardId = cardId;
            Last4 = last4;
            ClientId = client.Id;
            Client = client;
        }

        protected PaymentMethod() { }

        public string Alias { get; private set; }
        public string CardId { get; private set; }
        public string Last4 { get; private set; }
        public Guid ClientId { get; private set; }
        public Client Client { get; private set; }
    }
}
