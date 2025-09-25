using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exam.Infrastryctyre.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeTables_Teacher_TeacherId",
                table: "TimeTables");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teacher",
                table: "Teacher");

            migrationBuilder.RenameTable(
                name: "Teacher",
                newName: "Teachers");

            migrationBuilder.AlterColumn<string>(
                name: "Reason",
                table: "Attendances",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teachers",
                table: "Teachers",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeTables_Teachers_TeacherId",
                table: "TimeTables",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeTables_Teachers_TeacherId",
                table: "TimeTables");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teachers",
                table: "Teachers");

            migrationBuilder.RenameTable(
                name: "Teachers",
                newName: "Teacher");

            migrationBuilder.AlterColumn<string>(
                name: "Reason",
                table: "Attendances",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teacher",
                table: "Teacher",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeTables_Teacher_TeacherId",
                table: "TimeTables",
                column: "TeacherId",
                principalTable: "Teacher",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
