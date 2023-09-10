using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace iBos_API_Task.Migrations
{
    public partial class seeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "EmployeeCode", "EmployeeName", "EmployeeSalary", "SupervisorId" },
                values: new object[,]
                {
                    { 502030, "EMP320", "Mehedi Hasan", 50000m, 502036 },
                    { 502031, "EMP321", "Ashikur Rahman", 45000m, 502036 },
                    { 502032, "EMP322", "Rakibul Islam", 52000m, 502030 },
                    { 502033, "EMP323", "Hasan Abdullah", 46000m, 502031 },
                    { 502034, "EMP324", "Akib Khan", 66000m, 502032 },
                    { 502035, "EMP325", "Rasel Shikder", 53500m, 502033 },
                    { 502036, "EMP326", "Selim Reja", 59000m, 502035 }
                });

            migrationBuilder.InsertData(
                table: "EmployeeAttendances",
                columns: new[] { "EmployeeAttendanceId", "AttendanceDate", "EmployeeId", "IsAbsent", "IsOffday", "IsPresent" },
                values: new object[] { 1, new DateTime(2023, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 502030, false, false, true });

            migrationBuilder.InsertData(
                table: "EmployeeAttendances",
                columns: new[] { "EmployeeAttendanceId", "AttendanceDate", "EmployeeId", "IsAbsent", "IsOffday", "IsPresent" },
                values: new object[] { 2, new DateTime(2023, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 502030, true, false, false });

            migrationBuilder.InsertData(
                table: "EmployeeAttendances",
                columns: new[] { "EmployeeAttendanceId", "AttendanceDate", "EmployeeId", "IsAbsent", "IsOffday", "IsPresent" },
                values: new object[] { 3, new DateTime(2023, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 502031, false, false, true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EmployeeAttendances",
                keyColumn: "EmployeeAttendanceId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EmployeeAttendances",
                keyColumn: "EmployeeAttendanceId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EmployeeAttendances",
                keyColumn: "EmployeeAttendanceId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 502032);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 502033);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 502034);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 502035);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 502036);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 502030);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 502031);
        }
    }
}
