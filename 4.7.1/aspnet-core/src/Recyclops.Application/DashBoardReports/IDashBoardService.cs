using System;
using System.Collections.Generic;
using System.Text;
using Recyclops.DashBoardReports.Dto;

namespace Recyclops.DashBoardReports
{
    public interface IDashBoardService
    {

        DashLocationDto GetDashLocationReport();

        DashPlasticDto GetDashPlasticReport();
    }
}
