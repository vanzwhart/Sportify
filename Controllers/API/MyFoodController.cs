using AutoMapper;
using Microsoft.AspNet.Identity;
using MyFitness.Dtos;
using MyFitness.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyFitness.Controllers.API
{
    public class MyFoodController : ApiController
    {
        private ApplicationDbContext _context;

        public MyFoodController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/MyFood/1
        public IEnumerable<myFoodDto> GetMyFoods(string id)
        {
            var userid = User.Identity.GetUserId();
            return _context.MyFood.Include(x => x.food).Where(x => x.UserId == id).ToList().Select(Mapper.Map<MyFood, myFoodDto>);
        }

        // api/MyFood
        [HttpPost]
        public IHttpActionResult CreateMyFood(myFoodDto myFoodDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var myfood = Mapper.Map<myFoodDto, MyFood>(myFoodDto);
          


            _context.MyFood.Add(myfood);
            _context.SaveChanges();



            return Created(new Uri(Request.RequestUri + "/" + myfood.MyFoodId), myFoodDto);
        }

        // api/MyFood/1
        [HttpDelete]
        public void DeleteMyFood(int id)
        {
            var iduser = User.Identity.GetUserId();
            var myfoodInDb = _context.MyFood.FirstOrDefault(c => c.MyFoodId == id && c.UserId == iduser);

            if (myfoodInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _context.MyFood.Remove(myfoodInDb);
            _context.SaveChanges();
        }
    }
}
