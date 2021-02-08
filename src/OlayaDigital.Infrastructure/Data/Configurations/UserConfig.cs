using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OlayaDigital.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OlayaDigital.Infrastructure.Data.Configurations
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Usuario");

            builder.HasKey(x => x.Id);

            builder.Property(e => e.Email).IsRequired()
            .HasColumnName("Correo");

            builder.Property(e => e.Name).IsRequired()
            .HasColumnName("Nombre");

            builder.Property(e => e.Phone).IsRequired()
            .HasColumnName("Telefono");
        }
    }
}
