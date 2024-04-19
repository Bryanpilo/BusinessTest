using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace businessProject.Models;

public partial class BusinessProjectContext : DbContext
{
    public BusinessProjectContext()
    {
    }

    public BusinessProjectContext(DbContextOptions<BusinessProjectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TypeOfTransport> TypeOfTransports { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=CRX002-054;Initial Catalog=BusinessProject;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TypeOfTransport>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TypeOfTr__3214EC0793BE5E55");

            entity.ToTable("TypeOfTransport");

            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Speed)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
