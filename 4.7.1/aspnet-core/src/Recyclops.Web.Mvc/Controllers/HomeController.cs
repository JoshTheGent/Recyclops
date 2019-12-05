using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using Recyclops.Audit;
using Recyclops.Controllers;
using Recyclops.DashBoardReports;
using Recyclops.DomainHelper;
using Recyclops.Web.Models.DashReport;
using Recyclops.Web.Models.Home;

namespace Recyclops.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : RecyclopsControllerBase
    {
        private readonly IDashBoardService _dashBoardService;
        private readonly IDomainHelper _domainHelper;
        private readonly IAuditService _auditService;

        public HomeController(IDashBoardService dashBoardService, IDomainHelper domainHelper, IAuditService auditService)
        {
            _dashBoardService = dashBoardService;
            _domainHelper = domainHelper;
            _auditService = auditService;
        }






        public ActionResult Index()
        {
            var now = DateTime.Now;

            var model = new DashReportViewModel(_dashBoardService.GetDashLocationReport(),
                _dashBoardService.GetDashPlasticReport(), _dashBoardService.GetDashSpoolReport(), _dashBoardService.GetDashPrintableReport())
            {
                StartDate = new DateTime(now.Year, now.Month, now.Day).AddDays(-1),
                EndDate = new DateTime(now.Year, now.Month, now.Day).AddDays(1)
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult LoadTable(AuditIndexViewModel model)
        {
            //var model = new AuditIndexViewModel();
            var returnModel = _auditService.GetAuditTypeReport(model.StartDate, model.EndDate);
            return PartialView("_AuditTable", returnModel);
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
