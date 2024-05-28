using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TechGamer.Core.DomainObjects;
using TechGamer.Domain.Interfaces;
using TechGamer.Infra.Data.Context;

namespace TechGamer.Infra.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly TechGamerDbContext Db;
        protected readonly DbSet<T> DbSet;

        public Repository(TechGamerDbContext context)
        {
            Db = context;
            DbSet = Db.Set<T>();
        }

        protected IQueryable<T> Query()
        {
            return DbSet;
        }

        public void Dispose()
        {
            Db?.Dispose();
            GC.SuppressFinalize(this);
        }

        public long Count()
        {
            return DbSet.LongCount();
        }

        public long Count(Expression<Func<T, bool>> predicate)
        {
            var result = DbSet.LongCount(predicate);
            return result;
        }
    }
}
