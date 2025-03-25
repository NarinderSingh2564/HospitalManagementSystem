using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalManagementSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class Added_Validation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "isActive",
                table: "PatientMaster",
                type: "varchar(4)",
                maxLength: 4,
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "IsStaff",
                table: "PatientMaster",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(4)",
                oldMaxLength: 4);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "isActive",
                table: "PatientMaster",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(4)",
                oldMaxLength: 4);

            migrationBuilder.AlterColumn<string>(
                name: "IsStaff",
                table: "PatientMaster",
                type: "varchar(4)",
                maxLength: 4,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
