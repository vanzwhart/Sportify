using Microsoft.AspNet.Identity;
using MyFitness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFitness.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult Index()
        {
            var userid = User.Identity.GetUserId();
            var exist = _context.UserInfo.Where(x => x.UserId == userid).ToList();
            if (exist.Count == 0)
            {
                return View("/Views/Account/UserInfo.cshtml");            
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


   
        [Authorize]
        public ActionResult UserInfo()
        {
            return View("/Views/Account/UserInfo.cshtml");
        }
        
       
    }
}