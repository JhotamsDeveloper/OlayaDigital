using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using OlayaDigital.Core.Entities;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace OlayaDigital.Infrastructure.Data
{
    public partial class db_OlayaDigitalContext : DbContext
    {
        public db_OlayaDigitalContext()
        {
        }

        public db_OlayaDigitalContext(DbContextOptions<db_OlayaDigitalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Auditoria> Auditoria { get; set; }
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Comentario> Comentario { get; set; }
        public virtual DbSet<Multimedia> Multimedia { get; set; }
        public virtual DbSet<Publicacion> Publicacion { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Auditoria>(entity =>
            {
                entity.Property(e => e.FechaActualizacion).HasColumnType("datetime");

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.HasOne(d => d.IdPublicacionNavigation)
                    .WithMany(p => p.Auditoria)
                    .HasForeignKey(d => d.IdPublicacion)
                    .HasConstraintName("FK__Auditoria__IdPub__1B0907CE");
            });

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.Property(e => e.Nombre).IsRequired();

                entity.Property(e => e.Url).IsRequired();
            });

            modelBuilder.Entity<Comentario>(entity =>
            {
                entity.Property(e => e.Descripcion).IsRequired();

                entity.HasOne(d => d.IdPublicacionNavigation)
                    .WithMany(p => p.Comentario)
                    .HasForeignKey(d => d.IdPublicacion)
                    .HasConstraintName("FK__Comentari__IdPub__1DE57479");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Comentario)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Comentari__IdUsu__1ED998B2");
            });

            modelBuilder.Entity<Multimedia>(entity =>
            {
                entity.Property(e => e.NombreArchivo).IsRequired();

                entity.HasOne(d => d.IdPublicacionNavigation)
                    .WithMany(p => p.Multimedia)
                    .HasForeignKey(d => d.IdPublicacion)
                    .HasConstraintName("FK__Multimedi__IdPub__182C9B23");
            });

            modelBuilder.Entity<Publicacion>(entity =>
            {
                entity.Property(e => e.Descripcion).IsRequired();

                entity.Property(e => e.Titulo).IsRequired();

                entity.Property(e => e.Url).IsRequired();

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Publicacion)
                    .HasForeignKey(d => d.IdCategoria)
                    .HasConstraintName("FK__Publicaci__IdCat__145C0A3F");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Publicacion)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Publicaci__IdUsu__15502E78");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.Correo).IsRequired();

                entity.Property(e => e.Nombre).IsRequired();

                entity.Property(e => e.Telefono).IsRequired();
            });

        }
    }
}
