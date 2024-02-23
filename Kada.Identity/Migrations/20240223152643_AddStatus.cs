using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kada.Identity.Migrations
{
    /// <inheritdoc />
    public partial class AddStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "Identifiant", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3dc803e1-2021-4cad-94b6-b409d2262db3", "Adm-AGALSQYL", "AQAAAAIAAYagAAAAEM+vcjix90zy4QNupiSWgd8qWeEN8BtF5j1bsa7+iRaUAIzMoBMOLUUyWXzKZsPQWw==", "eaaaffa7-9611-4515-bd1f-f3fd800195f8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "Identifiant", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2aa66d6d-ece5-4c90-9ced-a5a37c611764", "Tech-KL3TF5NE", "AQAAAAIAAYagAAAAEGMyB3Gy6ZuAKHZ0XZP9ggEkNMGdjhQ5TiBu3CnFs6A+khaJgkzn5e94ITDVK35ENw==", "9a6e7420-4b4c-4f1a-b8e7-75cfd30024b5" });
        }
    }
}
