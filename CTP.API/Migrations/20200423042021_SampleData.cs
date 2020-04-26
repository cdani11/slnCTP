using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CTP.API.Migrations
{
    public partial class SampleData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "Correo", "Especialidad", "FechaCreacion", "Nombre", "Telefono" },
                values: new object[,]
                {
                    { 1, "molguin@pruebas.com", "Doctora", new DateTimeOffset(new DateTime(2020, 4, 22, 23, 20, 20, 351, DateTimeKind.Unspecified).AddTicks(521), new TimeSpan(0, -5, 0, 0, 0)), "Andrea Olguin", "2856789" },
                    { 2, "eherrera@pruebas.com", "Arquitecta", new DateTimeOffset(new DateTime(2020, 4, 22, 23, 20, 20, 356, DateTimeKind.Unspecified).AddTicks(4618), new TimeSpan(0, -5, 0, 0, 0)), "Estefania Herrera", "2774112" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Apellido", "Contrasena", "Correo", "Nombre", "NombreUsuario", "NuevaContrasena" },
                values: new object[,]
                {
                    { 1, "Tigrero", "Carlos11", "cdanitg@gmail.com", "Carlos", "ctigrero", false },
                    { 2, "Pereira", "Carlos11", "carlo-dani1@hotmail.com", "Daniel", "dpereira", false }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
