using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recyclops.Web.Models.Home
{
    public class AuditIndexViewModel
    {
        public AuditIndexViewModel()
        {

        }

        public AuditIndexViewModel(DateTime now)
        {
            StartDate = new DateTime(now.Year, now.Month, now.Day).AddDays(-5);
            EndDate = new DateTime(now.Year, now.Month, now.Day).AddDays(1);
        }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
