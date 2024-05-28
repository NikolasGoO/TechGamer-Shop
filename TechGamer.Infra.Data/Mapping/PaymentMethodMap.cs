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
    public class PaymentMethodMap : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            builder.ToTable("PaymentMethod");
            builder.Property(pm => pm.Alias).HasMaxLength(50).IsRequired();
            builder.Property(pm => pm.CardId).HasMaxLength(120).IsRequired();
            builder.Property(pm => pm.Last4).HasMaxLength(4).IsRequired();
            builder.Property(pm => pm.ClientId).IsRequired();
        }
    }
}
