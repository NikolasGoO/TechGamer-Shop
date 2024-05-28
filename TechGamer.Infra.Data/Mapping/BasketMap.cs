using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechGamer.Domain.Entities;

namespace TechGamer.Infra.Data.Mapping
{
    public class BasketMap : IEntityTypeConfiguration<Basket>
    {
        public void Configure(EntityTypeBuilder<Basket> builder)
        {
            builder.ToTable("Basket");

            builder.Property(b => b.ClientId).IsRequired();

            builder.HasKey(b => b.Id);
        }
    }
}
