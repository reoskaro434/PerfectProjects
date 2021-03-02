using Microsoft.AspNetCore.Mvc;
using PerfectProjects.DataAccess.Data;
using PerfectProjects.DataAccess.RepositoryPattern;
using PerfectProjects.Model;
using PerfectProjects.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace PerfectProjects.Areas.User.Controllers
{
    [Area("User")]
    public class CreateProjectShortController : Controller
    {
        private IUnitOfWork _unitOfWork;
        public CreateProjectShortController(IUnitOfWork UnitOfWork)
        {
            _unitOfWork = UnitOfWork;
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
                //_unitOfWork.ShortDescriptions.Add(Model);
                //_unitOfWork.Save();
                ShortPreviewModel shortDescriptionModel = new ShortPreviewModel();
                shortDescriptionModel.ShortDescription = Model;



                string id = User.FindFirst(ClaimTypes.NameIdentifier).Value;

           


                return View("ShortPreview", shortDescriptionModel);
            }
            return View();
        }
    }
}
