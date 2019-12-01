using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using Recyclops.Controllers;
using Recyclops.DashBoardReports;
using Recyclops.DomainHelper;
using Recyclops.Web.Models.DashReport;

namespace Recyclops.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : RecyclopsControllerBase
    {
        private readonly IDashBoardService _dashBoardService;
        private readonly IDomainHelper _domainHelper;
        public HomeController(IDashBoardService dashBoardService, IDomainHelper domainHelper)
        {
            _dashBoardService = dashBoardService;
            _domainHelper = domainHelper;
        }






        public ActionResult Index()
        {
            _domainHelper.UploadLocations();
            _domainHelper.UploadPlastics();
            _domainHelper.UploadSpools();
            _domainHelper.UploadPrintables();

            var model = new DashReportViewModel(_dashBoardService.GetDashLocationReport(), _dashBoardService.GetDashPlasticReport());

            return View(model);
        }
	}
}
