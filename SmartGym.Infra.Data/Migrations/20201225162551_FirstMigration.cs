using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartGym.Infra.Data.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TrainingCenter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingCenter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonalTrainer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    IdTrainingCenter = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalTrainer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonalTrainer_TrainingCenter_IdTrainingCenter",
                        column: x => x.IdTrainingCenter,
                        principalTable: "TrainingCenter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    IdTrainingCenter = table.Column<int>(type: "int", nullable: false),
                    IdPersonalTrainer = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Student_PersonalTrainer_IdPersonalTrainer",
                        column: x => x.IdPersonalTrainer,
                        principalTable: "PersonalTrainer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Student_TrainingCenter_IdTrainingCenter",
                        column: x => x.IdTrainingCenter,
                        principalTable: "TrainingCenter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonalTrainer_IdTrainingCenter",
                table: "PersonalTrainer",
                column: "IdTrainingCenter");

            migrationBuilder.CreateIndex(
                name: "IX_Student_IdPersonalTrainer",
                table: "Student",
                column: "IdPersonalTrainer");

            migrationBuilder.CreateIndex(
                name: "IX_Student_IdTrainingCenter",
                table: "Student",
                column: "IdTrainingCenter");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "PersonalTrainer");

            migrationBuilder.DropTable(
                name: "TrainingCenter");
        }
    }
}
