using ImageServiceCoreMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ImageServiceCoreMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult UploadImage()
        {
            ImageServiceDb obj = new ImageServiceDb();
            return View(obj);
        }

        [HttpPost]
        public IActionResult UploadImage(IFormFile postedFile)
        {
            byte[] bytes;
            using (BinaryReader reader = new BinaryReader(postedFile.OpenReadStream()))
            {
                bytes = reader.ReadBytes((int)postedFile.Length);
            }

            ImageServiceDb image = new ImageServiceDb()
            {
                Name = postedFile.FileName,
                Data = bytes,
                ImageType = postedFile.ContentType
            };
            PersonalDbContext db = new PersonalDbContext();
            db.ImageServiceDbs.Add(image);
            db.SaveChanges();
            return RedirectToAction("ViewImages");
        }
        public IActionResult ViewImage(int id)
        {
            PersonalDbContext db = new PersonalDbContext();
            ImageServiceDb obj = db.ImageServiceDbs.Find(id);
            return View(obj);
        }
        public IActionResult ViewImages()
        {
            PersonalDbContext db = new PersonalDbContext();
            List<ImageServiceDb> imageList = new List<ImageServiceDb>();
            imageList = db.ImageServiceDbs.ToList();
            return View(imageList);
        }
    }
}
