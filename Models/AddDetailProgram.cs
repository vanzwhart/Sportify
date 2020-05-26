using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyFitness.Models
{
    public class AddDetailProgram
    {
        public int Id { get; set; }
   
        public HttpPostedFileBase FotoGerakan { get; set; }
        public string Deskripsi { get; set; }
        public string Langkah { get; set; }

        public int ProgramId { get; set; }
        [ForeignKey("ProgramId")]
        public JenisProgram JenisProgram { get; set; }
    }
}