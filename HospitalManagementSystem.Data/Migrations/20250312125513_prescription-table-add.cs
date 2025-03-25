using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalManagementSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class prescriptiontableadd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PatientMedicinePrescriptionDetailMaster",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    MedicineId = table.Column<int>(type: "int", nullable: false),
                    DosageQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DosageUnit = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    Frequency = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    FrequencyUnit = table.Column<int>(type: "int", nullable: false),
                    Timing = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    duration = table.Column<int>(type: "int", nullable: false),
                    Instructions = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientMedicinePrescriptionDetailMaster", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientMedicinePrescriptionDetailMaster_DepartmentMaster_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "DepartmentMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PatientMedicinePrescriptionDetailMaster_MedicineMaster_MedicineId",
                        column: x => x.MedicineId,
                        principalTable: "MedicineMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PatientMedicinePrescriptionDetailMaster_PatientMaster_PatientId",
                        column: x => x.PatientId,
                        principalTable: "PatientMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PatientMedicinePrescriptionDetailMaster_UserMaster_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "UserMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PatientMedicinePrescriptionDetailMaster_DepartmentId",
                table: "PatientMedicinePrescriptionDetailMaster",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientMedicinePrescriptionDetailMaster_DoctorId",
                table: "PatientMedicinePrescriptionDetailMaster",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientMedicinePrescriptionDetailMaster_MedicineId",
                table: "PatientMedicinePrescriptionDetailMaster",
                column: "MedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientMedicinePrescriptionDetailMaster_PatientId",
                table: "PatientMedicinePrescriptionDetailMaster",
                column: "PatientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatientMedicinePrescriptionDetailMaster");
        }
    }
}
