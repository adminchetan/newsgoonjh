using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace vinay.Controllers
{
    public class PublicController : Controller
    {
        // GET: Public
        public ActionResult Index()
        {
            return View();
        }
    }
}