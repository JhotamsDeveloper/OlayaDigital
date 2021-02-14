using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OlayaDigital.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OlayaDigital.Infrastructure.Data.Configurations
{
    public class CommentConfig : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comentario");

            builder.HasKey(x => x.Id);

            builder.Property(e => e.Description).IsRequired()
            .HasColumnName("Descripcion");

            builder.Property(e => e.IdPost).IsRequired()
            .HasColumnName("IdPublicacion");

            builder.Property(e => e.IdUser).IsRequired()
            .HasColumnName("IdUsuario");

            builder.HasOne(d => d.Post)
                .WithMany(p => p.Coments)
                .HasForeignKey(d => d.IdPost)
                .HasConstraintName("FK__Comentari__IdPub__1DE57479");

            builder.HasOne(d => d.User)
                .WithMany(p => p.Comments)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK__Comentari__IdUsu__1ED998B2");
        }
    }
}
