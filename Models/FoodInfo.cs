using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MyFitness.Models
{
    public class FoodInfo
    {
        public int Id { get; set;}
        [Required]
        [StringLength (255)]
        public string NamaMakanan { get; set; }
        public int TotalCalories { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
    }
}