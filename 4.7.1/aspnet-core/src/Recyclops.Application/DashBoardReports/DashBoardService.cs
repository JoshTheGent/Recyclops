using System;
using System.Collections.Generic;
using System.Text;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Recyclops.LocationSource;

namespace Recyclops.DashBoardReports
{
    public class DashBoardService: IDashBoardService, ITransientDependency
    {
        #region Properties

        private readonly IRepository<Domains.LocationSource.LocationSource> _locationSourceService;


        #endregion


        #region Constructor

        public DashBoardService(IRepository<Domains.LocationSource.LocationSource> locationSourceService)
        {
            _locationSourceService = locationSourceService;
        }

        #endregion


        #region Methods



        #endregion
    }
}
