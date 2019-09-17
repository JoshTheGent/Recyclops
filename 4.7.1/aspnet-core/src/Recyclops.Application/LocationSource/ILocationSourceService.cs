using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services;
using Recyclops.LocationSource.Dto;

namespace Recyclops.LocationSource
{
    public interface ILocationSourceService : IAsyncCrudAppService<LocationSourceDto, int>
    {

    }
}
