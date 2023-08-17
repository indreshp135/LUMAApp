using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LUMAApp.Migrations
{
    /// <inheritdoc />
    public partial class M2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_item_id",
                table: "item_master");

            migrationBuilder.DropForeignKey(
                name: "fk_loan_id",
                table: "loan_card_master");

            migrationBuilder.DropTable(
                name: "emp_card_details");

            migrationBuilder.DropTable(
                name: "emp_issue_details");

            migrationBuilder.DropColumn(
                name: "passhash",
                table: "emp_master");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "passhash",
                table: "emp_master",
                type: "varchar(1)",
                unicode: false,
                maxLength: 1,
                nullable: true);

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
                    issue_date = table.Column<DateTime>(type: "date", nullable: true),
                    item_id = table.Column<string>(type: "varchar(6)", unicode: false, maxLength: 6, nullable: false),
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

            migrationBuilder.AddForeignKey(
                name: "fk_item_id",
                table: "item_master",
                column: "item_id",
                principalTable: "emp_issue_details",
                principalColumn: "item_id");

            migrationBuilder.AddForeignKey(
                name: "fk_loan_id",
                table: "loan_card_master",
                column: "loan_id",
                principalTable: "emp_card_details",
                principalColumn: "loan_id");
        }
    }
}
