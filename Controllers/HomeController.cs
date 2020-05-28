using Microsoft.AspNet.Identity;
using MyFitness.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

            var allprograms = _context.HasilRekomendasis.Include(x => x.JenisProgram).Where(a => a.UserId == userid).ToList().Select(a => a.JenisProgram);
            
            
            var viewmodel = new AllProgramViewModel
            {
                programs = allprograms
            };

            var uss = _context.UserInfo.FirstOrDefault(x => x.UserId == userid);
            DateTime Now = DateTime.Today;
            int umur = Now.Year - uss.tanggal_lahir.Year;

            if(umur <= 30 && uss.BMI != "Normal" || umur > 30 && umur <= 40 && uss.BMI == "Normal")
            {
                if(uss.Tingkatan == 1)
                {
                    ViewBag.Set = "3 Set 10 Repetisi";
                }
                else if(uss.Tingkatan == 2)
                {
                    ViewBag.Set = "4 Set 10 Repetisi";
                }
                ViewBag.Set = "4 Set 12 Repetisi";
            }
            else if(umur <= 30 && uss.BMI == "Normal")
            {
                if(uss.Tingkatan == 1)
                {
                    ViewBag.Set = "3 Set 12 Repetisi";
                }
                else if (uss.Tingkatan == 2)
                { 
                    ViewBag.Set = "4 Set 12 Repetisi";
                }
                ViewBag.Set = "5 Set 10 Repetisi";
                
            }
            else if (umur > 30 && umur <= 40 && uss.BMI != "Normal" || umur > 40 && umur <= 50 && uss.BMI == "Normal")
            {
                if (uss.Tingkatan == 1)
                {
                    ViewBag.Set = "3 Set 10 Repetisi";
                }
                else if (uss.Tingkatan == 2)
                {
                    ViewBag.Set = "3 Set 12 Repetisi";
                }
                ViewBag.Set = "4 Set 10 Repetisi";

            }
            else if (umur > 40 && umur <= 50 && uss.BMI != "Normal")
            {
                if (uss.Tingkatan == 1)
                {
                    ViewBag.Set = "3 Set 8 Repetisi";
                }
                else if (uss.Tingkatan == 2)
                {
                    ViewBag.Set = "3 Set 10 Repetisi";
                }
                ViewBag.Set = "3 Set 12 Repetisi";

            }
      


            return View("/Views/Home/Index.cshtml",viewmodel);
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