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
        private readonly IRepository<Domains.PlasticSpool.PlasticSpool> _plasticSpoolService;
        private readonly IRepository<Domains.PrintableObject.PrintableObject> _printableObjectService;

        #endregion


        #region Constructor

        public DashBoardService(IRepository<Domains.LocationSource.LocationSource> locationSourceService, IRepository<Domains.Plastic.Plastic> plasticService, IRepository<Domains.PlasticSpool.PlasticSpool> plasticSpoolService, IRepository<Domains.PrintableObject.PrintableObject> printableObjectService)
        {
            _locationSourceService = locationSourceService;
            _plasticService = plasticService;
            _plasticSpoolService = plasticSpoolService;
            _printableObjectService = printableObjectService;
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

        public DashSpoolDto GetDashSpoolReport()
        {
            var plastic = _plasticSpoolService.GetAllList();



            return new DashSpoolDto(plastic);
        }

        public DashPrintableDto GetDashPrintableReport()
        {
            var plastic = _printableObjectService.GetAllList();



            return new DashPrintableDto(plastic);
        }


        #endregion
    }
}
