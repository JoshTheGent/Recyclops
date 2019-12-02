using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
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

        private readonly IPrintableOrderService _printableOrderRepository;
        private readonly IPlasticOrderService _plasticOrderRepository;
        private readonly IAbpSession _abpSession;

        #endregion


        #region Constructor

        public OrderService(IRepository<Domains.Order.Order, int> repository, IPrintableOrderService printableOrderRepository, IPlasticOrderService plasticOrderRepository, IAbpSession abpSession) : base(repository)
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


        public async Task SaveBridges(OrderDto data, List<PlasticSpoolDto> spools, List<PrintableObjectDto> printables)
        {
            var user = _abpSession.GetUserId();
            data.ClientId = user;
            if (data.Id == 0)
            {
                data.Id = (await base.Create(data)).Id;
            }

            var spoolTotal = (double)0;
            var spoolList = new List<PlasticOrderDto>();
            foreach (var spool in spools)
            {
                spoolTotal += spool.SellValue;
                //spoolList.Add(new PlasticOrderDto
                //{
                //    Id = 0,
                //    OrderId = data.Id,
                //    PlasticSpoolId = spool.Id
                //});

                await _plasticOrderRepository.Create(new PlasticOrderDto
                {
                    Id = 0,
                    OrderId = data.Id,
                    PlasticSpoolId = spool.Id
                });
            }

            //foreach (var spool in spoolList)
            //{
            //    //spool.DerivedTotal = spoolTotal;
            //    var plas = (await _plasticOrderRepository.Create(spool)).Id;
            //}

            var printableTotal = (double)0;
            var printableList = new List<Domains.PrintableOrder.PrintableOrder>();
            foreach (var printable in printables)
            {
                printableTotal += printable.SellValue;
                await _printableOrderRepository.Create(new PrintableOrderDto
                {
                    OrderId = data.Id,
                    PrintableObjectId = printable.Id
                });
                //printableList.Add(new Domains.PrintableOrder.PrintableOrder
                //{
                //    Id = 0,
                //    OrderId = data.Id,
                //    PrintableObjectId = printable.Id
                //});
            }

            //foreach (var printable in printableList)
            //{
            //    //printable.DerivedTotal = printableTotal;
            //    var prin = (await _printableOrderRepository.Create(new PrintableOrderDto(printable))).Id;
            //}

            data.TotalCost = spoolTotal + printableTotal;



            
            await base.Update(data);
            
                



        }

        #endregion

    }
}
