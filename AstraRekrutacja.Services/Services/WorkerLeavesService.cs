using AstraRekrutacja.Data.Models;
using AstraRekrutacja.Data.Repositories.Interfaces;
using AstraRekrutacja.Extensions;
using AstraRekrutacja.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstraRekrutacja.Services.Services
{
    public class WorkerLeavesService : IWorkerLeavesService
    {
        private IWorkerLeavesRepository workerLeavesRepository { get; }

        public WorkerLeavesService(IWorkerLeavesRepository workerLeavesRepository)
        {
            this.workerLeavesRepository = workerLeavesRepository;
        }

        public async Task<IEnumerable<WorkerLeavesResultViewModel>> GetWorkerVacation(DateTime leavesFrom, DateTime leavesTo)
        {
            var workerVacation = await workerLeavesRepository.GetWorkerLeaves(leavesFrom, leavesTo);

            var workerVacationViewModel = new List<WorkerLeavesResultViewModel>();

            foreach(var vac in workerVacation)
            {
                var endDate = vac.LeaveStartDate.AddBusinessDays(vac.LeaveDays);

                var range = "C";
                if(vac.LeaveStartDate >= leavesFrom && endDate <= leavesTo)
                {
                    range = "P";
                }

                workerVacationViewModel.Add(new WorkerLeavesResultViewModel
                {
                    WorkerName = vac.WorkerName,
                    ManagerName = vac.ManagerName,
                    LeaveStartDate = vac.LeaveStartDate.ToShortDateString(),
                    LeaveEndDate = endDate.ToShortDateString(),
                    LeaveTypeName = vac.LeaveTypeName,
                    LeaveStatus = vac.LeaveStatus,
                    LeaveDays = (int)(endDate - vac.LeaveStartDate).Days + 1,
                    Range = range
                });
            }

            return workerVacationViewModel;
        }
    }
}
