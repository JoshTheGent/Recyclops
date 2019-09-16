using Microsoft.AspNetCore.Antiforgery;
using Recyclops.Controllers;

namespace Recyclops.Web.Host.Controllers
{
    public class AntiForgeryController : RecyclopsControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
