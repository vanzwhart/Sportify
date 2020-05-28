using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MyFitness.Models
{
    public class HasilRekomendasi
    {
        public int Id { get; set; }
       
        public int ProgramId { get; set; }
        [ForeignKey("ProgramId")]
        public JenisProgram JenisProgram { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
        
    }
}