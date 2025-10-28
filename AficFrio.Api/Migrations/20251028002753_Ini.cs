using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AficFrio.Api.Migrations
{
    /// <inheritdoc />
    public partial class Ini : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    QRCodeMobile = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Senha = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Role = table.Column<int>(type: "int", nullable: false),
                    CadastradoEm = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Empresa",
                columns: new[] { "Id", "Nome", "QRCodeMobile" },
                values: new object[] { 1, "Dev's Burguer", "Pendente" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "CadastradoEm", "Email", "EmpresaId", "Role", "Senha", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 10, 21, 21, 27, 52, 657, DateTimeKind.Local).AddTicks(8311), "admin@admin.com", 1, 1, "gfse3McKBuFWBrNpAwRVDg==", "User" },
                    { 2, new DateTime(2025, 10, 21, 21, 27, 52, 657, DateTimeKind.Local).AddTicks(8459), "admin@admin.com", 1, 2, "gfse3McKBuFWBrNpAwRVDg==", "Admin" },
                    { 3, new DateTime(2025, 10, 21, 21, 27, 52, 657, DateTimeKind.Local).AddTicks(8461), "admin@admin.com", 1, 3, "gfse3McKBuFWBrNpAwRVDg==", "RafaDev" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_EmpresaId",
                table: "Usuarios",
                column: "EmpresaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Empresa");
        }
    }
}
