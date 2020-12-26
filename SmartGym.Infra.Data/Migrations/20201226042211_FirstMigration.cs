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
                    CompanyName = table.Column<string>(type: "varchar(100)", nullable: false)
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
                    TrainingCenterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalTrainer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonalTrainer_TrainingCenter_TrainingCenterId",
                        column: x => x.TrainingCenterId,
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
                    TrainingCenterId = table.Column<int>(type: "int", nullable: false),
                    PersonalTrainerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Student_PersonalTrainer_PersonalTrainerId",
                        column: x => x.PersonalTrainerId,
                        principalTable: "PersonalTrainer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Student_TrainingCenter_TrainingCenterId",
                        column: x => x.TrainingCenterId,
                        principalTable: "TrainingCenter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonalTrainer_TrainingCenterId",
                table: "PersonalTrainer",
                column: "TrainingCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_PersonalTrainerId",
                table: "Student",
                column: "PersonalTrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_TrainingCenterId",
                table: "Student",
                column: "TrainingCenterId");
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
