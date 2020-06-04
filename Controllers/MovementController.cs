using Microsoft.AspNet.Identity;
using MyFitness.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFitness.Controllers
{
   
    public class MovementController : Controller
    {
        private ApplicationDbContext _context;

        public MovementController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Movement
        public ActionResult Index()
        {
            var allprograms = _context.JenisPrograms.ToList();
            var viewmodel = new AllProgramViewModel
            {
                programs = allprograms
            };
            return View(viewmodel);
        }

        [Authorize]
        public ActionResult AddMovement()
        {
            return PartialView("_addMovement");
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddMovement(AddProgram model)
        {

            if (ModelState.IsValid)
            {
                try
                {

                    JenisProgram prog = new JenisProgram();
                    prog.NamaProgram = model.NamaProgram;
                    prog.Deskripsi = model.Deskripsi;
                    prog.JenisKelamin = model.JenisKelamin;
                    prog.JenisAlat = model.JenisAlat;
                    prog.Tingkatan = model.Tingkatan;
                    prog.Punggung = model.Punggung;
                    prog.Perut = model.Perut;
                    prog.LenganTricep = model.LenganTricep;
                    prog.LenganBicep = model.LenganBicep;
                    prog.Kaki = model.Kaki;
                    prog.Dada = model.Dada;
                    prog.Bahu = model.Bahu;
                    prog.Bokong = model.Bokong;


                    if (model.FotoGerakan != null)
                    {
                        if (model.FotoGerakan.ContentLength > 0)
                        {
                            var fileName = Path.GetFileName(model.FotoGerakan.FileName);
                            var guid = Guid.NewGuid().ToString();
                            var folderPath = Server.MapPath("~/uploads/" + model.NamaProgram);
                            if (!Directory.Exists(folderPath))
                            {
                                Directory.CreateDirectory(folderPath);
                            }
                            var path = Path.Combine(folderPath, fileName);
                            model.FotoGerakan.SaveAs(path);
                            string fl = path.Substring(path.LastIndexOf("\\"));
                            string[] split = fl.Split('\\');
                            string newpath = split[1];
                            string imagepath = "/uploads/" + model.NamaProgram + "/" + newpath;
                            prog.FotoGerakan = imagepath;
                        }
                    }
                    _context.JenisPrograms.Add(prog);
                    _context.SaveChanges();
                    TempData["Success"] = "Shop Added Successfully!";
                }
                catch (Exception e)
                {
                    TempData["Error"] = e.Message;
                }
            }



            return RedirectToAction("Index", "Movement");
        }



        [HttpGet]
        public ActionResult EditMovement(int? id)
        {
            JenisProgram prog = _context.JenisPrograms.FirstOrDefault(z => z.Id == id);
            AddProgram editMovement = new AddProgram();
            editMovement.NamaProgram = prog.NamaProgram;
            editMovement.Deskripsi = prog.Deskripsi;
            editMovement.JenisKelamin = prog.JenisKelamin;
            editMovement.JenisAlat = prog.JenisAlat;
            editMovement.Tingkatan = prog.Tingkatan;
            return PartialView("_editMovement", editMovement);
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditMovement(AddProgram model)
        {
           
            if (ModelState.IsValid)
            {
                try
                {
                    JenisProgram prog = _context.JenisPrograms.FirstOrDefault(z => z.Id == model.Id);
                    prog.NamaProgram = model.NamaProgram;
                    prog.Deskripsi = model.Deskripsi;
                    prog.JenisKelamin = model.JenisKelamin;
                    prog.JenisAlat = model.JenisAlat;
                    prog.Tingkatan = model.Tingkatan;
                    prog.Punggung = model.Punggung;
                    prog.Perut = model.Perut;
                    prog.LenganTricep = model.LenganTricep;
                    prog.LenganBicep = model.LenganBicep;
                    prog.Kaki = model.Kaki;
                    prog.Dada = model.Dada;
                    prog.Bahu = model.Bahu;
                    prog.Bokong = model.Bokong;


                    if (model.FotoGerakan != null)
                    {
                        if (model.FotoGerakan.ContentLength > 0)
                        {
                            var fileName = Path.GetFileName(model.FotoGerakan.FileName);
                            var guid = Guid.NewGuid().ToString();
                            var folderPath = Server.MapPath("~/uploads/" + model.NamaProgram);
                            if (!Directory.Exists(folderPath))
                            {
                                Directory.CreateDirectory(folderPath);
                            }
                            var path = Path.Combine(folderPath, fileName);
                            model.FotoGerakan.SaveAs(path);
                            string fl = path.Substring(path.LastIndexOf("\\"));
                            string[] split = fl.Split('\\');
                            string newpath = split[1];
                            string imagepath = "/uploads/" + model.NamaProgram + "/" + newpath;
                            prog.FotoGerakan = imagepath;
                        }
                    }
                    _context.SaveChanges();
                   
                }
                catch (Exception e)
                {
                    TempData["Error"] = e.Message;
                }
            }



            return RedirectToAction("Index", "Movement");
        }

        [HttpGet]
        public ActionResult EditDetailMovement(int? id)
        {
            DetailProgramViewModel prog = _context.DetailPrograms.FirstOrDefault(z => z.Id == id);
            AddDetailProgram editMovement = new AddDetailProgram();
            editMovement.Deskripsi = prog.Deskripsi;
            editMovement.Langkah = prog.Langkah;
            editMovement.ProgramId = prog.ProgramId;
            editMovement.Id = prog.Id;
            return PartialView("_editDetailMovement", editMovement);
        }

        public ActionResult DeleteDetailMovement(int? id)
        {
            DetailProgramViewModel prog = _context.DetailPrograms.FirstOrDefault(z => z.Id == id);
            _context.DetailPrograms.Remove(prog);
            _context.SaveChanges();
            return RedirectToAction("Index", "Movement");
        }

        public ActionResult DeleteMovement(int id)
        {
            JenisProgram prog = _context.JenisPrograms.FirstOrDefault(z => z.Id == id);
            _context.JenisPrograms.Remove(prog);
            _context.SaveChanges();
            return RedirectToAction("Index", "Movement");
        }


        [HttpGet]
        public ActionResult DetailMovement(int? id)
        {
            var detailMovements = _context.DetailPrograms.Where(a => a.ProgramId == id).ToList();
            var viewmodel = new ProgramDetailViewModel
            {
                detailProg = detailMovements
            };
            ViewBag.ProgId = id;
            return View("/Views/Movement/MovementDetail.cshtml", viewmodel);
        }


        [HttpGet]
        public ActionResult AddDetailMovement(int? id)
        {
            ViewBag.ProgramId = _context.JenisPrograms.FirstOrDefault(x => x.Id == id).Id;
            return PartialView("_addDetailMovement");
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddDetailMovement(AddDetailProgram model)
        {

            if (ModelState.IsValid)
            {
                try
                {

                    DetailProgramViewModel prog = new DetailProgramViewModel();
                    prog.Langkah = model.Langkah;
                    prog.Deskripsi = model.Deskripsi;
                    prog.ProgramId = model.ProgramId;



                    if (model.FotoGerakan != null)
                    {
                        if (model.FotoGerakan.ContentLength > 0)
                        {
                            var fileName = Path.GetFileName(model.FotoGerakan.FileName);
                            var guid = Guid.NewGuid().ToString();
                            var folderPath = Server.MapPath("~/uploads/" + model.Id);
                            if (!Directory.Exists(folderPath))
                            {
                                Directory.CreateDirectory(folderPath);
                            }
                            var path = Path.Combine(folderPath, fileName);
                            model.FotoGerakan.SaveAs(path);
                            string fl = path.Substring(path.LastIndexOf("\\"));
                            string[] split = fl.Split('\\');
                            string newpath = split[1];
                            string imagepath = "/uploads/" + model.Id + "/" + newpath;
                            prog.FotoGerakan = imagepath;
                        }
                    }
                    _context.DetailPrograms.Add(prog);
                    _context.SaveChanges();
                    TempData["Success"] = "Shop Added Successfully!";
                }
                catch (Exception e)
                {
                    TempData["Error"] = e.Message;
                }
            }
            return RedirectToAction("DetailMovement", "Movement", new { id = model.ProgramId});
        }



        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditDetailMovement(AddDetailProgram model)
        {

            if (ModelState.IsValid)
            {
                try
                {

                    DetailProgramViewModel prog = _context.DetailPrograms.FirstOrDefault(x => x.Id == model.Id);
                    prog.Langkah = model.Langkah;
                    prog.Deskripsi = model.Deskripsi;
                    prog.ProgramId = model.ProgramId;



                    if (model.FotoGerakan != null)
                    {
                        if (model.FotoGerakan.ContentLength > 0)
                        {
                            var fileName = Path.GetFileName(model.FotoGerakan.FileName);
                            var guid = Guid.NewGuid().ToString();
                            var folderPath = Server.MapPath("~/uploads/" + model.Id);
                            if (!Directory.Exists(folderPath))
                            {
                                Directory.CreateDirectory(folderPath);
                            }
                            var path = Path.Combine(folderPath, fileName);
                            model.FotoGerakan.SaveAs(path);
                            string fl = path.Substring(path.LastIndexOf("\\"));
                            string[] split = fl.Split('\\');
                            string newpath = split[1];
                            string imagepath = "/uploads/" + model.Id + "/" + newpath;
                            prog.FotoGerakan = imagepath;
                        }
                    }
                    
                    _context.SaveChanges();
                    
                }
                catch (Exception e)
                {
                    TempData["Error"] = e.Message;
                }
            }
            return RedirectToAction("DetailMovement", "Movement", new { id = model.ProgramId });
        }
    }
}


