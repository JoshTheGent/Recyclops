using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Recyclops.PlasticSpool.Dto;

namespace Recyclops.PlasticSpool
{
    public class PlasticSpoolService : AsyncCrudAppService<Domains.PlasticSpool.PlasticSpool, PlasticSpoolDto, int>, IPlasticSpoolService
    {

        #region Properties



        #endregion


        #region Constructor

        public PlasticSpoolService(IRepository<Domains.PlasticSpool.PlasticSpool, int> repository) : base(repository)
        {
        }

        #endregion


        #region Methods

        public List<PlasticSpoolDto> GetAllIncluding()
        {
            var dom = Repository
                .GetAll()
                .Include(x => x.Plastic)
                .ThenInclude(x => x.LocationSource)
                .Include(x => x.PrintableObjects)
                .ToList();

            var dto = dom.Select(x => new PlasticSpoolDto(x)).ToList();

            return dto;
        }


        #endregion
    }

}
