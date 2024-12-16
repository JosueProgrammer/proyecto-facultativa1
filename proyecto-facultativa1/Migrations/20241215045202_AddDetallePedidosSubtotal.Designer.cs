﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using proyecto_facultativa1.Data;

#nullable disable

namespace proyecto_facultativa1.Migrations
{
    [DbContext(typeof(ProductManagementContext))]
    [Migration("20241215045202_AddDetallePedidosSubtotal")]
    partial class AddDetallePedidosSubtotal
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("proyecto_facultativa1.Data.Clientes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Direccion")
                        .HasColumnType("text");

                    b.Property<DateTime?>("FechaRegistro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Telefono")
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)");

                    b.HasKey("Id")
                        .HasName("PK__Clientes__3214EC07D649EDA9");

                    b.HasIndex(new[] { "Correo" }, "UQ__Clientes__60695A19D36B0FC1")
                        .IsUnique();

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("proyecto_facultativa1.Data.DetallePedidos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("PedidoId")
                        .HasColumnType("int");

                    b.Property<decimal>("PrecioUnitario")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<int>("ProductoId")
                        .HasColumnType("int");

                    b.Property<decimal>("Subtotal")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("decimal(21, 2)")
                        .HasComputedColumnSql("([Cantidad]*[PrecioUnitario])", false);

                    b.HasKey("Id")
                        .HasName("PK__DetalleP__3214EC073C09C1A2");

                    b.HasIndex("PedidoId");

                    b.HasIndex("ProductoId");

                    b.ToTable("DetallePedidos");
                });

            modelBuilder.Entity("proyecto_facultativa1.Data.Pedidos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("FechaPedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.HasKey("Id")
                        .HasName("PK__Pedidos__3214EC07AF6FEA41");

                    b.HasIndex("ClienteId");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("proyecto_facultativa1.Data.Productos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .HasColumnType("text");

                    b.Property<DateTime?>("FechaCreacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<int>("ProveedorId")
                        .HasColumnType("int");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK__Producto__3214EC0766318104");

                    b.HasIndex("ProveedorId");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("proyecto_facultativa1.Data.Proveedores", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Correo")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Direccion")
                        .HasColumnType("text");

                    b.Property<DateTime?>("FechaRegistro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Telefono")
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)");

                    b.HasKey("Id")
                        .HasName("PK__Proveedo__3214EC0765041B1E");

                    b.HasIndex(new[] { "Nombre" }, "UQ__Proveedo__75E3EFCFA91D2153")
                        .IsUnique();

                    b.ToTable("Proveedores");
                });

            modelBuilder.Entity("proyecto_facultativa1.Data.DetallePedidos", b =>
                {
                    b.HasOne("proyecto_facultativa1.Data.Pedidos", "Pedido")
                        .WithMany("DetallePedidos")
                        .HasForeignKey("PedidoId")
                        .IsRequired()
                        .HasConstraintName("FK__DetallePe__Pedid__48CFD27E");

                    b.HasOne("proyecto_facultativa1.Data.Productos", "Producto")
                        .WithMany("DetallePedidos")
                        .HasForeignKey("ProductoId")
                        .IsRequired()
                        .HasConstraintName("FK__DetallePe__Produ__49C3F6B7");

                    b.Navigation("Pedido");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("proyecto_facultativa1.Data.Pedidos", b =>
                {
                    b.HasOne("proyecto_facultativa1.Data.Clientes", "Cliente")
                        .WithMany("Pedidos")
                        .HasForeignKey("ClienteId")
                        .IsRequired()
                        .HasConstraintName("FK__Pedidos__Cliente__45F365D3");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("proyecto_facultativa1.Data.Productos", b =>
                {
                    b.HasOne("proyecto_facultativa1.Data.Proveedores", "Proveedor")
                        .WithMany("Productos")
                        .HasForeignKey("ProveedorId")
                        .IsRequired()
                        .HasConstraintName("FK__Productos__Prove__412EB0B6");

                    b.Navigation("Proveedor");
                });

            modelBuilder.Entity("proyecto_facultativa1.Data.Clientes", b =>
                {
                    b.Navigation("Pedidos");
                });

            modelBuilder.Entity("proyecto_facultativa1.Data.Pedidos", b =>
                {
                    b.Navigation("DetallePedidos");
                });

            modelBuilder.Entity("proyecto_facultativa1.Data.Productos", b =>
                {
                    b.Navigation("DetallePedidos");
                });

            modelBuilder.Entity("proyecto_facultativa1.Data.Proveedores", b =>
                {
                    b.Navigation("Productos");
                });
#pragma warning restore 612, 618
        }
    }
}
