using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services;
using Recyclops.Plastic.Dto;

namespace Recyclops.Plastic
{
    public interface IPlasticService : IAsyncCrudAppService<PlasticDto, int>
    {

        /// <summary>
        /// Gets all of the Plastic Dtos with the Location Sources
        /// </summary>
        /// <returns></returns>
        List<PlasticDto> GetAllIncludingLocation();
    }
}
