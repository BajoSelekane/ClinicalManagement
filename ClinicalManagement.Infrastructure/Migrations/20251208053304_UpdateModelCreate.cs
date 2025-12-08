using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicalManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModelCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Poctors_DoctorId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Timeslots_Poctors_DoctorId",
                table: "Timeslots");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Poctors",
                table: "Poctors");

            migrationBuilder.RenameTable(
                name: "Poctors",
                newName: "Doctors");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Doctors",
                table: "Doctors",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Doctors_DoctorId",
                table: "Appointments",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Timeslots_Doctors_DoctorId",
                table: "Timeslots",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Doctors_DoctorId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Timeslots_Doctors_DoctorId",
                table: "Timeslots");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Doctors",
                table: "Doctors");

            migrationBuilder.RenameTable(
                name: "Doctors",
                newName: "Poctors");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Poctors",
                table: "Poctors",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Poctors_DoctorId",
                table: "Appointments",
                column: "DoctorId",
                principalTable: "Poctors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Timeslots_Poctors_DoctorId",
                table: "Timeslots",
                column: "DoctorId",
                principalTable: "Poctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
