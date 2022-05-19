﻿using AstraRekrutacja.Data.Models;
using AstraRekrutacja.Services.Services.Interfaces;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AstraRekrutacja.Controllers
{
    public class VacationController : Controller
    {
        private IWorkerLeavesService workerLeavesService { get; }
        private IWorkerLeavesExcelService workerLeavesExcelService { get; }

        public VacationController(IWorkerLeavesService workerLeavesService, IWorkerLeavesExcelService workerLeavesExcelService)
        {
            this.workerLeavesService = workerLeavesService;
            this.workerLeavesExcelService = workerLeavesExcelService;
        }

        public async Task<ActionResult> Index(DateTime? start, DateTime? end)
        {
            var StartDate = start ?? DateTime.MinValue;
            var EndDate = end ?? DateTime.MaxValue;

            ViewBag.start = StartDate;
            ViewBag.end = EndDate;

            var workerLeaves = await workerLeavesService.GetWorkerVacation(StartDate, EndDate);

            var test = new WorkerVMTest
            {
                WorkerLeavesResultViewModels = workerLeaves
            };

            return View(test);
        }

        public async Task DownloadExcel(DateTime? start, DateTime? end)
        {
            var StartDate = start ?? DateTime.MinValue;
            var EndDate = end ?? DateTime.MaxValue;

            var workerLeavesExcel = await workerLeavesExcelService.GenerateWorkerVacationExcel(StartDate, EndDate);

            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment: filename=" + "Report.xlsx");
            Response.BinaryWrite(workerLeavesExcel.GetAsByteArray());
            Response.End();
        }
    }
}