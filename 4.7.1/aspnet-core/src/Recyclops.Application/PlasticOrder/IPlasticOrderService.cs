using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services;
using Recyclops.PlasticOrder.Dto;
using Recyclops.PrintableOrder.Dto;

namespace Recyclops.PlasticOrder
{
    public interface IPlasticOrderService : IAsyncCrudAppService<PlasticOrderDto, int>
    {
    }
}