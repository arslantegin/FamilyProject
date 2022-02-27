using Family.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Family.UI.Controllers
{
    public class HomeController : Controller
    {
        FamilyContext db = new FamilyContext();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}