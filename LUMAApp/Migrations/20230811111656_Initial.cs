using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LUMAApp.Migrations
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
                    EMail = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    EmployeeName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    PasswordHashed = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EMail);
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
