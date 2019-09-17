using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using Recyclops.LocationSource.Dto;

namespace Recyclops.LocationSource
{
    public class LocationSourceService : AsyncCrudAppService<Domains.LocationSource.LocationSource, LocationSourceDto, int>, ILocationSourceService
    {

        #region Properties



        #endregion


        #region Constructor

        public LocationSourceService(IRepository<Domains.LocationSource.LocationSource, int> repository) : base(repository)
        {
        }

        #endregion


        #region Methods


        #endregion


    }
}
