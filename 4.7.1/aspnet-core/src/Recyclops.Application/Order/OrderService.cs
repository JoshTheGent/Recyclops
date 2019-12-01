using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Recyclops.Order.Dto;

namespace Recyclops.Order
{
    public class OrderService : AsyncCrudAppService<Domains.Order.Order, OrderDto, int>, IOrderService
    {

        #region Properties



        #endregion


        #region Constructor

        public OrderService(IRepository<Domains.Order.Order, int> repository) : base(repository)
        {
        }

        #endregion


        #region Methods

        public List<OrderDto> GetAllIncluding()
        {
            var dom = Repository
                .GetAll()
                .Include(x => x.PlasticOrders)
                .ThenInclude(x=>x.PlasticSpool)
                .ThenInclude(x=>x.Plastic)
                .Include(x=>x.PrintableOrders)
                .ThenInclude(x=>x.PrintableObject)
                .ThenInclude(x=>x.PlasticSpool)
                .ThenInclude(x=>x.Plastic)
                .ToList();

            var dto = dom.Select(x => new OrderDto(x)).ToList();

            return dto;
        }


        #endregion

    }
}
