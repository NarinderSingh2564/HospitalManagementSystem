using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalManagementSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class PatientMasterTables_Added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddressMasters_UserMaster_UserId",
                table: "AddressMasters");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "UserMaster",
                type: "varchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "UserMaster",
                type: "varchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "UserMaster",
                type: "varchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "UserMaster",
                type: "varchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "UserMaster",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "AddressMasters",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "AddressMasters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "AddressMasters",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsStaff",
                table: "AddressMasters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "AddressMasters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "AddressMasters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "AddressMasters",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "AddressMasters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "PatientMaster",
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
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PatientMedicalHistoryMaster",
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
                        principalTable: "PatientMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AddressMasters_PatientId",
                table: "AddressMasters",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientMedicalHistoryMaster_PatientId",
                table: "PatientMedicalHistoryMaster",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_AddressMasters_PatientMaster_PatientId",
                table: "AddressMasters",
                column: "PatientId",
                principalTable: "PatientMaster",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AddressMasters_UserMaster_UserId",
                table: "AddressMasters",
                column: "UserId",
                principalTable: "UserMaster",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddressMasters_PatientMaster_PatientId",
                table: "AddressMasters");

            migrationBuilder.DropForeignKey(
                name: "FK_AddressMasters_UserMaster_UserId",
                table: "AddressMasters");

            migrationBuilder.DropTable(
                name: "PatientMedicalHistoryMaster");

            migrationBuilder.DropTable(
                name: "PatientMaster");

            migrationBuilder.DropIndex(
                name: "IX_AddressMasters_PatientId",
                table: "AddressMasters");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "AddressMasters");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "AddressMasters");

            migrationBuilder.DropColumn(
                name: "IsStaff",
                table: "AddressMasters");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "AddressMasters");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "AddressMasters");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "AddressMasters");

            migrationBuilder.DropColumn(
                name: "isActive",
                table: "AddressMasters");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "UserMaster",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "UserMaster",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "UserMaster",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "UserMaster",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "UserMaster",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "AddressMasters",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AddressMasters_UserMaster_UserId",
                table: "AddressMasters",
                column: "UserId",
                principalTable: "UserMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
