using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalManagementSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class Create_Database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "HMS");

            migrationBuilder.CreateTable(
                name: "DepartmentMaster",
                schema: "HMS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false),
                    DepartmentCode = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicineMaster",
                schema: "HMS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicineName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    MedicineForm = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PricePerUnit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PatientMaster",
                schema: "HMS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    MaritalStatus = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    FatherName = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    MotherName = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    SpouseName = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BloodGroup = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    EmergencyPhoneNumber = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true),
                    Gender = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    AdmissionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MedicalHistory = table.Column<bool>(type: "bit", nullable: false),
                    IsInsured = table.Column<bool>(type: "bit", nullable: false),
                    InsuranceCompany = table.Column<string>(type: "Varchar(150)", maxLength: 150, nullable: true),
                    InsuranceNumber = table.Column<string>(type: "Varchar(30)", maxLength: 30, nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isActive = table.Column<string>(type: "varchar(4)", maxLength: 4, nullable: false),
                    IsStaff = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DesignationMaster",
                schema: "HMS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    DesignationName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    DesignationCode = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DesignationMaster", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DesignationMaster_DepartmentMaster_DepartmentId",
                        column: x => x.DepartmentId,
                        principalSchema: "HMS",
                        principalTable: "DepartmentMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PatientMedicalHistoryMaster",
                schema: "HMS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    Disease = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    TreatmentBy = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false),
                    From = table.Column<DateTime>(type: "datetime2", nullable: false),
                    To = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientMedicalHistoryMaster", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientMedicalHistoryMaster_PatientMaster_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "HMS",
                        principalTable: "PatientMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "UserMaster",
                schema: "HMS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    IsDoctor = table.Column<bool>(type: "bit", nullable: false),
                    DesignationId = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsStaff = table.Column<string>(type: "varchar(4)", maxLength: 4, nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMaster", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserMaster_DesignationMaster_DesignationId",
                        column: x => x.DesignationId,
                        principalSchema: "HMS",
                        principalTable: "DesignationMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AddressMasters",
                schema: "HMS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostalCode = table.Column<string>(type: "varchar(6)", maxLength: 6, nullable: false),
                    City = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    State = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    Country = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    Address = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressMasters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AddressMasters_PatientMaster_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "HMS",
                        principalTable: "PatientMaster",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AddressMasters_UserMaster_UserId",
                        column: x => x.UserId,
                        principalSchema: "HMS",
                        principalTable: "UserMaster",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InPatientDepartmentMaster",
                schema: "HMS",
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
                        principalSchema: "HMS",
                        principalTable: "DepartmentMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_InPatientDepartmentMaster_PatientMaster_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "HMS",
                        principalTable: "PatientMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_InPatientDepartmentMaster_UserMaster_DoctorId",
                        column: x => x.DoctorId,
                        principalSchema: "HMS",
                        principalTable: "UserMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PatientAppointmentMaster",
                schema: "HMS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    AppointmentOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeSlotId = table.Column<int>(type: "int", nullable: false),
                    PatientType = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
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
                        principalSchema: "HMS",
                        principalTable: "DepartmentMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PatientAppointmentMaster_PatientMaster_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "HMS",
                        principalTable: "PatientMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PatientAppointmentMaster_UserMaster_DoctorId",
                        column: x => x.DoctorId,
                        principalSchema: "HMS",
                        principalTable: "UserMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PatientMedicinePrescriptionDetailMaster",
                schema: "HMS",
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
                        principalSchema: "HMS",
                        principalTable: "DepartmentMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PatientMedicinePrescriptionDetailMaster_MedicineMaster_MedicineId",
                        column: x => x.MedicineId,
                        principalSchema: "HMS",
                        principalTable: "MedicineMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PatientMedicinePrescriptionDetailMaster_PatientMaster_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "HMS",
                        principalTable: "PatientMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PatientMedicinePrescriptionDetailMaster_UserMaster_DoctorId",
                        column: x => x.DoctorId,
                        principalSchema: "HMS",
                        principalTable: "UserMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AddressMasters_PatientId",
                schema: "HMS",
                table: "AddressMasters",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_AddressMasters_UserId",
                schema: "HMS",
                table: "AddressMasters",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DesignationMaster_DepartmentId",
                schema: "HMS",
                table: "DesignationMaster",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_InPatientDepartmentMaster_DepartmentId",
                schema: "HMS",
                table: "InPatientDepartmentMaster",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_InPatientDepartmentMaster_DoctorId",
                schema: "HMS",
                table: "InPatientDepartmentMaster",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_InPatientDepartmentMaster_PatientId",
                schema: "HMS",
                table: "InPatientDepartmentMaster",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientAppointmentMaster_DepartmentId",
                schema: "HMS",
                table: "PatientAppointmentMaster",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientAppointmentMaster_DoctorId",
                schema: "HMS",
                table: "PatientAppointmentMaster",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientAppointmentMaster_PatientId",
                schema: "HMS",
                table: "PatientAppointmentMaster",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientMedicalHistoryMaster_PatientId",
                schema: "HMS",
                table: "PatientMedicalHistoryMaster",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientMedicinePrescriptionDetailMaster_DepartmentId",
                schema: "HMS",
                table: "PatientMedicinePrescriptionDetailMaster",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientMedicinePrescriptionDetailMaster_DoctorId",
                schema: "HMS",
                table: "PatientMedicinePrescriptionDetailMaster",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientMedicinePrescriptionDetailMaster_MedicineId",
                schema: "HMS",
                table: "PatientMedicinePrescriptionDetailMaster",
                column: "MedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientMedicinePrescriptionDetailMaster_PatientId",
                schema: "HMS",
                table: "PatientMedicinePrescriptionDetailMaster",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMaster_DesignationId",
                schema: "HMS",
                table: "UserMaster",
                column: "DesignationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddressMasters",
                schema: "HMS");

            migrationBuilder.DropTable(
                name: "InPatientDepartmentMaster",
                schema: "HMS");

            migrationBuilder.DropTable(
                name: "PatientAppointmentMaster",
                schema: "HMS");

            migrationBuilder.DropTable(
                name: "PatientMedicalHistoryMaster",
                schema: "HMS");

            migrationBuilder.DropTable(
                name: "PatientMedicinePrescriptionDetailMaster",
                schema: "HMS");

            migrationBuilder.DropTable(
                name: "MedicineMaster",
                schema: "HMS");

            migrationBuilder.DropTable(
                name: "PatientMaster",
                schema: "HMS");

            migrationBuilder.DropTable(
                name: "UserMaster",
                schema: "HMS");

            migrationBuilder.DropTable(
                name: "DesignationMaster",
                schema: "HMS");

            migrationBuilder.DropTable(
                name: "DepartmentMaster",
                schema: "HMS");
        }
    }
}
