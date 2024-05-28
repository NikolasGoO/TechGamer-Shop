using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TechGamer.Domain.Entities;
using TechGamer.Domain.Interfaces;
using TechGamer.Infra.Data.Context;

namespace TechGamer.Infra.Data.Repositories
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        protected readonly IAddressRepository _addressRepository;
        public ClientRepository(TechGamerDbContext context, IAddressRepository addressRepository) : base(context)
        {
            _addressRepository = addressRepository;
        }

        public Client Add(Client entity)
        {
            entity.SetAddress(null);

            DbSet.Add(entity);
            return entity;
        }

        public Client GetById(Guid id)
        {
            var context = DbSet.AsQueryable();
            var client = context.FirstOrDefault(c => c.Id == id);

            if (client.ClientAddress == null)
            {
                client.SetAddress(_addressRepository.GetById(client.AddressId));
            }
            return client;
        }

        public void Remove(Guid id)
        {
            var obj = GetById(id);
            if (obj != null)
            {
                DbSet.Remove(obj);
            }
        }

        public void Remove(Expression<Func<Client, bool>> predicate)
        {
            var context = DbSet.AsQueryable();
            var entities = context.Where(predicate);
            DbSet.RemoveRange(entities);
        }

        public IEnumerable<Client> Search(Expression<Func<Client, bool>> predicate)
        {
            var context = DbSet.AsQueryable().Include("AddressClient");
            return context.Where(predicate).ToList();
        }

        public IEnumerable<Client> Search(Expression<Func<Client, bool>> predicate,
            int pageNumber,
            int pageSize)
        {
            var context = DbSet.AsQueryable().Include("AddressClient");
            var result = context.Where(predicate)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);
            return result;
        }

        public Client Update(Client entity)
        {
            DbSet.Update(entity);
            return entity;
        }
    }
}
