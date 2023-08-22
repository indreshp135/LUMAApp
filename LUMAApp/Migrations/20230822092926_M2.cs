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
            migrationBuilder.AlterColumn<string>(
                name: "loan_type",
                table: "loan_card_master",
                type: "varchar(20)",
                unicode: false,
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(15)",
                oldUnicode: false,
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_loan_card_master_loan_type",
                table: "loan_card_master",
                column: "loan_type");

            migrationBuilder.CreateIndex(
                name: "SET_UNIQUE_LOAN_TYPE",
                table: "loan_card_master",
                column: "loan_type",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_item_master_item_category",
                table: "item_master",
                column: "item_category");

            migrationBuilder.AddForeignKey(
                name: "FK_LOAN_TYPE_ITEM_CATEGORY",
                table: "item_master",
                column: "item_category",
                principalTable: "loan_card_master",
                principalColumn: "loan_type");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LOAN_TYPE_ITEM_CATEGORY",
                table: "item_master");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_loan_card_master_loan_type",
                table: "loan_card_master");

            migrationBuilder.DropIndex(
                name: "SET_UNIQUE_LOAN_TYPE",
                table: "loan_card_master");

            migrationBuilder.DropIndex(
                name: "IX_item_master_item_category",
                table: "item_master");

            migrationBuilder.AlterColumn<string>(
                name: "loan_type",
                table: "loan_card_master",
                type: "varchar(15)",
                unicode: false,
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldUnicode: false,
                oldMaxLength: 20);
        }
    }
}
