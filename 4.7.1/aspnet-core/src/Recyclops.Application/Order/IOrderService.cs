using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Recyclops.Order.Dto;
using Recyclops.PlasticSpool.Dto;
using Recyclops.PrintableObject.Dto;

namespace Recyclops.Order
{
    public interface IOrderService : IAsyncCrudAppService<OrderDto, int>
    {

        List<OrderDto> GetAllIncluding();

        Task SaveBridges(OrderDto data, List<PlasticSpoolDto> spools, List<PrintableObjectDto> printables);
    }
}
