using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SunglassesApp.Migrations
{
    /// <inheritdoc />
    public partial class Initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80c32529-9d23-4d53-a0b3-89c710f5fd96",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5f347ef5-056a-4e50-96d6-8780bec606ab", "AQAAAAIAAYagAAAAEDytTf/zN8+3LQJEIXK4siDjJxPeJk337FumnuHz4GXu5Hbu4fCg/67ERY/LAjmDew==", "a0fe6767-6f12-4f8d-b170-aa992e88b148" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e1976e68-c98a-46f6-9f1e-c0a87ef94609",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1082e58e-f3e2-4e98-9b40-425b4333981c", "AQAAAAIAAYagAAAAELOG0TAQPrBzzbms2Hp7j2gcTrt1wcm65d+pLbcas+rrP0j8/4oQf0yW4rom81vvTw==", "a2d1cc42-4fc1-4228-9655-f817311c3730" });
        }
    }
}
