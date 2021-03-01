using Microsoft.AspNetCore.Mvc;
using PerfectProjects.DataAccess.Data;
using PerfectProjects.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PerfectProjects.Areas.User.Controllers
{
    [Area("User")]
    public class CreateProjectShortController : Controller
    {
        private ApplicationDbContext _db;
        public CreateProjectShortController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ShortPreview()//could be not necessary
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ShortDescription Model)
        {
            var tmpFiles = HttpContext.Request.Form.Files;
            Stream stream = tmpFiles[0].OpenReadStream();
            MemoryStream memStream = new MemoryStream();
            stream.CopyTo(memStream);
            Model.Image = memStream.ToArray();
            
            if (ModelState.IsValid)
            {
                _db.Add(Model);
                _db.SaveChanges();
            }
            return View("ShortPreview",Model);
        }
    }
}
