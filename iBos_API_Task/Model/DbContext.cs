using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Threading.Channels;

namespace iBos_API_Task.Model
{
    public class iBosDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeAttendance> EmployeeAttendances { get; set; }

        public iBosDbContext(DbContextOptions<iBosDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.EmployeeAttendances)
                .WithOne(a => a.Employee)
                .HasForeignKey(a => a.EmployeeId);

            modelBuilder.Entity<Employee>()
                .Property(e => e.EmployeeSalary)
                .HasColumnType("decimal(18, 2)");


            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    EmployeeId = 502030,
                    EmployeeName = "Mehedi Hasan",
                    EmployeeCode = "EMP320",
                    EmployeeSalary = 50000,
                    SupervisorId = 502036
                },
                new Employee
                {
                    EmployeeId = 502031,
                    EmployeeName = "Ashikur Rahman",
                    EmployeeCode = "EMP321",
                    EmployeeSalary = 45000,
                    SupervisorId = 502036
                },
                new Employee
                {
                    EmployeeId = 502032,
                    EmployeeName = "Rakibul Islam",
                    EmployeeCode = "EMP322",
                    EmployeeSalary = 52000,
                    SupervisorId = 502030
                },
                new Employee
                {
                    EmployeeId = 502033,
                    EmployeeName = "Hasan Abdullah",
                    EmployeeCode = "EMP323",
                    EmployeeSalary = 46000,
                    SupervisorId = 502031
                },
                new Employee
                {
                    EmployeeId = 502034,
                    EmployeeName = "Akib Khan",
                    EmployeeCode = "EMP324",
                    EmployeeSalary = 66000,
                    SupervisorId = 502032
                },
                new Employee
                {
                    EmployeeId = 502035,
                    EmployeeName = "Rasel Shikder",
                    EmployeeCode = "EMP325",
                    EmployeeSalary = 53500,
                    SupervisorId = 502033
                },
                new Employee
                {
                    EmployeeId = 502036,
                    EmployeeName = "Selim Reja",
                    EmployeeCode = "EMP326",
                    EmployeeSalary = 59000,
                    SupervisorId = 502035
                }
    );

            // Seed data for tblEmployeeAttendance
            modelBuilder.Entity<EmployeeAttendance>().HasData(
                new EmployeeAttendance
                {
                    EmployeeAttendanceId = 1,
                    EmployeeId = 502030,
                    AttendanceDate = new DateTime(2023, 06, 24),
                    IsPresent = true,
                    IsAbsent = false,
                    IsOffday = false
                },
                new EmployeeAttendance
                {
                    EmployeeAttendanceId = 2,
                    EmployeeId = 502030,
                    AttendanceDate = new DateTime(2023, 06, 25),
                    IsPresent = false,
                    IsAbsent = true,
                    IsOffday = false
                },
                new EmployeeAttendance
                {
                    EmployeeAttendanceId = 3,
                    EmployeeId = 502031,
                    AttendanceDate = new DateTime(2023, 06, 25),
                    IsPresent = true,
                    IsAbsent = false,
                    IsOffday = false
                }
            // Add more attendance records here
            );




            base.OnModelCreating(modelBuilder);
        }

    }
}


//public class Employee
//{
//    [Key]
//    public int EmployeeId { get; set; }

//    [Required]
//    [StringLength(100)]
//    public string EmployeeName { get; set; } = default!;

//    [Required]
//    [StringLength(20)]
//    public string EmployeeCode { get; set; } = default!;

//    [Required]
//    public decimal EmployeeSalary { get; set; }

//    [Required]
//    public int? SupervisorId { get; set; }

//    [ForeignKey("SupervisorId")]
//    public Supervisor Supervisor { get; set; } // Reference to the Supervisor table

//    public ICollection<Employee> Subordinates { get; set; } = new List<Employee>();
//    public ICollection<EmployeeAttendance> Attendances { get; set; } = new List<EmployeeAttendance>();
//}



//public class EmployeeAttendance
//{
//    [Key]
//    public int AttendanceId { get; set; }

//    public int EmployeeId { get; set; }

//    [Required,Column(TypeName = "date"),
//     Display(Name = "Date"),
//     DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
//    public DateTime AttendanceDate { get; set; }

//    [Required]
//    public bool IsPresent { get; set; }

//    [Required]
//    public bool IsAbsent { get; set; }

//    [Required]
//    public bool IsOffday { get; set; }

//    [NotMapped]
//    [ForeignKey("EmployeeId")]
//    public virtual Employee Employee { get; set; } = default!;
//}

//public class Supervisor
//{
//    [Key]
//    public int SupervisorId { get; set; }
//}
