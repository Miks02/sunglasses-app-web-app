using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SunglassesApp.Migrations
{
    /// <inheritdoc />
    public partial class AlterSupportTicketsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SupportTicketMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketId = table.Column<int>(type: "int", nullable: false),
                    SenderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsFromAdmin = table.Column<bool>(type: "bit", nullable: false),
                    SentAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportTicketMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupportTicketMessages_AspNetUsers_SenderId",
                        column: x => x.SenderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SupportTicketMessages_SupportTickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "SupportTickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_SupportTicketMessages_SenderId",
                table: "SupportTicketMessages",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_SupportTicketMessages_TicketId",
                table: "SupportTicketMessages",
                column: "TicketId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SupportTicketMessages");

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
    }
}
