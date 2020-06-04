using Microsoft.AspNet.Identity;
using MyFitness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFitness.Controllers
{
    public class UserController : Controller
    {
        ApplicationDbContext _context;
        public UserController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddUserInfo(UserInfo info)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var userid = User.Identity.GetUserId();
                    UserInfo userDB = new UserInfo();
                    userDB.UserId = userid;
                    userDB.BeratBadan = info.BeratBadan;
                    userDB.tanggal_lahir = info.tanggal_lahir;
                    userDB.Punggung = info.Punggung;
                    userDB.Perut = info.Perut;
                    userDB.NamaLengkap = info.NamaLengkap;
                    userDB.LenganTricep = info.LenganTricep;
                    userDB.LenganBicep = info.LenganBicep;
                    userDB.Kaki = info.Kaki;
                    userDB.Dada = info.Dada;
                    userDB.Bokong = info.Bokong;
                    userDB.Bahu = info.Bahu;
                    userDB.Tingkatan = info.Tingkatan;
                    userDB.TinggiBadan = info.TinggiBadan;
                    userDB.JenisKelamin = info.JenisKelamin;
                    userDB.tanggal_update = DateTime.Now;
                    int tinggi = (info.TinggiBadan / 100) * (info.TinggiBadan / 100);
                    int berat = info.BeratBadan;
                    int calBMI = berat / tinggi;
                    if(calBMI < 19)
                    {
                        userDB.BMI = "Underweight";
                    }
                    else if(calBMI >= 19 && calBMI <= 24)
                    {
                        userDB.BMI = "Normal";
                    }
                    else if(calBMI > 24)
                    {
                        userDB.BMI = "Overweight";
                    }

                    _context.UserInfo.Add(userDB);
                   

                    DateTime Now = DateTime.Today;
                    int umur = Now.Year - info.tanggal_lahir.Year;
                   
                    var exist = "a";
                    if (umur <= 25)
                    {
                        var nnull = _context.UserInfo.Where(a => a.UserId != userid && a.tanggal_lahir.Year - Now.Year >= -25 && a.JenisKelamin == info.JenisKelamin && a.Punggung == info.Punggung && a.Perut == info.Perut && a.LenganBicep == info.LenganBicep && a.LenganTricep == info.LenganTricep && a.Kaki == info.Kaki && a.Dada == info.Dada && a.Bokong == info.Bokong && a.Bahu == info.Bahu && a.BMI == userDB.BMI).ToList();
                        if (nnull.Count() > 0)
                        {
                            exist = _context.UserInfo.FirstOrDefault(a => a.UserId != userid && a.tanggal_lahir.Year - Now.Year >= -25 && a.JenisKelamin == info.JenisKelamin && a.Punggung == info.Punggung && a.Perut == info.Perut && a.LenganBicep == info.LenganBicep && a.LenganTricep == info.LenganTricep && a.Kaki == info.Kaki && a.Dada == info.Dada && a.Bokong == info.Bokong && a.Bahu == info.Bahu && a.BMI == userDB.BMI).UserId;
                        }
                    }
                    else if (umur > 25 && umur <= 45)
                    {
                        var nnull = _context.UserInfo.Where(a => a.UserId != userid & a.tanggal_lahir.Year - Now.Year < -25 && a.tanggal_lahir.Year - Now.Year >= -45 && a.JenisKelamin == info.JenisKelamin && a.Punggung == info.Punggung && a.Perut == info.Perut && a.LenganBicep == info.LenganBicep && a.LenganTricep == info.LenganTricep && a.Kaki == info.Kaki && a.Dada == info.Dada && a.Bokong == info.Bokong && a.Bahu == info.Bahu && a.BMI == userDB.BMI).ToList();
                        if (nnull.Count() > 0)
                        { 
                             exist = _context.UserInfo.FirstOrDefault(a => a.UserId != userid & a.tanggal_lahir.Year - Now.Year < -25 && a.tanggal_lahir.Year - Now.Year >= -45 && a.JenisKelamin == info.JenisKelamin && a.Punggung == info.Punggung && a.Perut == info.Perut && a.LenganBicep == info.LenganBicep && a.LenganTricep == info.LenganTricep && a.Kaki == info.Kaki && a.Dada == info.Dada && a.Bokong == info.Bokong && a.Bahu == info.Bahu && a.BMI == userDB.BMI).UserId;
                        }
                    }
                    else
                    {
                        var nnull = _context.UserInfo.Where(a => a.UserId != userid & a.tanggal_lahir.Year - Now.Year < -45 && a.JenisKelamin == info.JenisKelamin && a.Punggung == info.Punggung && a.Perut == info.Perut && a.LenganBicep == info.LenganBicep && a.LenganTricep == info.LenganTricep && a.Kaki == info.Kaki && a.Dada == info.Dada && a.Bokong == info.Bokong && a.Bahu == info.Bahu && a.BMI == userDB.BMI).ToList();
                        if(nnull.Count() > 0)
                        { 
                             exist = _context.UserInfo.FirstOrDefault(a => a.UserId != userid & a.tanggal_lahir.Year - Now.Year < -45   && a.JenisKelamin == info.JenisKelamin && a.Punggung == info.Punggung && a.Perut == info.Perut && a.LenganBicep == info.LenganBicep && a.LenganTricep == info.LenganTricep && a.Kaki == info.Kaki && a.Dada == info.Dada && a.Bokong == info.Bokong && a.Bahu == info.Bahu && a.BMI == userDB.BMI).UserId;
                        }
                    }



                    if(exist == "a")
                    {
                        var prog = _context.JenisPrograms.Where(x => x.JenisKelamin == info.JenisKelamin && x.Tingkatan == info.Tingkatan || x.JenisKelamin == "Unisex" && x.Tingkatan == info.Tingkatan).ToList();
                        if(info.Bahu == true)
                        {
                            var listprog = prog.Where(a => a.Bahu == true).ToList();
                            foreach(var a in listprog)
                            {
                                HasilRekomendasi hsl = new HasilRekomendasi();
                                hsl.UserId = userid;
                                hsl.ProgramId = a.Id;
                                _context.HasilRekomendasis.Add(hsl);
                                _context.SaveChanges();
                            }
                            
                        }
                        if (info.Bokong == true)
                        {
                            var listprog = prog.Where(a => a.Bokong == true).ToList();
                            foreach (var a in listprog)
                            {
                                var ads = _context.HasilRekomendasis.Where(x => x.UserId == userid && x.ProgramId == a.Id).ToList();
                                if (ads.Count() == 0)
                                {
                                    HasilRekomendasi hsl = new HasilRekomendasi();
                                    hsl.UserId = userid;
                                    hsl.ProgramId = a.Id;
                                    _context.HasilRekomendasis.Add(hsl);
                                    _context.SaveChanges();
                                }
                            }
                            
                        }
                        if (info.Perut == true)
                        {
                            var listprog = prog.Where(a => a.Perut == true).ToList();
                            foreach (var a in listprog)
                            {
                                var ads = _context.HasilRekomendasis.Where(x => x.UserId == userid && x.ProgramId == a.Id).ToList();
                                if (ads.Count() == 0)
                                {
                                    HasilRekomendasi hsl = new HasilRekomendasi();
                                    hsl.UserId = userid;
                                    hsl.ProgramId = a.Id;
                                    _context.HasilRekomendasis.Add(hsl);
                                    _context.SaveChanges();
                                }
                            }

                        }
                        if (info.Dada == true)
                        {
                            var listprog = prog.Where(a => a.Dada == true).ToList();
                            foreach (var a in listprog)
                            {
                                var ads = _context.HasilRekomendasis.Where(x => x.UserId == userid && x.ProgramId == a.Id).ToList();
                                if (ads.Count() == 0)
                                {
                                    HasilRekomendasi hsl = new HasilRekomendasi();
                                    hsl.UserId = userid;
                                    hsl.ProgramId = a.Id;
                                    _context.HasilRekomendasis.Add(hsl);
                                    _context.SaveChanges();
                                }
                            }
                           
                        }

                        if (info.Kaki == true)
                        {
                            var listprog = prog.Where(a => a.Kaki == true).ToList();
                            foreach (var a in listprog)
                            {
                                var ads = _context.HasilRekomendasis.Where(x => x.UserId == userid && x.ProgramId == a.Id).ToList();
                                if (ads.Count() == 0)
                                {
                                    HasilRekomendasi hsl = new HasilRekomendasi();
                                    hsl.UserId = userid;
                                    hsl.ProgramId = a.Id;
                                    _context.HasilRekomendasis.Add(hsl);
                                    _context.SaveChanges();
                                }
                            }
                           
                        }
                        if (info.LenganBicep == true)
                        {
                            var listprog = prog.Where(a => a.LenganBicep == true).ToList();
                            foreach (var a in listprog)
                            {
                                var ads = _context.HasilRekomendasis.Where(x => x.UserId == userid && x.ProgramId == a.Id).ToList();
                                if (ads.Count() == 0)
                                {
                                    HasilRekomendasi hsl = new HasilRekomendasi();
                                    hsl.UserId = userid;
                                    hsl.ProgramId = a.Id;
                                    _context.HasilRekomendasis.Add(hsl);
                                    _context.SaveChanges();
                                }
                            }
                           
                        }
                        if (info.LenganTricep == true)
                        {
                            var listprog = prog.Where(a => a.LenganTricep == true).ToList();
                            foreach (var a in listprog)
                            {
                                var ads = _context.HasilRekomendasis.Where(x => x.UserId == userid && x.ProgramId == a.Id).ToList();
                                if (ads.Count() == 0)
                                {
                                    HasilRekomendasi hsl = new HasilRekomendasi();
                                    hsl.UserId = userid;
                                    hsl.ProgramId = a.Id;
                                    _context.HasilRekomendasis.Add(hsl);
                                    _context.SaveChanges();
                                }
                            }
                            
                        }
                       
                        if (info.Punggung == true)
                        {
                            var listprog = prog.Where(a => a.Punggung == true).ToList();
                            foreach (var a in listprog)
                            {
                                var ads = _context.HasilRekomendasis.Where(x => x.UserId == userid && x.ProgramId == a.Id).ToList();
                                if (ads.Count() == 0)
                                {
                                    HasilRekomendasi hsl = new HasilRekomendasi();
                                    hsl.UserId = userid;
                                    hsl.ProgramId = a.Id;
                                    _context.HasilRekomendasis.Add(hsl);
                                    _context.SaveChanges();
                                }
                            }
                            
                        }
                        _context.SaveChanges();

                    }
                    else
                    {
                        var prog = _context.HasilRekomendasis.Where(x => x.UserId == exist).ToList();
                        foreach(var a in prog)
                        {
                            HasilRekomendasi hsl = new HasilRekomendasi();
                            hsl.UserId = userid;
                            hsl.ProgramId = a.ProgramId;
                            _context.HasilRekomendasis.Add(hsl);

                        }
                        _context.SaveChanges();
                    }
                   

                }
                catch
                {
                    return View();
                }
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult EditUserInfo(UserInfo info)
        {
            
                try
                {
                    var userid = User.Identity.GetUserId();
                    var userDB = _context.UserInfo.FirstOrDefault(x => x.UserId == userid);
                  
                   
                   
                    userDB.BeratBadan = info.BeratBadan;
                    userDB.Punggung = info.Punggung;
                    userDB.Perut = info.Perut;
                   
                    userDB.LenganTricep = info.LenganTricep;
                    userDB.LenganBicep = info.LenganBicep;
                    userDB.Kaki = info.Kaki;
                    userDB.Dada = info.Dada;
                    userDB.Bokong = info.Bokong;
                    userDB.Bahu = info.Bahu;
                    userDB.Tingkatan = info.Tingkatan;
                    userDB.TinggiBadan = info.TinggiBadan;
                   
                    userDB.tanggal_update = DateTime.Now;
                    int tinggi = (info.TinggiBadan / 100) * (info.TinggiBadan / 100);
                    int berat = info.BeratBadan;
                    int calBMI = berat / tinggi;
                    if (calBMI < 19)
                    {
                        userDB.BMI = "Underweight";
                    }
                    else if (calBMI >= 19 && calBMI <= 24)
                    {
                        userDB.BMI = "Normal";
                    }
                    else if (calBMI > 24)
                    {
                        userDB.BMI = "Overweight";
                    }

                    _context.SaveChanges();


                    DateTime Now = DateTime.Today;
                    int umur = Now.Year - info.tanggal_lahir.Year;

                    var exist = "a";
                    if (umur <= 25)
                    {
                        var nnull = _context.UserInfo.Where(a => a.UserId != userid && a.tanggal_lahir.Year - Now.Year >= -25 && a.JenisKelamin == info.JenisKelamin && a.Punggung == info.Punggung && a.Perut == info.Perut && a.LenganBicep == info.LenganBicep && a.LenganTricep == info.LenganTricep && a.Kaki == info.Kaki && a.Dada == info.Dada && a.Bokong == info.Bokong && a.Bahu == info.Bahu && a.BMI == userDB.BMI).ToList();
                        if (nnull.Count() > 0)
                        {
                            exist = _context.UserInfo.FirstOrDefault(a => a.UserId != userid && a.tanggal_lahir.Year - Now.Year >= -25 && a.JenisKelamin == info.JenisKelamin && a.Punggung == info.Punggung && a.Perut == info.Perut && a.LenganBicep == info.LenganBicep && a.LenganTricep == info.LenganTricep && a.Kaki == info.Kaki && a.Dada == info.Dada && a.Bokong == info.Bokong && a.Bahu == info.Bahu && a.BMI == userDB.BMI).UserId;
                        }
                    }
                    else if (umur > 25 && umur <= 45)
                    {
                        var nnull = _context.UserInfo.Where(a => a.UserId != userid & a.tanggal_lahir.Year - Now.Year < -25 && a.tanggal_lahir.Year - Now.Year >= -45 && a.JenisKelamin == info.JenisKelamin && a.Punggung == info.Punggung && a.Perut == info.Perut && a.LenganBicep == info.LenganBicep && a.LenganTricep == info.LenganTricep && a.Kaki == info.Kaki && a.Dada == info.Dada && a.Bokong == info.Bokong && a.Bahu == info.Bahu && a.BMI == userDB.BMI).ToList();
                        if (nnull.Count() > 0)
                        {
                            exist = _context.UserInfo.FirstOrDefault(a => a.UserId != userid & a.tanggal_lahir.Year - Now.Year < -25 && a.tanggal_lahir.Year - Now.Year >= -45 && a.JenisKelamin == info.JenisKelamin && a.Punggung == info.Punggung && a.Perut == info.Perut && a.LenganBicep == info.LenganBicep && a.LenganTricep == info.LenganTricep && a.Kaki == info.Kaki && a.Dada == info.Dada && a.Bokong == info.Bokong && a.Bahu == info.Bahu && a.BMI == userDB.BMI).UserId;
                        }
                    }
                    else
                    {
                        var nnull = _context.UserInfo.Where(a => a.UserId != userid & a.tanggal_lahir.Year - Now.Year < -45 && a.JenisKelamin == info.JenisKelamin && a.Punggung == info.Punggung && a.Perut == info.Perut && a.LenganBicep == info.LenganBicep && a.LenganTricep == info.LenganTricep && a.Kaki == info.Kaki && a.Dada == info.Dada && a.Bokong == info.Bokong && a.Bahu == info.Bahu && a.BMI == userDB.BMI).ToList();
                        if (nnull.Count() > 0)
                        {
                            exist = _context.UserInfo.FirstOrDefault(a => a.UserId != userid & a.tanggal_lahir.Year - Now.Year < -45 && a.JenisKelamin == info.JenisKelamin && a.Punggung == info.Punggung && a.Perut == info.Perut && a.LenganBicep == info.LenganBicep && a.LenganTricep == info.LenganTricep && a.Kaki == info.Kaki && a.Dada == info.Dada && a.Bokong == info.Bokong && a.Bahu == info.Bahu && a.BMI == userDB.BMI).UserId;
                        }
                    }


                    var rec = _context.HasilRekomendasis.Where(x => x.UserId == userid).ToList();
                    foreach (var k in rec)
                    {
                        _context.HasilRekomendasis.Remove(k);
                        _context.SaveChanges();
                    }

                    if (exist == "a")
                    {
                        var prog = _context.JenisPrograms.Where(x => x.JenisKelamin == info.JenisKelamin && x.Tingkatan == info.Tingkatan || x.JenisKelamin == "Unisex" && x.Tingkatan == info.Tingkatan).ToList();
                        if (info.Bahu == true)
                        {
                            var listprog = prog.Where(a => a.Bahu == true).ToList();
                            foreach (var a in listprog)
                            {
                                HasilRekomendasi hsl = new HasilRekomendasi();
                                hsl.UserId = userid;
                                hsl.ProgramId = a.Id;
                                _context.HasilRekomendasis.Add(hsl);
                                _context.SaveChanges();
                            }

                        }
                        if (info.Bokong == true)
                        {
                            var listprog = prog.Where(a => a.Bokong == true).ToList();
                            foreach (var a in listprog)
                            {
                                var ads = _context.HasilRekomendasis.Where(x => x.UserId == userid && x.ProgramId == a.Id).ToList();
                                if (ads.Count() == 0)
                                {
                                    HasilRekomendasi hsl = new HasilRekomendasi();
                                    hsl.UserId = userid;
                                    hsl.ProgramId = a.Id;
                                    _context.HasilRekomendasis.Add(hsl);
                                    _context.SaveChanges();
                                }
                            }

                        }
                        if (info.Perut == true)
                        {
                            var listprog = prog.Where(a => a.Perut == true).ToList();
                            foreach (var a in listprog)
                            {
                                var ads = _context.HasilRekomendasis.Where(x => x.UserId == userid && x.ProgramId == a.Id).ToList();
                                if (ads.Count() == 0)
                                {
                                    HasilRekomendasi hsl = new HasilRekomendasi();
                                    hsl.UserId = userid;
                                    hsl.ProgramId = a.Id;
                                    _context.HasilRekomendasis.Add(hsl);
                                    _context.SaveChanges();
                                }
                            }

                        }
                        if (info.Dada == true)
                        {
                            var listprog = prog.Where(a => a.Dada == true).ToList();
                            foreach (var a in listprog)
                            {
                                var ads = _context.HasilRekomendasis.Where(x => x.UserId == userid && x.ProgramId == a.Id).ToList();
                                if (ads.Count() == 0)
                                {
                                    HasilRekomendasi hsl = new HasilRekomendasi();
                                    hsl.UserId = userid;
                                    hsl.ProgramId = a.Id;
                                    _context.HasilRekomendasis.Add(hsl);
                                    _context.SaveChanges();
                                }
                            }

                        }

                        if (info.Kaki == true)
                        {
                            var listprog = prog.Where(a => a.Kaki == true).ToList();
                            foreach (var a in listprog)
                            {
                                var ads = _context.HasilRekomendasis.Where(x => x.UserId == userid && x.ProgramId == a.Id).ToList();
                                if (ads.Count() == 0)
                                {
                                    HasilRekomendasi hsl = new HasilRekomendasi();
                                    hsl.UserId = userid;
                                    hsl.ProgramId = a.Id;
                                    _context.HasilRekomendasis.Add(hsl);
                                    _context.SaveChanges();
                                }
                            }

                        }
                        if (info.LenganBicep == true)
                        {
                            var listprog = prog.Where(a => a.LenganBicep == true).ToList();
                            foreach (var a in listprog)
                            {
                                var ads = _context.HasilRekomendasis.Where(x => x.UserId == userid && x.ProgramId == a.Id).ToList();
                                if (ads.Count() == 0)
                                {
                                    HasilRekomendasi hsl = new HasilRekomendasi();
                                    hsl.UserId = userid;
                                    hsl.ProgramId = a.Id;
                                    _context.HasilRekomendasis.Add(hsl);
                                    _context.SaveChanges();
                                }
                            }

                        }
                        if (info.LenganTricep == true)
                        {
                            var listprog = prog.Where(a => a.LenganTricep == true).ToList();
                            foreach (var a in listprog)
                            {
                                var ads = _context.HasilRekomendasis.Where(x => x.UserId == userid && x.ProgramId == a.Id).ToList();
                                if (ads.Count() == 0)
                                {
                                    HasilRekomendasi hsl = new HasilRekomendasi();
                                    hsl.UserId = userid;
                                    hsl.ProgramId = a.Id;
                                    _context.HasilRekomendasis.Add(hsl);
                                    _context.SaveChanges();
                                }
                            }

                        }

                        if (info.Punggung == true)
                        {
                            var listprog = prog.Where(a => a.Punggung == true).ToList();
                            foreach (var a in listprog)
                            {
                                var ads = _context.HasilRekomendasis.Where(x => x.UserId == userid && x.ProgramId == a.Id).ToList();
                                if (ads.Count() == 0)
                                {
                                    HasilRekomendasi hsl = new HasilRekomendasi();
                                    hsl.UserId = userid;
                                    hsl.ProgramId = a.Id;
                                    _context.HasilRekomendasis.Add(hsl);
                                    _context.SaveChanges();
                                }
                            }

                        }
                        _context.SaveChanges();

                    }
                    else
                    {
                        var prog = _context.HasilRekomendasis.Where(x => x.UserId == exist).ToList();
                        foreach (var a in prog)
                        {
                            HasilRekomendasi hsl = new HasilRekomendasi();
                            hsl.UserId = userid;
                            hsl.ProgramId = a.ProgramId;
                            _context.HasilRekomendasis.Add(hsl);

                        }
                        _context.SaveChanges();
                    }


                }
                catch
                {
                    return View();
                }
            
            return RedirectToAction("Index", "Home");
        }
    }
}