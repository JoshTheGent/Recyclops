using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services;
using Recyclops.PlasticSpool.Dto;
using Recyclops.PrintableObject.Dto;

namespace Recyclops.PlasticSpool
{
    public interface IPlasticSpoolService : IAsyncCrudAppService<PlasticSpoolDto, int>
    {


        List<PlasticSpoolDto> GetAllIncluding();
    }
}
