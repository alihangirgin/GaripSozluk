using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace GaripSozluk.Data.Migrations.LogDb
{
    public partial class asd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    TraceIdentifier = table.Column<string>(maxLength: 100, nullable: true),
                    ResponseStatusCode = table.Column<string>(maxLength: 100, nullable: true),
                    RequestMethod = table.Column<string>(maxLength: 100, nullable: true),
                    RequestPath = table.Column<string>(maxLength: 100, nullable: true),
                    UserAgent = table.Column<string>(maxLength: 200, nullable: true),
                    RoutePath = table.Column<string>(maxLength: 100, nullable: true),
                    IPAddress = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logs");
        }
    }
}
