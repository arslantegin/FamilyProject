using Family.DAL;
using Family.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Family.UI.Controllers
{
    public class RelationController : Controller
    {
        FamilyContext db = new FamilyContext();
        // GET: Relation
        public ActionResult MyRequest()
        {
            Person currentUser = Session["currentPerson"] as Person;
            List<Request> requests = db.Requests.Where(x => x.ReceiverId == currentUser.Id).ToList();
            return View();
        }

        public ActionResult SendRequest()
        {
            return View(Request);
        }
    }

}