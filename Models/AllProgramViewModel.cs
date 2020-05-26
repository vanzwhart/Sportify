using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFitness.Models
{
    public class AllProgramViewModel
    {
        public IEnumerable<JenisProgram> programs { get; set; }
    }
}