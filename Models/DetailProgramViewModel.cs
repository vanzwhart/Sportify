using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MyFitness.Models
{
    public class DetailProgramViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string FotoGerakan { get; set; }
        public string Deskripsi { get; set; }
        public string Langkah { get; set; }

        public int ProgramId { get; set; }
        [ForeignKey("ProgramId")]
        public JenisProgram JenisProgram { get; set; }
    }
}