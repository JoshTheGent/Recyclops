using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using Recyclops.PlasticOrder.Dto;

namespace Recyclops.PlasticOrder
{
    public class PlasticOrderService : AsyncCrudAppService<Domains.PlasticOrder.PlasticOrder, PlasticOrderDto, int>, IPlasticOrderService
    {

        public PlasticOrderService(IRepository<Domains.PlasticOrder.PlasticOrder, int> repo) : base(repo)
        {

        }


    }
}
