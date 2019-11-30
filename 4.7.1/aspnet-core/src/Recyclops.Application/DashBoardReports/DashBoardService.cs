using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Text;
using Abp.Application.Services.Dto;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Recyclops.DashBoardReports.Dto;
using Recyclops.LocationSource;

namespace Recyclops.DashBoardReports
{
    public class DashBoardService: IDashBoardService, ITransientDependency
    {
        #region Properties

        private readonly IRepository<Domains.LocationSource.LocationSource> _locationSourceService;
        private readonly IRepository<Domains.Plastic.Plastic> _plasticService;


        #endregion


        #region Constructor

        public DashBoardService(IRepository<Domains.LocationSource.LocationSource> locationSourceService, IRepository<Domains.Plastic.Plastic> plasticService)
        {
            _locationSourceService = locationSourceService;
            _plasticService = plasticService;
        }

        #endregion


        #region Methods

        public DashLocationDto GetDashLocationReport()
        {
            var locations = _locationSourceService.GetAllList();



            return new DashLocationDto(locations);
        }

        public DashPlasticDto GetDashPlasticReport()
        {
            var plastic = _plasticService.GetAllList();



            return new DashPlasticDto(plastic);
        }



        #endregion
    }
}
