using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SunglassesApp.Migrations
{
    /// <inheritdoc />
    public partial class AlterProductsTable1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80c32529-9d23-4d53-a0b3-89c710f5fd96",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a7940214-0445-4882-8e6b-2fab74063995", "AQAAAAIAAYagAAAAEAcUhHjeaCchpF5Wy3o7QXvjmSsc6EnuXE07Kxi+tc5qQAM2Xx7wrrpya4rtUx5iGA==", "35aadae3-5e18-4323-901a-3cc82b90619a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e1976e68-c98a-46f6-9f1e-c0a87ef94609",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8fe6584b-5ce1-4c47-b9e5-6f447992b45a", "AQAAAAIAAYagAAAAEIrLCuQHU/+tx+gpgi3LoETirv1g50FIbOexerK9MVU1nW+nTo66683PqsggH3r2Kw==", "c77b3b69-2bae-4071-aed6-607316fe9007" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
