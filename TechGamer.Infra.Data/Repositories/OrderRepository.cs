﻿using System;
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
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(TechGamerDbContext context) : base(context)
        { }

        public Order Add(Order entity)
        {
            DbSet.Add(entity);
            return entity;
        }

        public Order GetById(Guid id)
        {
            var context = DbSet.AsQueryable();
            var order = context.FirstOrDefault(c => c.Id == id);
            return order;
        }

        public void Remove(Guid id)
        {
            var obj = GetById(id);
            if (obj != null)
            {
                DbSet.Remove(obj);
            }
        }

        public void Remove(Expression<Func<Order, bool>> predicate)
        {
            var context = DbSet.AsQueryable();
            var entities = context.Where(predicate);
            DbSet.RemoveRange(entities);
        }

        public IEnumerable<Order> Search(Expression<Func<Order, bool>> predicate)
        {
            var context = DbSet.AsQueryable();
            return context.Where(predicate).ToList();
        }

        public IEnumerable<Order> Search(Expression<Func<Order, bool>> predicate,
            int pageNumber,
            int pageSize)
        {
            var context = DbSet.AsQueryable();
            var result = context.Where(predicate)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);
            return result;
        }

        public Order Update(Order entity)
        {
            DbSet.Update(entity);
            return entity;
        }
    }
}
