using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechGamer.Infra.Data.Mapping;

namespace TechGamer.Infra.Data.Context
{
    public class TechGamerDbContext : DbContext
    {
        public TechGamerDbContext(DbContextOptions<TechGamerDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AddressMap());
            modelBuilder.ApplyConfiguration(new BasketMap());
            modelBuilder.ApplyConfiguration(new BasketItemMap());
            modelBuilder.ApplyConfiguration(new ClientMap());
            modelBuilder.ApplyConfiguration(new OrderMap());
            modelBuilder.ApplyConfiguration(new OrderItemMap());
            modelBuilder.ApplyConfiguration(new PaymentMethodMap());
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new VoucherMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
