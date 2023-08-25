using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Services.Core.Data;

namespace Services.Infraestructure.Data;

public partial class PruebaStevensNexosContext : DbContext
{
    public PruebaStevensNexosContext()
    {
    }

    public PruebaStevensNexosContext(DbContextOptions<PruebaStevensNexosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Autore> Autores { get; set; }

    public virtual DbSet<Libro> Libros { get; set; }

    public virtual DbSet<Paciente> Pacientes { get; set; }

    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Autore>(entity =>
        {
            entity.HasKey(e => e.IdAutor).HasName("PK__Autores__9AE8206A54D2C6B6");

            entity.Property(e => e.IdAutor).HasColumnName("idAutor");
            entity.Property(e => e.AutorFechaNacimiento)
                .HasColumnType("datetime")
                .HasColumnName("autorFechaNacimiento");
            entity.Property(e => e.CiudadAutor)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ciudadAutor");
            entity.Property(e => e.EmailAutor)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("emailAutor");
            entity.Property(e => e.NombreAutor)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombreAutor");
        });

        modelBuilder.Entity<Libro>(entity =>
        {
            entity.HasKey(e => e.IdLibro).HasName("PK__Libros__5BC0F02633AD6DB9");

            entity.Property(e => e.IdLibro).HasColumnName("idLibro");
            entity.Property(e => e.IdAutor).HasColumnName("idAutor");
            entity.Property(e => e.LibroFecha)
                .HasColumnType("datetime")
                .HasColumnName("libroFecha");
            entity.Property(e => e.LibroGenero)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("libroGenero");
            entity.Property(e => e.LibroTitulo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("libroTitulo");
            entity.Property(e => e.NumeroPaginas)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("numeroPaginas");

            entity.HasOne(d => d.IdAutorNavigation).WithMany(p => p.Libros)
                .HasForeignKey(d => d.IdAutor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Libros__idAutor__47DBAE45");
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.HasKey(e => e.IdPaciente).HasName("PK__Paciente__F48A08F2C14C71D3");

            entity.Property(e => e.IdPaciente).HasColumnName("idPaciente");
            entity.Property(e => e.DireccionPaciente)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("direccionPaciente");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.IdIdentificacion)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("idIdentificacion");
            entity.Property(e => e.NombrePaciente)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombrePaciente");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
