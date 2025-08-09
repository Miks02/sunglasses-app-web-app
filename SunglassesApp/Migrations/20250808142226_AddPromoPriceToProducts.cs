using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SunglassesApp.Migrations
{
    /// <inheritdoc />
    public partial class AddPromoPriceToProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PromoPrice",
                table: "Products",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80c32529-9d23-4d53-a0b3-89c710f5fd96",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "35a8fcde-4a0a-4eee-96be-39d0f24fc50f", "AQAAAAIAAYagAAAAEBWW1e8KiakGqqOvpCMg3036IeQRMRLDKA75yoTI087J6YVWI9Vduqh34tIsv6mLDg==", "fb2d1f23-b54e-4bb1-94c5-13b99088730a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e1976e68-c98a-46f6-9f1e-c0a87ef94609",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "25d0653a-b615-407a-af2f-42147284ee01", "AQAAAAIAAYagAAAAEJZqaOwdGzvCEbQsn/xiU15LjEZfwcs/E2SWUKxAOzRjTFNF+NnxEpw1LodhlJRI4w==", "d889c27b-22ab-4e1a-bd29-c67e265a79a6" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PromoPrice",
                table: "Products");

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
    }
}
