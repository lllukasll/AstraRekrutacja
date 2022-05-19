using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstraRekrutacja.Data.Models
{
    public class WorkerVMTest
    {
        public IEnumerable<WorkerLeavesResultViewModel> WorkerLeavesResultViewModels { get; set; }
        public WorkerLeavesDto WorkerDateFromTo { get; set; }
    }
}
