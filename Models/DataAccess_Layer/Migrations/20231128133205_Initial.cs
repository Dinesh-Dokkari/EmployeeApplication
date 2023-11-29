using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess_Layer.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Employee_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Experience = table.Column<double>(type: "float", nullable: false),
                    Annual_CTC = table.Column<double>(type: "float", nullable: false),
                    Basic_Amount = table.Column<double>(type: "float", nullable: false),
                    HRA_Amount = table.Column<double>(type: "float", nullable: false),
                    LTA_Amount = table.Column<double>(type: "float", nullable: false),
                    Gratuity = table.Column<double>(type: "float", nullable: false),
                    Income_Tax = table.Column<double>(type: "float", nullable: false),
                    Total_Deduction = table.Column<double>(type: "float", nullable: false),
                    NetPay = table.Column<double>(type: "float", nullable: false),
                    Monthly_CTC = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
