using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalManagementSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class inpatientdepartmentmastertableadd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PatientType",
                table: "PatientAppointmentMaster",
                type: "varchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldMaxLength: 20);

            migrationBuilder.CreateTable(
                name: "InPatientDepartmentMaster",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    WardNumber = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    BedNumber = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    Status = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    AdmittedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsSurgery = table.Column<bool>(type: "bit", nullable: true),
                    SurgeryName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    SurgeryOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SurgeryStatus = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    IsDischarged = table.Column<bool>(type: "bit", nullable: true),
                    DischargerOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InPatientDepartmentMaster", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InPatientDepartmentMaster_DepartmentMaster_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "DepartmentMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_InPatientDepartmentMaster_PatientMaster_PatientId",
                        column: x => x.PatientId,
                        principalTable: "PatientMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_InPatientDepartmentMaster_UserMaster_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "UserMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InPatientDepartmentMaster_DepartmentId",
                table: "InPatientDepartmentMaster",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_InPatientDepartmentMaster_DoctorId",
                table: "InPatientDepartmentMaster",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_InPatientDepartmentMaster_PatientId",
                table: "InPatientDepartmentMaster",
                column: "PatientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InPatientDepartmentMaster");

            migrationBuilder.AlterColumn<string>(
                name: "PatientType",
                table: "PatientAppointmentMaster",
                type: "varchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldMaxLength: 20,
                oldNullable: true);
        }
    }
}
