using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SunglassesApp.Migrations
{
    /// <inheritdoc />
    public partial class AddTicketsToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsAnswered",
                table: "SupportTickets",
                newName: "isResolved");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isResolved",
                table: "SupportTickets",
                newName: "IsAnswered");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80c32529-9d23-4d53-a0b3-89c710f5fd96",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ddc2e4d6-1bf6-4be7-a1e8-c2d80c5b39ed", "AQAAAAIAAYagAAAAEHkxDQGwoCkDIDJJ9Zkuxawo1QzBEM2NjPcGlTkG1+vSsNAUuEh/01hLHA/QqzN+Uw==", "f1da35c7-c347-4713-929c-5a798d1823e6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e1976e68-c98a-46f6-9f1e-c0a87ef94609",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5c6134f1-aa18-46f9-8a1b-3ed18cbc9b56", "AQAAAAIAAYagAAAAEBHRFP+TOVd+dBsfvBZMEDQZ0O7fMPg96yQx1btY4M2mNqhS2Zkg61k6aqbRmFYamQ==", "21478e5b-7fd2-41ba-9dec-33d3d9109842" });
        }
    }
}
