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

        public DashReportViewModel(DateTime now)
        {
            StartDate = new DateTime(now.Year, now.Month, now.Day).AddDays(-1);
            EndDate = new DateTime(now.Year, now.Month, now.Day).AddDays(1);
        }

        public DashReportViewModel(DashLocationDto locationReport, DashPlasticDto plasticReport, DashSpoolDto spoolReport, DashPrintableDto printableReport)
        {
            LocationReport = locationReport;

            PlasticReport = plasticReport;

            SpoolReport = spoolReport;

            PrintableReport = printableReport;
        }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public DashLocationDto LocationReport { get; set; }

        public DashPlasticDto PlasticReport { get; set; }

        public DashSpoolDto SpoolReport { get; set; }

        public DashPrintableDto PrintableReport { get; set; }
    }
}
