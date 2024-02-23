using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kada.Identity.Migrations
{
    /// <inheritdoc />
    public partial class UpdateStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "Identifiant", "PasswordHash", "SecurityStamp" },
                values: new object[] { "50dd828f-c26c-4efc-8162-37d0b99cec9e", "Adm-UTKO1CJ7", "AQAAAAIAAYagAAAAEDhPgKfiJNOVwbuCwdcu4NJ9Yctdi6pBx/T5dOlFZz+rQJMOLubmFCnstu2LArQb6g==", "157a85c4-206f-4ccb-9ff1-45d6cb312b7e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "Identifiant", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b2e7301e-7f28-4626-b6d9-73826de097a6", "Tech-G4QJGEUB", "AQAAAAIAAYagAAAAEGLEJ4p+PPJkg7h4+r4mTVgCgewObY12r9E8e3iPuceIkQ6tpqBxHONyFjx7zEtrbw==", "48828812-c1fd-4ff5-b73b-4f3c4d1e515c" });
        }
    }
}
