using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services;
using Recyclops.Order.Dto;

namespace Recyclops.Order
{
    public interface IOrderService : IAsyncCrudAppService<OrderDto, int>
    {

        List<OrderDto> GetAllIncluding();

    }
}
