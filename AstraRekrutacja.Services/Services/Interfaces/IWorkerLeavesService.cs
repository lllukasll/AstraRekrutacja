using AstraRekrutacja.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AstraRekrutacja.Services.Services.Interfaces
{
    public interface IWorkerLeavesService
    {
        Task<IEnumerable<WorkerLeavesResultViewModel>> GetWorkerVacation(DateTime leavesFrom, DateTime leavesTo);
    }
}
