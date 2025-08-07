using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SunglassesApp.Migrations
{
    /// <inheritdoc />
    public partial class AddGenderColumnToProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Promotions",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "Promotions",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "DiscountPercentage",
                table: "Promotions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80c32529-9d23-4d53-a0b3-89c710f5fd96",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "80b90549-fca0-4aab-96cf-702b4c4640d3", "AQAAAAIAAYagAAAAEJJ1nO0XXqB5htSQhWJueAdRbTGKuR4F4dmCUB59T4wsTXSNHp0LOLBUL9rRzvaFkQ==", "debe4a2d-a747-40fa-b089-98e75f42ad69" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e1976e68-c98a-46f6-9f1e-c0a87ef94609",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3ea0e533-e81e-4d4e-a2d3-f62ed940f425", "AQAAAAIAAYagAAAAEOv1uQg8xGuo5ow4sJP+ItDvFJFInZskTpMUiy+yIc7Eh2gLl8w/Z62hSBLtdGdcoA==", "3e1cf3ac-749b-408e-8087-732b141b7ce9" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Products");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Promotions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "Promotions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DiscountPercentage",
                table: "Promotions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80c32529-9d23-4d53-a0b3-89c710f5fd96",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ac22b2ab-9023-482d-a4fe-1eb971ea4b4b", "AQAAAAIAAYagAAAAEKFdTYJ1/rs9d6XqFolHzBdPJFJrvLc0x8UQIjQ0cQC4FH8cdsJxd9tojsBzZLbuiA==", "c2d89bac-709b-4669-826b-c0a603b294fe" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e1976e68-c98a-46f6-9f1e-c0a87ef94609",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6f527be6-591c-4074-9e71-256b81a4cfee", "AQAAAAIAAYagAAAAEIEfi5fyzs10aakZlUPIv98e1YBhKiqn1yZM7+VVdDidXoTl+Soh0nhJqGe1y6rupg==", "89339180-04ba-418e-89b9-e8c35686f107" });
        }
    }
}
