using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BIO.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Analysis",
                columns: table => new
                {
                    AnalysisID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnalysisType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnalysisDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MethodUsed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnalysisResults = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Analysis", x => x.AnalysisID);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TestPerformers",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specialization = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestPerformers", x => x.EmployeeID);
                });

            migrationBuilder.CreateTable(
                name: "GeneticMutations",
                columns: table => new
                {
                    GeneticVariantID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genotype = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GenomeLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PredictedEffect = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnalysisId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneticMutations", x => x.GeneticVariantID);
                    table.ForeignKey(
                        name: "FK_GeneticMutations_Analysis_AnalysisId",
                        column: x => x.AnalysisId,
                        principalTable: "Analysis",
                        principalColumn: "AnalysisID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GeneticTests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Result = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneticTests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GeneticTests_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneticTests_TestPerformers_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "TestPerformers",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GeneticMutations_AnalysisId",
                table: "GeneticMutations",
                column: "AnalysisId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneticTests_EmployeeID",
                table: "GeneticTests",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_GeneticTests_PatientId",
                table: "GeneticTests",
                column: "PatientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GeneticMutations");

            migrationBuilder.DropTable(
                name: "GeneticTests");

            migrationBuilder.DropTable(
                name: "Analysis");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "TestPerformers");
        }
    }
}
