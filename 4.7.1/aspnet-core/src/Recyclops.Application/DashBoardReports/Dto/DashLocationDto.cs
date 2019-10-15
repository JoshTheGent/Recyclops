using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Recyclops.DashBoardReports.Dto
{
    public class DashLocationDto
    {
        public DashLocationDto()
        {

        }

        public DashLocationDto(List<Domains.LocationSource.LocationSource> domList)
        {
            var monthAgo = DateTime.Today.AddMonths(-1);


            LocationCount = domList.Count();
            NewLocationCount = domList.Count(x => x.CreationTime >= monthAgo);
        }

        //total locations
        public int LocationCount { get; set; }
        // locations added a month ago
        public int NewLocationCount { get; set; }

    }
}
