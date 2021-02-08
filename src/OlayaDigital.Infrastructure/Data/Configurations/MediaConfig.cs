using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OlayaDigital.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OlayaDigital.Infrastructure.Data.Configurations
{
    public class MediaConfig : IEntityTypeConfiguration<Media>
    {
        public void Configure(EntityTypeBuilder<Media> builder)
        {
            builder.ToTable("Multimedia");

            builder.HasKey(x => x.Id);

            builder.Property(e => e.FileName).IsRequired()
            .HasColumnName("NombreArchivo");

            builder.Property(e => e.IdPost).IsRequired()
            .HasColumnName("IdPublicacion");

            builder.HasOne(d => d.Post)
                .WithMany(p => p.Medias)
                .HasForeignKey(d => d.IdPost)
                .HasConstraintName("FK__Multimedi__IdPub__182C9B23");
        }
    }
}
