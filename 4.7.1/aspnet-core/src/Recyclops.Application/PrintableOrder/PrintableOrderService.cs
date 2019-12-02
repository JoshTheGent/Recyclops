using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using Recyclops.PrintableOrder.Dto;

namespace Recyclops.PrintableOrder
{
    public class PrintableOrderService : AsyncCrudAppService<Domains.PrintableOrder.PrintableOrder, PrintableOrderDto, int>, IPrintableOrderService
    {

        public PrintableOrderService(IRepository<Domains.PrintableOrder.PrintableOrder, int> repo) : base(repo)
        {

        }


    }
}
