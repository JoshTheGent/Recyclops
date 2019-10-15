using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using Recyclops.Controllers;
using Recyclops.DashBoardReports;
using Recyclops.Web.Models.DashReport;

namespace Recyclops.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : RecyclopsControllerBase
    {
        private readonly IDashBoardService _dashBoardService;

        public HomeController(IDashBoardService dashBoardService)
        {
            _dashBoardService = dashBoardService;
        }






        public ActionResult Index()
        {
            var model = new DashReportViewModel(_dashBoardService.GetDashLocationReport(), _dashBoardService.GetDashPlasticReport());

            return View(model);
        }
	}
}
