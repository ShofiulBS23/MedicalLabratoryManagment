using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalLabratoryManagment.Migrations
{
    /// <inheritdoc />
    public partial class AddNewResultAndStateFieldsInOrderDeatilsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Result",
                table: "OrderDetials",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "OrderDetials",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Result",
                table: "OrderDetials");

            migrationBuilder.DropColumn(
                name: "State",
                table: "OrderDetials");
        }
    }
}
