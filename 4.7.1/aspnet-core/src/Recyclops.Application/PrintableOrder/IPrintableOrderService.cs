using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services;
using Recyclops.PrintableOrder.Dto;

namespace Recyclops.PrintableOrder
{
    public interface IPrintableOrderService : IAsyncCrudAppService<PrintableOrderDto, int>
    {
    }
}
