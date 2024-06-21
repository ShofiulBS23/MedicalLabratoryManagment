using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalLabratoryManagment.Migrations
{
    /// <inheritdoc />
    public partial class TestTableImpleemnted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    TestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TestType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SampleType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SampleUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinimumValue = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    MaximumValue = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.TestID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tests");
        }
    }
}
