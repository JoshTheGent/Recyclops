using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using Recyclops.Controllers;

namespace Recyclops.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : RecyclopsControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
