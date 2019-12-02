using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Castle.Core.Internal;
using Microsoft.AspNetCore.Mvc;
using Recyclops.Controllers;
using Recyclops.LocationSource;
using Recyclops.Order;
using Recyclops.Plastic;
using Recyclops.PlasticSpool;
using Recyclops.PlasticSpool.Dto;
using Recyclops.PrintableObject;
using Recyclops.PrintableObject.Dto;
using Recyclops.PrintableOrder.Dto;
using Recyclops.Web.Models.Order;
using Recyclops.Web.Models.Plastic;
using Recyclops.Web.Models.PrintableObject;

namespace Recyclops.Web.Controllers
{
    public class OrderController : RecyclopsControllerBase
    {
        #region Properies

        private readonly IOrderService _orderService;
        private readonly IPrintableObjectService _printableObjectService;
        private readonly IPlasticSpoolService _plasticSpoolService;

        #endregion

        #region Constructor

        public OrderController(IOrderService orderService, IPrintableObjectService printableObjectService, IPlasticSpoolService plasticSpoolService)
        {
            _orderService = orderService;
            _printableObjectService = printableObjectService;
            _plasticSpoolService = plasticSpoolService;
        }

        #endregion


        [HttpGet]
        public ActionResult Index()
        {

            var orders = _orderService.GetAllIncluding().Select(x=>new OrderViewModel(x)).ToList();


            return View(orders);
        }

        [HttpGet]
        public async Task<PartialViewResult> LoadForm(int? id)
        {
            var printables = _printableObjectService.GetAllIncluding();
            var plastics = _plasticSpoolService.GetAllIncluding();

            return PartialView("_Modal", id == null ? new OrderViewModel(printables, plastics) : new OrderViewModel(await _orderService.Get(new EntityDto((int)id)), printables, plastics));
        }




        #region Posts

        [HttpPost]
        public async Task Create(OrderViewModel OrderViewModel)
        {
            var data = OrderViewModel.DtoModel();


            var spools = OrderViewModel.PlasticOrderIds.IsNullOrEmpty() ? new List<PlasticSpoolDto>(): OrderViewModel.PlasticOrderIds.Select(x => (_plasticSpoolService.Get(new EntityDto(x)).Result))
                .ToList();
            var printables = OrderViewModel.PrintableOrderIds.IsNullOrEmpty() ? new List<PrintableObjectDto>() : OrderViewModel.PrintableOrderIds.Select(x => (_printableObjectService.Get(new EntityDto(x)).Result))
                .ToList();

            await _orderService.SaveBridges(data, spools, printables);

            //if (OrderViewModel.Id == 0)
            //    await _orderService.Create(data);
            //if (OrderViewModel.Id != 0)
            //    await _orderService.Update(data);
        }

        [HttpPost]
        public async Task Complete(int id)
        {
            var order = _orderService.Get(new EntityDto(id)).Result;
            order.IsComplete = true;
            await _orderService.Update(order);
        }


        [HttpPost]
        public async Task Delete(int id)
        {
            await _orderService.Delete(new EntityDto { Id = id });
        }

        #endregion
    }
}
