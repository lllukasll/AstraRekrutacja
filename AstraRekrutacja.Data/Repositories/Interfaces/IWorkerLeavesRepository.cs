using AstraRekrutacja.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstraRekrutacja.Data.Repositories.Interfaces
{
    public interface IWorkerLeavesRepository
    {
        Task<IEnumerable<WorkerLeavesResult>> GetWorkerLeaves(DateTime leavesFrom, DateTime leavesTo);
    }
}
