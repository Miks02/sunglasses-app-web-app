using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SunglassesApp.Migrations
{
    /// <inheritdoc />
    public partial class ChangeScoreToFloatInRatings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "DateRated",
                table: "Ratings");

            migrationBuilder.AlterColumn<float>(
                name: "Score",
                table: "Ratings",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80c32529-9d23-4d53-a0b3-89c710f5fd96",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b0349335-a505-4bdf-97b5-8de3ccfd5d3f", "AQAAAAIAAYagAAAAEFEkgm1dq4Hr/2V+rfNifpfWeeIjI3Uk1CcJKtPAWoIanMLoVDnGAdASHQCNTVPJjQ==", "ce9555db-26d0-4d47-adb9-03011141449b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e1976e68-c98a-46f6-9f1e-c0a87ef94609",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "091c65b9-ca15-4e4b-9280-15f61bd4a670", "AQAAAAIAAYagAAAAEJPUmuxB8IKIdHJps+QTG2fIVWiX2BArlGdZRMErRoXnbXO9IySG/e04V+bWoFPM3Q==", "09bb7ffd-5435-4cc2-ba52-d367e4ec7ca0" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Score",
                table: "Ratings",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "Ratings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateRated",
                table: "Ratings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80c32529-9d23-4d53-a0b3-89c710f5fd96",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dba07e3c-e11f-471e-8f16-2973cab27fd4", "AQAAAAIAAYagAAAAENEaqkysKzDFaUmgLxNZ748XukVfa1fUJWFbJTZ6bBOkyGC7/tZGQjMneHmDZq0i/g==", "2356d03b-527a-47cb-8110-2702dfe4f9d6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e1976e68-c98a-46f6-9f1e-c0a87ef94609",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b779a0ee-3723-4707-81c1-622823fa1557", "AQAAAAIAAYagAAAAEJ5p3qqRBcKlX7lEcJf//fr1BzZz8Hg8eDmaIVEQAg29nXjMA7PiRN/VsUoTD+lOPQ==", "26f841e0-3241-4b90-8d03-1f3a86077efa" });
        }
    }
}
