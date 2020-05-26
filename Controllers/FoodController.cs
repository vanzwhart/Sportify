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
            return View();
        }

        public ActionResult MyFood()
        {
            
            var iduser = User.Identity.GetUserId();

            var userinfo = _context.UserInfo.FirstOrDefault(x => x.UserId == iduser);
            DateTime Now = DateTime.Today;
            int umur = Now.Year - userinfo.tanggal_lahir.Year;
            int recCalories = 0;
            if(userinfo.JenisKelamin == "Male")
            { 
                recCalories = 88 + (13 * userinfo.BeratBadan) + (5 * userinfo.TinggiBadan) - (6 * umur);
            }
            else
            {
               recCalories = 448 + (9 * userinfo.BeratBadan) + (3 * userinfo.TinggiBadan) - (4 * umur);
            }

            ViewBag.RecCalories = recCalories;

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