using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyFitness.Models
{
    public class MyFood
    {
        public int MyFoodId { get; set; }
        public int FoodId { get; set; }
        [ForeignKey("FoodId")]
        public Food food { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
    }
}