using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using Recyclops.Controllers;
using Recyclops.LocationSource;
using Recyclops.Order;
using Recyclops.Plastic;
using Recyclops.PlasticSpool;
using Recyclops.PrintableObject;
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

    }
}
