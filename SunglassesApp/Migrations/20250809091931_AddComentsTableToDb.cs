using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SunglassesApp.Migrations
{
    /// <inheritdoc />
    public partial class AddComentsTableToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddedAt = table.Column<DateOnly>(type: "date", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ProductId",
                table: "Comments",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

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
    }
}
