using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OlayaDigital.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OlayaDigital.Infrastructure.Data.Configurations
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categoria");

            builder.HasKey(x => x.Id);

            builder.Property(e => e.Name).IsRequired()
            .HasColumnName("Nombre");

            builder.Property(e => e.Url).IsRequired();
        }
    }
}
