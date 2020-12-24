using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartGym.Infra.Data.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "varchar(100)", nullable: false),
                    Number = table.Column<string>(type: "varchar(2)", nullable: false),
                    Neighborhood = table.Column<string>(type: "varchar(30)", nullable: false),
                    City = table.Column<string>(type: "varchar(30)", nullable: false),
                    State = table.Column<string>(type: "varchar(30)", nullable: false),
                    Country = table.Column<string>(type: "varchar(30)", nullable: false),
                    ZipCode = table.Column<string>(type: "varchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrainingCenter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingCenter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingCenter_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersonalTrainer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    IdTrainingCenter = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalTrainer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonalTrainer_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    IdTrainingCenter = table.Column<int>(type: "int", nullable: false),
                    IdPersonalTrainer = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Student_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "IX_PersonalTrainer_AddressId",
                table: "PersonalTrainer",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalTrainer_IdTrainingCenter",
                table: "PersonalTrainer",
                column: "IdTrainingCenter");

            migrationBuilder.CreateIndex(
                name: "IX_Student_AddressId",
                table: "Student",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_IdPersonalTrainer",
                table: "Student",
                column: "IdPersonalTrainer");

            migrationBuilder.CreateIndex(
                name: "IX_Student_IdTrainingCenter",
                table: "Student",
                column: "IdTrainingCenter");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingCenter_AddressId",
                table: "TrainingCenter",
                column: "AddressId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "PersonalTrainer");

            migrationBuilder.DropTable(
                name: "TrainingCenter");

            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
