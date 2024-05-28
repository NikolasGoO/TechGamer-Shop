using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechGamer.Domain.Entities;

namespace TechGamer.Infra.Data.Mapping
{
    public class AddressMap : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Address");
            builder.Property(a => a.Street).HasMaxLength(200).IsRequired();
            builder.Property(a => a.Number).HasMaxLength(5);
            builder.Property(a => a.Complement).HasMaxLength(200);
            builder.Property(a => a.Neighborhood).HasMaxLength(100).IsRequired();
            builder.Property(a => a.City).HasMaxLength(50).IsRequired();
            builder.Property(a => a.State).HasMaxLength(2).IsRequired();
            builder.Property(a => a.PostalCode).HasMaxLength(8).IsRequired();

            builder.HasKey(a => a.Id);
        }
    }
}
