using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CW8.Migrations
{
    public partial class AddedSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "IdDoctor", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "example@ex.com", "Julian", "Bradford" },
                    { 2, "example@ex.com", "Magdalena", "Karpinska" }
                });

            migrationBuilder.InsertData(
                table: "Medicaments",
                columns: new[] { "IdMedicament", "Description", "Name", "Type" },
                values: new object[,]
                {
                    { 1, "Lek na uspokojenie", "Xanax", "tabletki" },
                    { 2, "Lek przeciwbolowy", "Tramadol", "tabletki" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "IdPatient", "BirthDate", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mati", "Kowalski" },
                    { 2, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jan", "Kowalski" }
                });

            migrationBuilder.InsertData(
                table: "Prescriptions",
                columns: new[] { "IdPrescription", "Date", "DueDate", "IdDoctor", "IdPatient" },
                values: new object[] { 1, new DateTime(2022, 6, 1, 0, 11, 16, 518, DateTimeKind.Local).AddTicks(4693), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 });

            migrationBuilder.InsertData(
                table: "Prescriptions",
                columns: new[] { "IdPrescription", "Date", "DueDate", "IdDoctor", "IdPatient" },
                values: new object[] { 2, new DateTime(2022, 6, 1, 0, 11, 16, 520, DateTimeKind.Local).AddTicks(8671), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1 });

            migrationBuilder.InsertData(
                table: "PrescriptionMedicament",
                columns: new[] { "IdMedicament", "IdPrescription", "Details", "Dose" },
                values: new object[] { 1, 1, "2x1 wieczorem", 2 });

            migrationBuilder.InsertData(
                table: "PrescriptionMedicament",
                columns: new[] { "IdMedicament", "IdPrescription", "Details", "Dose" },
                values: new object[] { 2, 2, "2x1 wieczorem", 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PrescriptionMedicament",
                keyColumns: new[] { "IdMedicament", "IdPrescription" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "PrescriptionMedicament",
                keyColumns: new[] { "IdMedicament", "IdPrescription" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Medicaments",
                keyColumn: "IdMedicament",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Medicaments",
                keyColumn: "IdMedicament",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "IdDoctor",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "IdDoctor",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 1);
        }
    }
}
