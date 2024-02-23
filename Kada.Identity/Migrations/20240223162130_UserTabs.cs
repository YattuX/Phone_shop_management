using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kada.Identity.Migrations
{
    /// <inheritdoc />
    public partial class UserTabs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "Identifiant", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3bb71851-2380-418b-9303-ab355094957c", "Adm-Q69PHTGH", "AQAAAAIAAYagAAAAEGQdMNoo88VCjBY6UXdcE8xtyohcwlAckKZi6BP4XeS6fDtcGVj2ciAHbWP6+sYXwg==", "15283815-5628-49c1-b141-3bc53c6ad6b6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "Identifiant", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f2e8ac85-7f63-458e-9bf2-37c8c5b89787", "Tech-4MR8DHPJ", "AQAAAAIAAYagAAAAECz1ITNuYE+yITuA/x+RPBfrHS8D5gPCBUqzilbtqwkV90MV38XfXNcLT/A4w050mQ==", "bba27b73-a8c8-44b3-bdfc-8ed37263d285" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "Identifiant", "PasswordHash", "SecurityStamp" },
                values: new object[] { "504789d6-ddf2-4109-b9a8-8ee6cf24009a", "Adm-Z8WVPC0Y", "AQAAAAIAAYagAAAAED7VY8zi0waM5sZImrLcFOZcUEUMAYHy12qNm8UkJxMvuHPTxdlGzoJR5Jbl1sr/eQ==", "f9eafd68-e6c3-4e4d-99cf-0f2a0f01ff51" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "Identifiant", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7bf12fcd-8e77-4f11-a96d-0556ef837c96", "Tech-YIHTT8YU", "AQAAAAIAAYagAAAAEFOyOpH3nZsV+D/VfZed1VwjgldrDDy4okCD0mgbKuYTrdkNyYLxTikRp9/JGmaCsA==", "00a25c8a-0e7b-4ea2-bc1c-7ecfebfd318c" });
        }
    }
}
