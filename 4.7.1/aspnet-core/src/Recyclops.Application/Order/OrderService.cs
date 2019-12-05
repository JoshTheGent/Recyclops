using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.AutoMapper;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using Microsoft.EntityFrameworkCore;
using Recyclops.Authorization.Users;
using Recyclops.Order.Dto;
using Recyclops.PlasticOrder;
using Recyclops.PlasticOrder.Dto;
using Recyclops.PlasticSpool.Dto;
using Recyclops.PrintableObject.Dto;
using Recyclops.PrintableOrder;
using Recyclops.PrintableOrder.Dto;
using Recyclops.Users;

namespace Recyclops.Order
{
    public class OrderService : AsyncCrudAppService<Domains.Order.Order, OrderDto, int>, IOrderService
    {

        #region Properties

        private readonly IRepository<Domains.PrintableOrder.PrintableOrder> _printableOrderRepository;
        private readonly IRepository<Domains.PlasticOrder.PlasticOrder> _plasticOrderRepository;
        private readonly IAbpSession _abpSession;

        #endregion


        #region Constructor

        public OrderService(IRepository<Domains.Order.Order, int> repository, IRepository<Domains.PrintableOrder.PrintableOrder> printableOrderRepository, IRepository<Domains.PlasticOrder.PlasticOrder> plasticOrderRepository, IAbpSession abpSession) : base(repository)
        {
            _plasticOrderRepository = plasticOrderRepository;
            _printableOrderRepository = printableOrderRepository;
            _abpSession = abpSession;
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
                .Include(x=>x.Client)
                .ToList();

            var dto = dom.Select(x => new OrderDto(x)).ToList();

            return dto;
        }


        public async Task SaveBridges(OrderHolder orderHolder)
        {
            
            var user = _abpSession.GetUserId();
            orderHolder.OrderDto.ClientId = user;
            if (orderHolder.OrderDto.Id == 0)
            {
                orderHolder.OrderDto.Id = (await base.Create(orderHolder.OrderDto)).Id;
            }

            var spoolTotal = (double)0;
            var spoolList = new List<PlasticOrderDto>();
            foreach (var spool in orderHolder.PlasticOrderDtos)
            {
                spoolTotal += spool.SellValue;
                
                var order = new Domains.PlasticOrder.PlasticOrder
                {
                    Id = 0,
                    OrderId = orderHolder.OrderDto.Id,
                    PlasticSpoolId = spool.Id
                };
                _plasticOrderRepository.Insert(order);
            }


            var printableTotal = (double)0;
            var printableList = new List<Domains.PrintableOrder.PrintableOrder>();
            foreach (var printable in orderHolder.PrintableOrderDtos)
            {
                printableTotal += printable.SellValue;
                var order = new Domains.PrintableOrder.PrintableOrder
                {
                    OrderId = orderHolder.OrderDto.Id,
                    PrintableObjectId = printable.Id
                };
                _printableOrderRepository.Insert(order);
                
            }


            orderHolder.OrderDto.TotalCost = spoolTotal + printableTotal;


            
            await base.Update(orderHolder.OrderDto);
            
                



        }

        #endregion

    }
}
