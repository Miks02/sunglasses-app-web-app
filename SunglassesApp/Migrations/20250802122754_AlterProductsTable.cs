using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SunglassesApp.Migrations
{
    /// <inheritdoc />
    public partial class AlterProductsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Products",
                newName: "Model");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80c32529-9d23-4d53-a0b3-89c710f5fd96",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5d35964f-5553-4552-a420-1f4273956d14", "AQAAAAIAAYagAAAAEMmkCIRbUwGT38h6UkFNXbRLKajJ4wgac9mAmphpXYmfzkNgc38XFYEa5mqzQBMn3A==", "ae7dd9c6-5a87-42e0-88f4-453e8d021b06" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e1976e68-c98a-46f6-9f1e-c0a87ef94609",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a47d02cc-75d2-4b06-ab9a-e1d5d5cf1711", "AQAAAAIAAYagAAAAECzACloZsCc67YS/fgexlLVYwMOLC505z8//aSPTxeE1UfDzR7SVfAjmQAWYW1Xz6Q==", "6f8f1f00-f710-4cf4-948e-ac1a1aef65b1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Model",
                table: "Products",
                newName: "Name");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80c32529-9d23-4d53-a0b3-89c710f5fd96",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4ee1516c-ca53-4283-a142-925897c8a9aa", "AQAAAAIAAYagAAAAEG5c9dp5gItZQWOus9H391iYiaidGW9asuzPBRBk7EBBIxg/0dsc4dgQcWe5s1MgfQ==", "54997949-b43e-4027-b404-d14a5ae27de9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e1976e68-c98a-46f6-9f1e-c0a87ef94609",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c3bb9d18-8428-4cae-a912-46a2007ebcdb", "AQAAAAIAAYagAAAAENefeHweACF1JNtu05RTae6ldeU+GBZT8dFRPGFxfrw2fxV2+vk5PG0Hxj4JdZSmvQ==", "5f9b4fc7-3325-4a67-9f79-2cc3be224c8b" });
        }
    }
}
