using AstraRekrutacja.Data.Models;
using AstraRekrutacja.Data.Repositories.Interfaces;
using AstraRekrutacja.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Threading.Tasks;

namespace AstraRekrutacja.Data.Repositories
{
    public class WorkerLeavesRepository : IWorkerLeavesRepository
    {
        private readonly MyDbContext Context;

        public WorkerLeavesRepository(MyDbContext context)
        {
            Context = context;
        }

        public async Task<IEnumerable<WorkerLeavesResult>> GetWorkerLeaves(DateTime leavesFrom, DateTime leavesTo)
        {
            var workerLeavesResult = await (from workerLeaves in Context.Workleaves
                                      join worker in Context.Workers on workerLeaves.WorkerId equals worker.WorkerId
                                      join manager in Context.Managers on worker.ManagerId equals manager.ManagerId
                                      join leaveType in Context.WorkleaveTypes on workerLeaves.WorkleaveTypeId equals leaveType.WorkleaveTypeId
                                      where workerLeaves.StartOfWorkleave >= leavesFrom && workerLeaves.StartOfWorkleave <= leavesTo
                                      where DbFunctions.AddDays(workerLeaves.StartOfWorkleave, workerLeaves.Days) >= leavesFrom && 
                                      DbFunctions.AddDays(workerLeaves.StartOfWorkleave, workerLeaves.Days) <= leavesTo
                                      where leaveType.Active == true
                                      where workerLeaves.Days <= 4
                                      select new WorkerLeavesResult()
                                      {
                                          WorkerName = worker.FirstName + " " + worker.LastName,
                                          ManagerName = manager.FirstName + " " + manager.LastName,
                                          LeaveStartDate = workerLeaves.StartOfWorkleave,
                                          LeaveTypeName = leaveType.WorkleaveName,
                                          LeaveStatus = workerLeaves.Status.ToString(),
                                          LeaveDays = workerLeaves.Days,
                                      }).ToListAsync();

            return workerLeavesResult;
        }
    }
}
