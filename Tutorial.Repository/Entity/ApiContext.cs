using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Tutorial.Repository.Entity;

public partial class ApiContext : DbContext
{
    public ApiContext()
    {
    }

    public ApiContext(DbContextOptions<ApiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-DNV1FA0\\TIEN;Database=API;User Id=sa;Password=12345;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Acsount");

            entity.ToTable("Account");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.ToTable("Book");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Author).HasMaxLength(50);
            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.Genre).HasMaxLength(50);
            entity.Property(e => e.Isbn)
                .HasMaxLength(50)
                .HasColumnName("ISBN");
            entity.Property(e => e.PublishedDate).HasColumnType("datetime");
            entity.Property(e => e.Publisher).HasMaxLength(50);
            entity.Property(e => e.Title).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
