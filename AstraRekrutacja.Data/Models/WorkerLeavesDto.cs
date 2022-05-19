using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstraRekrutacja.Data.Models
{
    public class WorkerLeavesDto
    {
        [Display(Name = "Vacation Start Date")]
        public DateTime LeavesFrom { get; set; }
        [Display(Name = "Vacation End Date")]
        public DateTime LeavesTo { get; set; }
    }
}
