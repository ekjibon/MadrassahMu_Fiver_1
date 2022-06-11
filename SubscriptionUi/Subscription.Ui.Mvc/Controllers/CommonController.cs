using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Subscription.Ui.Mvc.Controllers
{
    public class CommonController : BaseController
    {
        // GET: Common
        public ActionResult Loading()
        {
            return View();
        }
    }
}