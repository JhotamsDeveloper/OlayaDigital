using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OlayaDigital.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OlayaDigital.Infrastructure.Data.Configurations
{
    public class AuditConfig : IEntityTypeConfiguration<Audit>
    {
        public void Configure(EntityTypeBuilder<Audit> builder)
        {
            builder.ToTable("Auditoria");

            builder.HasKey(x => x.Id);

            builder.Property(e => e.DateCreate)
            .HasColumnName("FechaCreacion")
            .HasColumnType("datetime");

            builder.Property(e => e.DateUpdate)
            .HasColumnName("FechaActualizacion")
            .HasColumnType("datetime");

            builder.Property(e => e.IdPost)
            .HasColumnName("IdPublicacion");

            builder.HasOne(d => d.Posts)
                .WithMany(p => p.Audits)
                .HasForeignKey(d => d.IdPost)
                .HasConstraintName("FK__Auditoria__IdPub__1B0907CE");
        }
    }
}
