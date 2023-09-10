namespace iBos_API_Task.Model.ViewModel
{
    public class MonthlyAttendanceReport
    {
        public string EmployeeName { get; set; }
        public int MonthName { get; set; }
        public decimal PayableSalary { get; set; }
        public int TotalPresent { get; set; }
        public int TotalAbsent { get; set; }
        public int TotalOffday { get; set; }
    }

}
