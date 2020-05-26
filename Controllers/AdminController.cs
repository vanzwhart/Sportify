using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFitness.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult AddMovement()
        {
            return View("/Views/Admin/AddMovement.cshtml");
        }
        public ActionResult AddAdmin()
        {
            return View("/Views/Admin/AddAdmin.cshtml");
        }
        public ActionResult AddFood()
        {
            return View("/Views/Admin/AddFood.cshtml");
        }
    }
}