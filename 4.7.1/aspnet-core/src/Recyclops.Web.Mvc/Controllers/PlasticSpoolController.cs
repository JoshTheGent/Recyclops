using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using Recyclops.Controllers;
using Recyclops.PlasticSpool;
using Recyclops.Web.Models.PlasticSpool;

namespace Recyclops.Web.Controllers
{
    public class PlasticSpoolController : RecyclopsControllerBase
    {
        #region Properies

        private readonly IPlasticSpoolService _PlasticSpoolService;

        #endregion

        #region Constructor

        public PlasticSpoolController(IPlasticSpoolService PlasticSpoolService)
        {
            _PlasticSpoolService = PlasticSpoolService;
        }

        #endregion

        #region Views

        [HttpGet]
        public ActionResult Index()
        {
            var data = _PlasticSpoolService.GetAllIncluding();
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

            return PartialView("_Modal", id == null ? new PlasticSpoolViewModel() : new PlasticSpoolViewModel(await _PlasticSpoolService.Get(new EntityDto((int)id))));
        }

        #endregion

        #region Posts

        [HttpPost]
        public async Task Create(PlasticSpoolViewModel plasticSpoolViewModel)
        {
            var data = plasticSpoolViewModel.DtoModel();

            if (plasticSpoolViewModel.Id == 0)
                await _PlasticSpoolService.Create(data);
            if (plasticSpoolViewModel.Id != 0)
                await _PlasticSpoolService.Update(data);
        }

        [HttpPost]
        public async Task Delete(int id)
        {
            await _PlasticSpoolService.Delete(new EntityDto { Id = id });
        }

        #endregion

    }
}
