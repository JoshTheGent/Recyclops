using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using Recyclops.Controllers;
using Recyclops.LocationSource;
using Recyclops.PrintableObject;
using Recyclops.Web.Models.PrintableObject;

namespace Recyclops.Web.Controllers
{
    public class PrintableObjectController : RecyclopsControllerBase
    {
        #region Properies

        private readonly IPrintableObjectService _printableObjectService;

        #endregion

        #region Constructor

        public PrintableObjectController(IPrintableObjectService printableObjectService)
        {
            _printableObjectService = printableObjectService;
        }

        #endregion

        #region Views

        [HttpGet]
        public ActionResult Index()
        {
            var data = _printableObjectService.GetAllIncluding();
            var model = data.Select(x => new PrintableObjectViewModel(x)).ToList();

            return View(model);
        }

        /*[HttpGet]
        public PartialViewResult LoadTableData()
        {
            
            return PartialView("_Table", model);
        }*/

        [HttpGet]
        public async Task<PartialViewResult> LoadForm(int? id)
        {

            return PartialView("_Modal", id == null ? new PrintableObjectViewModel() : new PrintableObjectViewModel(await _printableObjectService.Get(new EntityDto((int)id))));
        }

        #endregion

        #region Posts

        [HttpPost]
        public async Task Create(PrintableObjectViewModel PrintableObjectViewModel)
        {
            var data = PrintableObjectViewModel.DtoModel();

            if (PrintableObjectViewModel.Id == 0)
                await _printableObjectService.Create(data);
            if (PrintableObjectViewModel.Id != 0)
                await _printableObjectService.Update(data);
        }

        [HttpPost]
        public async Task Delete(int id)
        {
            await _printableObjectService.Delete(new EntityDto { Id = id });
        }

        #endregion

    }
}
