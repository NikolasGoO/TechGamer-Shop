using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechGamer.Domain.Shared.Transaction;

namespace TechGamer.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context.TechGamerDbContext _context;

        public UnitOfWork(Context.TechGamerDbContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
