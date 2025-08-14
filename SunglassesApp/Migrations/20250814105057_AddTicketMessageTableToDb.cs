using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SunglassesApp.Migrations
{
    /// <inheritdoc />
    public partial class AddTicketMessageTableToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "SupportTickets");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80c32529-9d23-4d53-a0b3-89c710f5fd96",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f0caea48-13e7-495f-bc11-6a6852add89f", "AQAAAAIAAYagAAAAEMd0JCtR/4JK3Z5rKJy2xr3qW1HR0y6fxZmLE5ylxclvewCg9znNzDUTpkVZAiVTXg==", "b5887f6b-751b-48b2-8174-93b6388c4110" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e1976e68-c98a-46f6-9f1e-c0a87ef94609",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5f5e2fa0-4cb5-4300-b57e-7d314e536104", "AQAAAAIAAYagAAAAENyKBZwhJygw7FYnan2lWUDZC8/2vdewFzwg4owy+KgC41uaGFz5izI6qsbxXt7ckA==", "897e9c33-9d81-42b5-862a-9d20beb9bc81" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "SupportTickets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80c32529-9d23-4d53-a0b3-89c710f5fd96",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3be2ac06-09f4-45f8-a2fd-f4da67b231bd", "AQAAAAIAAYagAAAAEHN7MzHRQOc0mW5/fc9lZsy+mqoMUuujRQEFUr6aOq/p4ylv643Yk32K6TYhZKMpEQ==", "a1dc6801-af65-4ee0-8fd8-d4aa92f03da2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e1976e68-c98a-46f6-9f1e-c0a87ef94609",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c72e3c55-ea3d-4901-bbaa-a1b4d8613226", "AQAAAAIAAYagAAAAEKIldiVSLTeKXxEdNlfz0Cej9LpBjJ5dCR5dzadP5y4hEDUDyFFI8NX24RvlUZ49SA==", "5f484402-09a9-46a1-ae11-33c03c3abd59" });
        }
    }
}
