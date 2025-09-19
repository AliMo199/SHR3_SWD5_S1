using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRPrac.Data.Presistence.Migrations
{
    /// <inheritdoc />
    public partial class EmpRange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_HealthBenefits_BenefitId",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "Rate",
                table: "Employees",
                newName: "HourlyRate");

            migrationBuilder.RenameColumn(
                name: "HourlyEmployee_Rate",
                table: "Employees",
                newName: "CommissionRate");

            migrationBuilder.AlterColumn<int>(
                name: "BenefitId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_HealthBenefits_BenefitId",
                table: "Employees",
                column: "BenefitId",
                principalTable: "HealthBenefits",
                principalColumn: "BenefitId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_HealthBenefits_BenefitId",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "HourlyRate",
                table: "Employees",
                newName: "Rate");

            migrationBuilder.RenameColumn(
                name: "CommissionRate",
                table: "Employees",
                newName: "HourlyEmployee_Rate");

            migrationBuilder.AlterColumn<int>(
                name: "BenefitId",
                table: "Employees",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_HealthBenefits_BenefitId",
                table: "Employees",
                column: "BenefitId",
                principalTable: "HealthBenefits",
                principalColumn: "BenefitId");
        }
    }
}
