using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstraRekrutacja.Services.Services.Interfaces
{
    public interface IWorkerLeavesExcelService
    {
        Task<ExcelPackage> GenerateWorkerVacationExcel(DateTime leavesFrom, DateTime leavesTo);
    }
}
