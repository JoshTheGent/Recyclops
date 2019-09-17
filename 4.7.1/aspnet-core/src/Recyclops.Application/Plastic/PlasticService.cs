using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Recyclops.Plastic.Dto;

namespace Recyclops.Plastic
{
    public class PlasticService : AsyncCrudAppService<Domains.Plastic.Plastic, PlasticDto, int>, IPlasticService
    {

        #region Properties



        #endregion


        #region Constructor

        public PlasticService(IRepository<Domains.Plastic.Plastic, int> repository) : base(repository)
        {
        }

        #endregion


        #region Methods

        public List<PlasticDto> GetAllIncludingLocation()
        {
            var dom = Repository
                .GetAll()
                .Include(x => x.LocationSource)
                .ToList();

            var dto = dom.Select(x => new PlasticDto(x)).ToList();

            return dto;
        }


        #endregion


    }
}
