using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyNotes.Migrations
{
    /// <inheritdoc />
    public partial class Oui : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_State",
                table: "State");

            migrationBuilder.RenameColumn(
                name: "Sname",
                table: "State",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "State",
                newName: "CountryId");

            migrationBuilder.RenameColumn(
                name: "Dname",
                table: "District",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "District",
                newName: "DistrictId");

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "State",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "StateId",
                table: "State",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "DistrictId",
                table: "KycForms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StateId",
                table: "KycForms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_State",
                table: "State",
                column: "StateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_State",
                table: "State");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "State");

            migrationBuilder.DropColumn(
                name: "DistrictId",
                table: "KycForms");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "KycForms");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "State",
                newName: "Sname");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                table: "State",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "District",
                newName: "Dname");

            migrationBuilder.RenameColumn(
                name: "DistrictId",
                table: "District",
                newName: "ID");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "State",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_State",
                table: "State",
                column: "ID");
        }
    }
}
