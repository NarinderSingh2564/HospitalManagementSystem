using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalManagementSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class patienttableadd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
         
            migrationBuilder.CreateTable(
                name: "PatientAppointmentMaster",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    AppointmentOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeSlotId = table.Column<int>(type: "int", nullable: false),
                    PatientType = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    CRMNumber = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    ReasonForVisit = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    DoctorNotes = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    Status = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    RescheduledOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RescheduledTimeSlotId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientAppointmentMaster", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientAppointmentMaster_DepartmentMaster_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "DepartmentMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PatientAppointmentMaster_PatientMaster_PatientId",
                        column: x => x.PatientId,
                        principalTable: "PatientMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PatientAppointmentMaster_UserMaster_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "UserMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PatientAppointmentMaster_DepartmentId",
                table: "PatientAppointmentMaster",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientAppointmentMaster_DoctorId",
                table: "PatientAppointmentMaster",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientAppointmentMaster_PatientId",
                table: "PatientAppointmentMaster",
                column: "PatientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatientAppointmentMaster");

          
        }
    }
}
