using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Employee.Entity.Models;

public partial class TestDbContext : DbContext
{
    public TestDbContext()
    {
    }

    public TestDbContext(DbContextOptions<TestDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AddressMaster> AddressMasters { get; set; }

    public virtual DbSet<EmployeeMaster> EmployeeMasters { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=SALONY;Initial Catalog=TestDb;User Id=sa; password=root;Persist Security Info=False;Integrated Security=false;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AddressMaster>(entity =>
        {
            entity.HasKey(e => e.AddressId);

            entity.ToTable("AddressMaster");

            entity.Property(e => e.AddressId).HasDefaultValueSql("(newsequentialid())");
            entity.Property(e => e.Address).HasMaxLength(350);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.HasOne(d => d.Employee).WithMany(p => p.AddressMasters)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_AddressMaster_EmployeeMaster");
        });

        modelBuilder.Entity<EmployeeMaster>(entity =>
        {
            entity.HasKey(e => e.EmployeeId);

            entity.ToTable("EmployeeMaster");

            entity.Property(e => e.EmployeeId).HasDefaultValueSql("(newsequentialid())");
            entity.Property(e => e.Designation).HasMaxLength(50);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Name).HasMaxLength(150);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
