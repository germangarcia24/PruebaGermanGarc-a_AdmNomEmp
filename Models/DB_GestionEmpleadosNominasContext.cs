using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PruebaGermanGarcía_AdmNomEmp.Models
{
    public partial class DB_GestionEmpleadosNominasContext : DbContext
    {
        public DB_GestionEmpleadosNominasContext()
        {
        }

        public DB_GestionEmpleadosNominasContext(DbContextOptions<DB_GestionEmpleadosNominasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblDepartamento> TblDepartamentos { get; set; } = null!;
        public virtual DbSet<TblEmpleado> TblEmpleados { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblDepartamento>(entity =>
            {
                entity.ToTable("Tbl_Departamentos");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblEmpleado>(entity =>
            {
                entity.ToTable("Tbl_Empleados");

                entity.HasIndex(e => e.Nombre, "UQ__Tbl_Empl__75E3EFCF02D0242D")
                    .IsUnique();

                entity.Property(e => e.FechaIngreso).HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroEmpleado)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SalarioMensual).HasColumnType("decimal(12, 2)");

                entity.HasOne(d => d.Departamento)
                    .WithMany(p => p.TblEmpleados)
                    .HasForeignKey(d => d.DepartamentoId)
                    .HasConstraintName("FK_Dep");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
