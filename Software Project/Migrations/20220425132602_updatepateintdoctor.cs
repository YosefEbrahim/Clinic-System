using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Software_Project.Migrations
{
    public partial class updatepateintdoctor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DoctorS_Peteints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PetientId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorS_Peteints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorS_Peteints_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DoctorS_Peteints_Patients_PetientId",
                        column: x => x.PetientId,
                        principalTable: "Patients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoctorS_Peteints_DoctorId",
                table: "DoctorS_Peteints",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorS_Peteints_PetientId",
                table: "DoctorS_Peteints",
                column: "PetientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctorS_Peteints");
        }
    }
}
