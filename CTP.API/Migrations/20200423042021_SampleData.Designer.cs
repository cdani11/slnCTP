﻿// <auto-generated />
using System;
using CTP.API.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CTP.API.Migrations
{
    [DbContext(typeof(CTPInfoContext))]
    [Migration("20200423042021_SampleData")]
    partial class SampleData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CTP.API.Entities.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Especialidad")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<DateTimeOffset>("FechaCreacion")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.ToTable("Clientes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Correo = "molguin@pruebas.com",
                            Especialidad = "Doctora",
                            FechaCreacion = new DateTimeOffset(new DateTime(2020, 4, 22, 23, 20, 20, 351, DateTimeKind.Unspecified).AddTicks(521), new TimeSpan(0, -5, 0, 0, 0)),
                            Nombre = "Andrea Olguin",
                            Telefono = "2856789"
                        },
                        new
                        {
                            Id = 2,
                            Correo = "eherrera@pruebas.com",
                            Especialidad = "Arquitecta",
                            FechaCreacion = new DateTimeOffset(new DateTime(2020, 4, 22, 23, 20, 20, 356, DateTimeKind.Unspecified).AddTicks(4618), new TimeSpan(0, -5, 0, 0, 0)),
                            Nombre = "Estefania Herrera",
                            Telefono = "2774112"
                        });
                });

            modelBuilder.Entity("CTP.API.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<string>("Contrasena")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<bool>("NuevaContrasena")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Apellido = "Tigrero",
                            Contrasena = "Carlos11",
                            Correo = "cdanitg@gmail.com",
                            Nombre = "Carlos",
                            NombreUsuario = "ctigrero",
                            NuevaContrasena = false
                        },
                        new
                        {
                            Id = 2,
                            Apellido = "Pereira",
                            Contrasena = "Carlos11",
                            Correo = "carlo-dani1@hotmail.com",
                            Nombre = "Daniel",
                            NombreUsuario = "dpereira",
                            NuevaContrasena = false
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
