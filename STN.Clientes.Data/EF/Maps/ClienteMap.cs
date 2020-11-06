using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using STN.Clientes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace STN.Clientes.Data.EF.Maps
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable(nameof(Cliente));

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.Property(c => c.Nome).IsRequired().HasColumnType("varchar(100)");
            builder.Property(c => c.Estado).IsRequired().HasColumnType("varchar(100)");
            builder.Property(c => c.Cpf).IsRequired().HasColumnType("varchar(12)");
        }
    }
}
