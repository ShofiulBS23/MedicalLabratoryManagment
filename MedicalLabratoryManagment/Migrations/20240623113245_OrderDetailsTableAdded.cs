using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalLabratoryManagment.Migrations
{
    /// <inheritdoc />
    public partial class OrderDetailsTableAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderDetials",
                columns: table => new
                {
                    DetailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Minivalue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Maxvalue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BillNo = table.Column<int>(type: "int", nullable: false),
                    BillId = table.Column<int>(type: "int", nullable: true),
                    TestID = table.Column<int>(type: "int", nullable: true),
                    PatientID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetials", x => x.DetailID);
                    table.ForeignKey(
                        name: "FK_OrderDetials_Bills_BillId",
                        column: x => x.BillId,
                        principalTable: "Bills",
                        principalColumn: "BillNo");
                    table.ForeignKey(
                        name: "FK_OrderDetials_Patients_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patients",
                        principalColumn: "PatientID");
                    table.ForeignKey(
                        name: "FK_OrderDetials_Tests_TestID",
                        column: x => x.TestID,
                        principalTable: "Tests",
                        principalColumn: "TestID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetials_BillId",
                table: "OrderDetials",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetials_PatientID",
                table: "OrderDetials",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetials_TestID",
                table: "OrderDetials",
                column: "TestID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetials");
        }
    }
}
