using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using Recyclops.Controllers;

namespace Recyclops.Web.Controllers
{
    [AbpMvcAuthorize]
    public class PowerPointController : RecyclopsControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }

    }
}
