using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SunglassesApp.Migrations
{
    /// <inheritdoc />
    public partial class UseEnumsInProductsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80c32529-9d23-4d53-a0b3-89c710f5fd96",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bfe03a4d-5708-4176-99f9-67cf1941c863", "AQAAAAIAAYagAAAAEPjpc9p/BpxtOWtWpI93I5iP5kx31lRtuH0cTZXwNc6lYYvg2LV+qIY8D9qelYy+Jw==", "5b5d937b-da51-48b0-adcb-9db367f1f12b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e1976e68-c98a-46f6-9f1e-c0a87ef94609",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "48fc415e-529e-4d47-a336-93e515559aca", "AQAAAAIAAYagAAAAEKc/tHsc4Xq2R1dP5EFi4/joA67mOOddApieyIW9WsMzpsAaRuCPPj1ccoIblaSx0Q==", "5360cb1d-bc8e-499e-95fe-b0ee24093025" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
