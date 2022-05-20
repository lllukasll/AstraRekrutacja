using System;

namespace AstraRekrutacja.Data.Models
{
    public class WorkerLeavesResult
    {
        public string WorkerName { get; set; }
        public string ManagerName { get; set; }
        public DateTime LeaveStartDate { get; set; }
        public string LeaveTypeName { get; set; }
        public string LeaveStatus { get; set; }
        public int LeaveDays { get; set; }
    }
}
