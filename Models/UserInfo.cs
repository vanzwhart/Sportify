using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MyFitness.Models
{
    public class UserInfo
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string NamaLengkap { get; set; }
        public int BeratBadan { get; set; }
        public int TinggiBadan { get; set; }
        public bool Dada { get; set; }
        public bool Bahu { get; set; }
        public bool Punggung { get; set; }
        public bool Kaki { get; set; }
        public bool Bokong { get; set; }
        public bool Perut { get; set; }
        public bool LenganBicep { get; set; }
        public bool LenganTricep { get; set; }

        public string JenisKelamin { get; set; }
        public string BMI { get; set; }

        public int Tingkatan { get; set; }

        public DateTime tanggal_update { get; set; }
        public DateTime tanggal_lahir { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
       

    }
}