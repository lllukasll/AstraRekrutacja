using OfficeOpenXml;
using System;
using System.Threading.Tasks;

namespace AstraRekrutacja.Services.Services.Interfaces
{
    public interface IWorkerLeavesExcelService
    {
        Task<ExcelPackage> GenerateWorkerVacationExcel(DateTime leavesFrom, DateTime leavesTo);
    }
}
