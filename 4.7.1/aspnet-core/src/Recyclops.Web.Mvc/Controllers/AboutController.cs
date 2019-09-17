using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using Recyclops.Controllers;

namespace Recyclops.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AboutController : RecyclopsControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
