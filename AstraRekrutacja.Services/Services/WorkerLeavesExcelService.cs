using AstraRekrutacja.Services.Services.Interfaces;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstraRekrutacja.Services.Services
{
    public class WorkerLeavesExcelService : IWorkerLeavesExcelService
    {
        public IWorkerLeavesService workerLeavesService { get; }

        public WorkerLeavesExcelService(IWorkerLeavesService workerLeavesService)
        {
            this.workerLeavesService = workerLeavesService;
        }

        public async Task<ExcelPackage> GenerateWorkerVacationExcel(DateTime leavesFrom, DateTime leavesTo)
        {
            var workerVacation = await workerLeavesService.GetWorkerVacation(leavesFrom, leavesTo);

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage Ep = new ExcelPackage();
            ExcelWorksheet Sheet = Ep.Workbook.Worksheets.Add("Worker Vacation");

            Sheet.Cells["A1"].Value = "Worker";
            Sheet.Cells["B1"].Value = "Manager";
            Sheet.Cells["C1"].Value = "Vacation Start Date";
            Sheet.Cells["D1"].Value = "Vacation End Date";
            Sheet.Cells["E1"].Value = "Vacation Type";
            Sheet.Cells["F1"].Value = "Vacation Status";
            Sheet.Cells["G1"].Value = "Length";
            Sheet.Cells["H1"].Value = "Range";

            int row = 2;
            foreach (var item in workerVacation)
            {

                Sheet.Cells[string.Format("A{0}", row)].Value = item.WorkerName;
                Sheet.Cells[string.Format("B{0}", row)].Value = item.ManagerName;
                Sheet.Cells[string.Format("C{0}", row)].Value = item.LeaveStartDate.ToString();
                Sheet.Cells[string.Format("D{0}", row)].Value = item.LeaveEndDate.ToString();
                Sheet.Cells[string.Format("E{0}", row)].Value = item.LeaveTypeName;
                Sheet.Cells[string.Format("F{0}", row)].Value = item.LeaveStatus;
                Sheet.Cells[string.Format("G{0}", row)].Value = item.LeaveDays;
                Sheet.Cells[string.Format("H{0}", row)].Value = item.Range;
                row++;
            }

            Sheet.Cells["A:AZ"].AutoFitColumns();

            return Ep;
        }
    }
}
