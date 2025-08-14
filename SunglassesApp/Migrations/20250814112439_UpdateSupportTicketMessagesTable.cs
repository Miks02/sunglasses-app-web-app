using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SunglassesApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSupportTicketMessagesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80c32529-9d23-4d53-a0b3-89c710f5fd96",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a73695db-598d-444d-8178-3ae8f4c1ec58", "AQAAAAIAAYagAAAAEGwJXrCC8pB94xAaSHFLVIoSqqKTEEOFy3f+V3XqaxJMuzGb0NoRKcmP+7xpielifQ==", "78271570-d9a9-4486-906e-ffc61fee67d5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e1976e68-c98a-46f6-9f1e-c0a87ef94609",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6a733402-dd68-4069-a8c6-cb35910232ae", "AQAAAAIAAYagAAAAEEZlRXqv7xgbsSwlae6UclDrejOZ+BI/f7lcl1bZu3xnVz70tryrAIUWUYOZK92/9Q==", "c7990905-d7e7-47b6-bdc0-23fd6b9ee7e0" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80c32529-9d23-4d53-a0b3-89c710f5fd96",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2b7f9ad6-8118-47d5-a952-d2c42e8c673e", "AQAAAAIAAYagAAAAEKoTYIz7VXkOQwJtCRAoREqUiZLyH3PjCm0RlwKzGojyAYb48YIGDP4XrK20WfxlaQ==", "905b85da-3b19-49a4-8caf-42b103346080" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e1976e68-c98a-46f6-9f1e-c0a87ef94609",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "49d2aa98-46e1-45a9-bc94-8cccfffc986d", "AQAAAAIAAYagAAAAEEwOGLYi+4heaXUkJzjcXnnOC8x1ACMfW83qs98Q/65nfZ3WpkjMlqgyiTb41Ni6vw==", "3b63fa0d-8d83-4de4-9fc8-9bb8f1f53330" });
        }
    }
}
