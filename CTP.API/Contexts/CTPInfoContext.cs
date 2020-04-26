using CTP.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CTP.API.Contexts
{
    public class CTPInfoContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        
        public CTPInfoContext(DbContextOptions<CTPInfoContext> options) : base(options)
        {
            // Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // sembrar la base de datos con datos ficticios
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    Id = 1,
                    NombreUsuario = "ctigrero",
                    Nombre = "Carlos",
                    Apellido = "Tigrero",
                    Correo = "cdanitg@gmail.com",
                    Contrasena = "Carlos11",
                    NuevaContrasena = false
                },
                new Usuario
                {
                    Id = 2,
                    NombreUsuario = "dpereira",
                    Nombre = "Daniel",
                    Apellido = "Pereira",
                    Correo = "carlo-dani1@hotmail.com",
                    Contrasena = "Carlos11",
                    NuevaContrasena = false
                });

            modelBuilder.Entity<Cliente>().HasData(
                new Cliente
                {
                    Id = 1,
                    Nombre = "Andrea Olguin",
                    Correo = "molguin@pruebas.com",
                    Especialidad = "Doctora",
                    FechaCreacion = DateTimeOffset.Now,
                    Telefono = "2856789"
                },
                new Cliente
                {
                    Id = 2,
                    Nombre = "Estefania Herrera",
                    Correo = "eherrera@pruebas.com",
                    Especialidad = "Arquitecta",
                    FechaCreacion = DateTimeOffset.Now,
                    Telefono = "2774112"
                });

            base.OnModelCreating(modelBuilder);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("ConnectionString");
        //    base.OnConfiguring(optionsBuilder);
        //}
    }
}
