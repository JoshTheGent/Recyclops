using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Recyclops.DashBoardReports.Dto;

namespace Recyclops.Web.Models.DashReport
{
    public class DashReportViewModel
    {
        public DashReportViewModel(DashLocationDto locationReport, DashPlasticDto plasticReport)
        {
            LocationReport = locationReport;

            PlasticReport = plasticReport;
        }

        public DashLocationDto LocationReport { get; set; }

        public DashPlasticDto PlasticReport { get; set; }
    }
}
