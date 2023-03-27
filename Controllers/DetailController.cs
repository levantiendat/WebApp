﻿using Microsoft.AspNetCore.Mvc;
using WebApp1.Models;
using WebApp1.Models.Entities;


namespace WebApp1.Controllers
{
    public class DetailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> DetailIndex()
        {
            DbhocphanContext DB = new DbhocphanContext();
            var s = DB.Lophps.Select(p => new Show001
            {
                MALOPHOCPHAN = Convert.ToString(p.Mahocphan) + "." + p.Hocki + "." + p.Khoahoc + "." + p.Nhomlophp,
                TENLOP = Convert.ToString(p.MahocphanNavigation.Namehp),
                TC = Convert.ToDouble(p.MahocphanNavigation.Tinchi),
                GV = p.MagvNavigation.Namegv,
                TKB = p.Tkb,
                week = p.Tuanhoc,
                SL = Convert.ToInt32(p.Sl),
                DK = Convert.ToInt32(p.Dk),
                ndb = Convert.ToInt32(p.NumDubi),
                db = Convert.ToInt32(p.Dubi),
                clc = Convert.ToBoolean(p.Clc),

            }).ToList();
            return View(s);
        }
    }
}
