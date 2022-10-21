using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace StockGularBack.Data.DB
{
    public partial class StockContext : DbContext
    {
        public StockContext()
        {
        }

        public StockContext(DbContextOptions<StockContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Article> Articles { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("SERVER=.\\SQLEXPRESS;database=Stock;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CategoryId).HasColumnName("categoryId");

                entity.Property(e => e.CodeArticle)
                    .HasMaxLength(20)
                    .HasColumnName("codeArticle")
                    .IsFixedLength();

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.Designation)
                    .HasMaxLength(100)
                    .HasColumnName("designation")
                    .IsFixedLength();

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.IdEntreprise).HasColumnName("idEntreprise");

                entity.Property(e => e.Photo)
                    .HasMaxLength(255)
                    .HasColumnName("photo")
                    .IsFixedLength();

                entity.Property(e => e.PrixUnitaireHt).HasColumnName("prixUnitaireHt");

                entity.Property(e => e.PrixUnitaireTtc).HasColumnName("prixUnitaireTtc");

                entity.Property(e => e.TauxTva).HasColumnName("tauxTva");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Designation)
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
