using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using Recyclops.Controllers;
using Recyclops.LocationSource;
using Recyclops.Web.Models.LocationSource;

namespace Recyclops.Web.Controllers
{
    public class LocationSourceController : RecyclopsControllerBase
    {
        #region Properies

        private readonly ILocationSourceService _locationSourceService;

        #endregion

        #region Constructor

        public LocationSourceController(ILocationSourceService locationSourceService)
        {
            _locationSourceService = locationSourceService;
        }

        #endregion

        #region Views

        [HttpGet]
        public ActionResult Index()
        {
            var data = _locationSourceService.GetAll(new PagedAndSortedResultRequestDto() { MaxResultCount = Int32.MaxValue }).Result.Items.ToList();
            var model = data.Select(x => new LocationSourceViewModel(x)).ToList();

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
            return PartialView("_Modal", id == null ? new LocationSourceViewModel() : new LocationSourceViewModel(await _locationSourceService.Get(new EntityDto((int)id))));
        }

        #endregion

        #region Posts

        [HttpPost]
        public async Task Create(LocationSourceViewModel LocationSourceViewModel)
        {
            var data = LocationSourceViewModel.DtoModel();

            if (LocationSourceViewModel.Id == 0)
                await _locationSourceService.Create(data);
            if (LocationSourceViewModel.Id != 0)
                await _locationSourceService.Update(data);
        }

        [HttpPost]
        public async Task Delete(int id)
        {
            await _locationSourceService.Delete(new EntityDto { Id = id });
        }

        #endregion

    }
}
