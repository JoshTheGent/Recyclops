using System.Threading.Tasks;
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


            var model = new DashReportViewModel(_dashBoardService.GetDashLocationReport(), _dashBoardService.GetDashPlasticReport());

            return View(model);
        }



        public async Task Upload()
        {
            if (!_domainHelper.UploadCheck()) return;
            var locIds = await _domainHelper.UploadLocations();
            var plasticIds = await _domainHelper.UploadPlastics(locIds);
            var spoolIds = await _domainHelper.UploadSpools(plasticIds);
            var printableIds = await _domainHelper.UploadPrintables(spoolIds);
        }



	}
}
