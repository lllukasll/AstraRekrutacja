namespace AstraRekrutacja.Data.Models
{
    public class WorkerLeavesResultViewModel
    {
        public string WorkerName { get; set; }
        public string ManagerName { get; set; }
        public string LeaveStartDate { get; set; }
        public string LeaveEndDate { get; set; }
        public string LeaveTypeName { get; set; }
        public string LeaveStatus { get; set; }
        public int LeaveDays { get; set; }
        public string Range { get; set; }
    }
}
