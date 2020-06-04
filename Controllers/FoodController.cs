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
    public class FoodController : Controller
    {
        private ApplicationDbContext _context;

        public FoodController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Food
        public ActionResult Index()
        {
            if(User.IsInRole("Admin"))
                return View();
            return View("/Views/Food/UserIndex.cshtml");
           
           
        }

        public ActionResult MyFood()
        {
            
            var iduser = User.Identity.GetUserId();

            var userinfo = _context.UserInfo.FirstOrDefault(x => x.UserId == iduser);
            DateTime Now = DateTime.Today;
            int umur = Now.Year - userinfo.tanggal_lahir.Year;
            double recCalories = 0;
            double tde = 0;
            if(userinfo.JenisKelamin == "Male")
            { 
                recCalories = 88.382 + (13.397 * userinfo.BeratBadan) + (4.799 * userinfo.TinggiBadan) - (5.677 * umur);
              
            }
            else
            {
               recCalories = 447.593 + (9.247 * userinfo.BeratBadan) + (3.098 * userinfo.TinggiBadan) - (4.33 * umur);
            }

            if (userinfo.Tingkatan == 1)
            {
                tde = recCalories * 1.2;
            }
            else if (userinfo.Tingkatan == 2)
            {
                tde = recCalories * 1.375;
            }
            else
            {
                tde = recCalories * 1.55;
            }

            ViewBag.Tde = Math.Round(tde,0);
            ViewBag.RecCalories = Math.Round(recCalories,0);

            var myCalories = _context.MyFood.Include(a => a.food).Where(x => x.UserId == iduser).ToList();
            var totCal = 0;
            if (myCalories.Count > 0)
            {
                foreach (var cal in myCalories)
                {
                    totCal += cal.food.FoodCalories;
                }
            }
            ViewBag.MyCalories = totCal;
            Session["UserId"] = iduser;
            return View();
        }
    }
}