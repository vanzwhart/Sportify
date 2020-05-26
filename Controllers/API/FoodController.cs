using AutoMapper;
using MyFitness.Dtos;
using MyFitness.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyFitness.Controllers.API
{
    public class FoodController : ApiController
    {
        private ApplicationDbContext _context;

        public FoodController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/food
        public IEnumerable<foodDto> GetFoods()
        {
            return _context.Food.ToList().Select(Mapper.Map<Food, foodDto>);
        }

        
        [Route("api/food/update/{id}")]
        public foodDto GetCustomersEdit(int id)
        {

            var food = _context.Food.SingleOrDefault(c => c.FoodId == id);

            if (food == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Mapper.Map<Food, foodDto>(food);
        }

        //POST /api/food
        [HttpPost]
        public IHttpActionResult CreateFood(foodDto foodDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var food = Mapper.Map<foodDto, Food>(foodDto);

            _context.Food.Add(food);
            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + food.FoodId), foodDto);
        }

        //PUT /api/food/1
        [HttpPut]
        public void updateFood(int id, foodDto foodDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var foodInDb = _context.Food.SingleOrDefault(m => m.FoodId == id);

            foodDto.FoodId = id;

            if(foodInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map(foodDto, foodInDb);
            _context.SaveChanges();
        }

        //DELETE api/customers/1
        [HttpDelete]
        public void DeleteFood(int id)
        {
            var foodInDb = _context.Food.SingleOrDefault(c => c.FoodId == id);

            if (foodInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _context.Food.Remove(foodInDb);
            _context.SaveChanges();
        }
    }
}
