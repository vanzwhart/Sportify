using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFitness.Models
{
    public class ProgramDetailViewModel
    {
        public IEnumerable<DetailProgramViewModel> detailProg { get; set; }
    }
}