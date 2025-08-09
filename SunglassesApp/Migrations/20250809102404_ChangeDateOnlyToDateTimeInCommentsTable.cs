using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SunglassesApp.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDateOnlyToDateTimeInCommentsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "AddedAt",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "AddedAt",
                table: "Comments",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80c32529-9d23-4d53-a0b3-89c710f5fd96",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6ce1d6c4-3307-494f-9047-991f6760ebed", "AQAAAAIAAYagAAAAEKXKL+Wfz2VDQYMg6pZFwR5pC8IkVdEPjG9xJCldf3oh2kxGZYoRgtAToCBECct3lQ==", "3d58e2cd-9532-4927-95f7-2640120b09a4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e1976e68-c98a-46f6-9f1e-c0a87ef94609",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "43dff86c-00eb-445a-8e0d-d4bbee55179c", "AQAAAAIAAYagAAAAEFtJZMmyoEaeRJHvg5YPZXIziAVrAOue+yUj/BXvvZMx1wUAedtd3rO+hnaBzDwPRQ==", "9f60eb58-3143-40c6-9ca9-870b739eeb86" });
        }
    }
}
