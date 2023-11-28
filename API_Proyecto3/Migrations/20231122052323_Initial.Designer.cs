﻿// <auto-generated />
using System;
using API_Proyecto3.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API_Proyecto3.Migrations
{
    [DbContext(typeof(API_Proyecto3Context))]
    [Migration("20231122052323_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("API_Proyecto3.Models.Empleado", b =>
                {
                    b.Property<int>("EmpleadoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmpleadoId"), 1L, 1);

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Ingreso")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumCedula")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ParqueoId")
                        .HasColumnType("int");

                    b.Property<string>("PersonaContacto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmpleadoId");

                    b.HasIndex("ParqueoId");

                    b.ToTable("Empleado");
                });

            modelBuilder.Entity("API_Proyecto3.Models.Parqueo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("HoraApertura")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("HoraCierre")
                        .HasColumnType("datetime2");

                    b.Property<int>("MaxVehiculos")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalVendido")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Parqueo");
                });

            modelBuilder.Entity("API_Proyecto3.Models.Tiquete", b =>
                {
                    b.Property<int>("TiqueteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TiqueteId"), 1L, 1);

                    b.Property<bool>("EnUso")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Ingreso")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Monto_Pagado")
                        .HasColumnType("int");

                    b.Property<int>("ParqueoId")
                        .HasColumnType("int");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Salida")
                        .HasColumnType("datetime2");

                    b.Property<int>("TarifaHora")
                        .HasColumnType("int");

                    b.Property<int>("TarifaMediaHora")
                        .HasColumnType("int");

                    b.HasKey("TiqueteId");

                    b.HasIndex("ParqueoId");

                    b.ToTable("Tiquete");
                });

            modelBuilder.Entity("API_Proyecto3.Models.Empleado", b =>
                {
                    b.HasOne("API_Proyecto3.Models.Parqueo", "Parqueo")
                        .WithMany("Empleados")
                        .HasForeignKey("ParqueoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Parqueo");
                });

            modelBuilder.Entity("API_Proyecto3.Models.Tiquete", b =>
                {
                    b.HasOne("API_Proyecto3.Models.Parqueo", "Parqueo")
                        .WithMany("Tiquetes")
                        .HasForeignKey("ParqueoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Parqueo");
                });

            modelBuilder.Entity("API_Proyecto3.Models.Parqueo", b =>
                {
                    b.Navigation("Empleados");

                    b.Navigation("Tiquetes");
                });
#pragma warning restore 612, 618
        }
    }
}
