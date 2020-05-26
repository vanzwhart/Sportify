using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MyFitness.Models
{
    public class JenisProgram  
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string NamaProgram { get; set; }
        public string JenisAlat { get; set; }
        public string JenisKelamin { get; set; }
        public bool Dada { get; set; }
        public bool Bahu { get; set; }
        public bool Punggung { get; set; }
        public bool Kaki { get; set; }
        public bool Bokong { get; set; }
        public bool Perut { get; set; }
        public bool LenganBicep { get; set; }
        public bool LenganTricep { get; set; }
        public string FotoGerakan { get; set; }
        public string Deskripsi { get; set; }

        public int Tingkatan { get; set; }

      
    

    }
}