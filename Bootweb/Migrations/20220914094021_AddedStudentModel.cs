using Microsoft.EntityFrameworkCore.Migrations;

namespace Bootweb.Migrations
{
    public partial class AddedStudentModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DptID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DptName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DptID);
                });

            migrationBuilder.CreateTable(
                name: "Registers",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentName = table.Column<string>(nullable: false),
                    StudentEmail = table.Column<string>(nullable: false),
                    DptID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registers", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_Registers_Departments_DptID",
                        column: x => x.DptID,
                        principalTable: "Departments",
                        principalColumn: "DptID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Registers_DptID",
                table: "Registers",
                column: "DptID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Registers");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
