using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OlayaDigital.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OlayaDigital.Infrastructure.Data.Configurations
{
    public class PostConfig : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Publicacion");

            builder.HasKey(x => x.Id);

            builder.Property(e => e.Tittle).IsRequired()
            .HasColumnName("Titulo");

            builder.Property(e => e.Url).IsRequired();

            builder.Property(e => e.Description).IsRequired()
            .HasColumnName("Descripcion");

            builder.Property(e => e.IdCategory).IsRequired()
            .HasColumnName("IdCategoria");

            builder.Property(e => e.IdUser).IsRequired()
            .HasColumnName("IdUsuario");

            builder.HasOne(d => d.Category)
                .WithMany(p => p.Posts)
                .HasForeignKey(d => d.IdCategory)
                .HasConstraintName("FK__Publicaci__IdCat__145C0A3F");

            builder.HasOne(d => d.User)
                .WithMany(p => p.Posts)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK__Publicaci__IdUsu__15502E78");
        }
    }
}
