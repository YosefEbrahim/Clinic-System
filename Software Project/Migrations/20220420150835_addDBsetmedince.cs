using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Software_Project.Migrations
{
    public partial class addDBsetmedince : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicine_Patients_PatientId",
                table: "Medicine");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Medicine",
                table: "Medicine");

            migrationBuilder.RenameTable(
                name: "Medicine",
                newName: "Medicines");

            migrationBuilder.RenameIndex(
                name: "IX_Medicine_PatientId",
                table: "Medicines",
                newName: "IX_Medicines_PatientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Medicines",
                table: "Medicines",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicines_Patients_PatientId",
                table: "Medicines",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicines_Patients_PatientId",
                table: "Medicines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Medicines",
                table: "Medicines");

            migrationBuilder.RenameTable(
                name: "Medicines",
                newName: "Medicine");

            migrationBuilder.RenameIndex(
                name: "IX_Medicines_PatientId",
                table: "Medicine",
                newName: "IX_Medicine_PatientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Medicine",
                table: "Medicine",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicine_Patients_PatientId",
                table: "Medicine",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id");
        }
    }
}
