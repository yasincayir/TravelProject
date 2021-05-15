﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelProject.Models.Siniflar;
namespace TravelProject.Controllers
{
    public class BlogController : Controller
    {
        // GET: Bog
        Context c = new Context();
        BlogYorum by = new BlogYorum();
        public ActionResult Index()
        {
            //var bloglar = c.Blogs.ToList();
            by.Deger1 = c.Blogs.ToList();
            by.Deger3 = c.Blogs.OrderByDescending(x => x.ID).Take(3).ToList();
            return View(by);
        }
 
        public ActionResult BlogDetay(int id)
        {
            //var blogbul = c.Blogs.Where(i => i.ID == id).ToList();
            by.Deger1 = c.Blogs.Where(i => i.ID == id).ToList();
            by.Deger2 = c.Yorumlars.Where(i => i.BlogID == id).ToList();
            return View(by);
        }
        [HttpGet]
        public PartialViewResult YorumYap(int id)
        {
            ViewBag.deger = id;
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult YorumYap(Yorumlar y)
        {
            c.Yorumlars.Add(y);
            c.SaveChanges();
            return PartialView();
        }
    }
}