using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Recyclops.Controllers;
using Recyclops.Plastic;
using Recyclops.Web.Models.Plastic;
using Microsoft.AspNetCore.Mvc;
using Recyclops.LocationSource;

namespace Recyclops.Web.Controllers
{
    public class PlasticController : RecyclopsControllerBase
    {
        #region Properies

        private readonly IPlasticService _plasticService;
        private readonly ILocationSourceService _locationSourceService;

        #endregion

        #region Constructor

        public PlasticController(IPlasticService plasticService, ILocationSourceService locationSourceService)
        {
            _plasticService = plasticService;
            _locationSourceService = locationSourceService;
        }

        #endregion

        #region Views

        [HttpGet]
        public ActionResult Index()
        {
            var data = _plasticService.GetAllIncludingLocation();
            var model = data.Select(x => new PlasticViewModel(x)).ToList();

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
            var locations = _locationSourceService.GetAll(new PagedAndSortedResultRequestDto{ MaxResultCount = int.MaxValue }).Result.Items
                .ToList();

            return PartialView( "_Modal", id == null? new PlasticViewModel(locations) : new PlasticViewModel(await _plasticService.Get(new EntityDto( (int) id) ), locations ) );
        }

        #endregion

        #region Posts

        [HttpPost]
        public async Task Create(PlasticViewModel plasticViewModel)
        {
            var data = plasticViewModel.DtoModel();

            if (plasticViewModel.Id == 0)
                await _plasticService.Create(data);
            if (plasticViewModel.Id != 0)
                await _plasticService.Update(data);
        }

        [HttpPost]
        public async Task Delete(int id)
        {
            await _plasticService.Delete(new EntityDto { Id = id });
        }

        #endregion

    }
}
