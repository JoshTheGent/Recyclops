using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using Recyclops.Controllers;
using Recyclops.Plastic;
using Recyclops.PlasticSpool;
using Recyclops.Web.Models.PlasticSpool;

namespace Recyclops.Web.Controllers
{
    [AbpMvcAuthorize]
    public class PlasticSpoolController : RecyclopsControllerBase
    {
        #region Properies

        private readonly IPlasticSpoolService _plasticSpoolService;
        private readonly IPlasticService _plasticService;

        #endregion

        #region Constructor

        public PlasticSpoolController(IPlasticSpoolService plasticSpoolService, IPlasticService plasticService)
        {
            _plasticSpoolService = plasticSpoolService;
            _plasticService = plasticService;
        }

        #endregion

        #region Views

        [HttpGet]
        public ActionResult Index()
        {
            var data = _plasticSpoolService.GetAllIncluding();
            var model = data.Select(x => new PlasticSpoolViewModel(x)).ToList();

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
            var plastics = _plasticService.GetAllIncludingLocation().ToList();

            return PartialView("_Modal", id == null ? new PlasticSpoolViewModel(plastics) : new PlasticSpoolViewModel(await _plasticSpoolService.Get(new EntityDto((int)id)), plastics));
        }

        #endregion

        #region Posts

        [HttpPost]
        public async Task Create(PlasticSpoolViewModel plasticSpoolViewModel)
        {
            var data = plasticSpoolViewModel.DtoModel();

            if (plasticSpoolViewModel.Id == 0)
                await _plasticSpoolService.Create(data);
            if (plasticSpoolViewModel.Id != 0)
                await _plasticSpoolService.Update(data);
        }

        [HttpPost]
        public async Task Delete(int id)
        {
            await _plasticSpoolService.Delete(new EntityDto { Id = id });
        }

        #endregion

    }
}
