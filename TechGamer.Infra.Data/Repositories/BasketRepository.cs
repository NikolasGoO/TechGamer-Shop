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
    public class BasketRepository : Repository<Basket>, IBasketRepository
    {
        protected readonly IClientRepository _clientRepository;
        public BasketRepository(TechGamerDbContext context, IClientRepository clientRepository) : base(context)
        {
            _clientRepository = clientRepository;
        }

        public Basket Add(Basket entity)
        {
            DbSet.Add(entity);

            if (entity.Client == null)
            {
                entity.SetClient(_clientRepository.GetById(entity.ClientId));
            }

            return entity;
        }

        public Basket GetById(Guid id)
        {
            var context = DbSet.AsQueryable();
            var basket = context.FirstOrDefault(c => c.Id == id);
            if (basket.Client == null)
            {
                basket.SetClient(_clientRepository.GetById(basket.ClientId));
            }
            return basket;
        }

        public void Remove(Guid id)
        {
            var obj = GetById(id);
            if (obj != null)
            {
                DbSet.Remove(obj);
            }
        }

        public void Remove(Expression<Func<Basket, bool>> predicate)
        {
            var context = DbSet.AsQueryable();
            var entities = context.Where(predicate);
            DbSet.RemoveRange(entities);
        }

        public IEnumerable<Basket> Search(Expression<Func<Basket, bool>> predicate)
        {
            var context = DbSet.AsQueryable().Include("Client");
            return context.Where(predicate).ToList();
        }

        public IEnumerable<Basket> Search(Expression<Func<Basket, bool>> predicate,
            int pageNumber,
            int pageSize)
        {
            var context = DbSet.AsQueryable().Include("Client");
            var result = context.Where(predicate)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);
            return result;
        }

        public Basket Update(Basket entity)
        {
            DbSet.Update(entity);
            return entity;
        }
    }
}
