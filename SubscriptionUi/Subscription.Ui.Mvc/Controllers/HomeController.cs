using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Subscription.Ui.Mvc.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            return RedirectToAction("Authentication", "Authentication", new { area = "Authentication" });
        }
    }
}