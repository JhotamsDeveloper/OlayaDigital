using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using OlayaDigital.Core.Entities;
using OlayaDigital.Infrastructure.Data.Configurations;

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

        public virtual DbSet<Audit> Audits { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Comment> Commets { get; set; }
        public virtual DbSet<Media> Media { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AuditConfig());
            modelBuilder.ApplyConfiguration(new CategoryConfig());
            modelBuilder.ApplyConfiguration(new CommentConfig());
            modelBuilder.ApplyConfiguration(new MediaConfig());
            modelBuilder.ApplyConfiguration(new PostConfig());
            modelBuilder.ApplyConfiguration(new UserConfig());
        }
    }
}
