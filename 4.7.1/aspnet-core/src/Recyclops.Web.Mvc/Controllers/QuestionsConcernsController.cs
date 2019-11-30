using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Authorization;
using Abp.Authorization;
using Microsoft.AspNetCore.Mvc;
using Recyclops.Controllers;

namespace Recyclops.Web.Controllers
{
    [AbpMvcAuthorize]
    public class QuestionsConcernsController : RecyclopsControllerBase
    {

        public QuestionsConcernsController()
        {

        }

        public ActionResult Index()
        {
            return View();
        }

    }
}
