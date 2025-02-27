using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalManagementSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class Added_IsStaff_Column_to_UserMaster_PatientMaster : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<string>(
                name: "IsStaff",
                table: "UserMaster",
                type: "varchar(5)",
                nullable: false,
                maxLength: 5);

            migrationBuilder.AddColumn<string>(
                name: "IsStaff",
                table: "PatientMaster",
                type: "varchar(5)",
                nullable: true,
                maxLength: 5);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsStaff",
                table: "UserMaster");

            migrationBuilder.DropColumn(
                name: "IsStaff",
                table: "PatientMaster");

        }
    }
}
