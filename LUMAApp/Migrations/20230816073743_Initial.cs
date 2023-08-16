using System;
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
                name: "emp_master",
                columns: table => new
                {
                    emp_id = table.Column<string>(type: "varchar(6)", unicode: false, maxLength: 6, nullable: false),
                    emp_name = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    desgn = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
                    dept = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
                    gender = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    DOB = table.Column<DateTime>(type: "date", nullable: true),
                    DOJ = table.Column<DateTime>(type: "date", nullable: true),
                    passhash = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__emp_mast__1299A86157AF7BC0", x => x.emp_id);
                });

            migrationBuilder.CreateTable(
                name: "emp_card_details",
                columns: table => new
                {
                    loan_id = table.Column<string>(type: "varchar(6)", unicode: false, maxLength: 6, nullable: false),
                    emp_id = table.Column<string>(type: "varchar(6)", unicode: false, maxLength: 6, nullable: false),
                    card_issue_date = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__emp_card__A1F795549BFEAA1D", x => x.loan_id);
                    table.ForeignKey(
                        name: "fk1_emp_id",
                        column: x => x.emp_id,
                        principalTable: "emp_master",
                        principalColumn: "emp_id");
                });

            migrationBuilder.CreateTable(
                name: "emp_issue_details",
                columns: table => new
                {
                    issue_id = table.Column<string>(type: "varchar(6)", unicode: false, maxLength: 6, nullable: false),
                    emp_id = table.Column<string>(type: "varchar(6)", unicode: false, maxLength: 6, nullable: true),
                    item_id = table.Column<string>(type: "varchar(6)", unicode: false, maxLength: 6, nullable: false),
                    issue_date = table.Column<DateTime>(type: "date", nullable: true),
                    return_date = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__emp_issu__D6185C39B240E5BE", x => x.issue_id);
                    table.UniqueConstraint("AK_emp_issue_details_item_id", x => x.item_id);
                    table.ForeignKey(
                        name: "fk_emp_id",
                        column: x => x.emp_id,
                        principalTable: "emp_master",
                        principalColumn: "emp_id");
                });

            migrationBuilder.CreateTable(
                name: "loan_card_master",
                columns: table => new
                {
                    loan_id = table.Column<string>(type: "varchar(6)", unicode: false, maxLength: 6, nullable: false),
                    loan_type = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    duration_years = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__loan_car__A1F79554DD11A340", x => x.loan_id);
                    table.ForeignKey(
                        name: "fk_loan_id",
                        column: x => x.loan_id,
                        principalTable: "emp_card_details",
                        principalColumn: "loan_id");
                });

            migrationBuilder.CreateTable(
                name: "item_master",
                columns: table => new
                {
                    item_id = table.Column<string>(type: "varchar(6)", unicode: false, maxLength: 6, nullable: false),
                    item_descp = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
                    item_status = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    item_make = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
                    item_category = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    item_valuation = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__item_mas__52020FDD153DD1E2", x => x.item_id);
                    table.ForeignKey(
                        name: "fk_item_id",
                        column: x => x.item_id,
                        principalTable: "emp_issue_details",
                        principalColumn: "item_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_emp_card_details_emp_id",
                table: "emp_card_details",
                column: "emp_id");

            migrationBuilder.CreateIndex(
                name: "uloan_id",
                table: "emp_card_details",
                column: "loan_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_emp_issue_details_emp_id",
                table: "emp_issue_details",
                column: "emp_id");

            migrationBuilder.CreateIndex(
                name: "uitem_id",
                table: "emp_issue_details",
                column: "item_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "item_master");

            migrationBuilder.DropTable(
                name: "loan_card_master");

            migrationBuilder.DropTable(
                name: "emp_issue_details");

            migrationBuilder.DropTable(
                name: "emp_card_details");

            migrationBuilder.DropTable(
                name: "emp_master");
        }
    }
}
