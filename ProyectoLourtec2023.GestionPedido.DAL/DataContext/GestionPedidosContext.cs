﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProyectoLourtec2023.GestionPedido.Models;
namespace ProyectoLourtec2023.GestionPedido.DAL.DataContext;

public partial class GestionPedidosContext : DbContext
{
    public GestionPedidosContext()
    {
    }

    public GestionPedidosContext(DbContextOptions<GestionPedidosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<TipoCli> TipoClis { get; set; }

    public virtual DbSet<Vendedor> Vendedors { get; set; }

    public virtual DbSet<VentaD> VentaDs { get; set; }

    public virtual DbSet<VentaE> VentaEs { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cliente__3214EC07B0EA4425");

            entity.ToTable("Cliente");

            entity.Property(e => e.Correo)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Notas)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Razon)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Rif)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("RIF");
            entity.Property(e => e.Telefono)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.IdTipoCliNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.IdTipoCli)
                .HasConstraintName("FK__Cliente__IdTipoC__398D8EEE");
        });

        modelBuilder.Entity<TipoCli>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TipoCli__3214EC079A89D244");

            entity.ToTable("TipoCli");

            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Vendedor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Vendedor__3214EC07137A3AE3");

            entity.ToTable("Vendedor");

            entity.Property(e => e.Cedula)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VentaD>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("VentaD");

            entity.Property(e => e.Cantidad).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Costo).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.DescuentoP)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("Descuento_P");
            entity.Property(e => e.DescuentoV)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("Descuento_V");
            entity.Property(e => e.Precio).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Total)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.IdNavigation).WithMany()
                .HasForeignKey(d => d.Id)
                .HasConstraintName("FK__VentaD__Total__403A8C7D");
        });

        modelBuilder.Entity<VentaE>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__VentaE__3214EC07C5B46976");

            entity.ToTable("VentaE");

            entity.Property(e => e.Cantidad).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Documento)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.Impuesto).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Notas)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Subtotal).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Total).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.IdVendedorNavigation).WithMany(p => p.VentaEs)
                .HasForeignKey(d => d.IdVendedor)
                .HasConstraintName("FK__VentaE__IdVended__3E52440B");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
