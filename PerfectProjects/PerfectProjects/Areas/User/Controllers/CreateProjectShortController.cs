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
using Microsoft.AspNetCore.Http;
using PerfectProjects.Utility;

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
        [HttpPost]
        public IActionResult Create(ShortDescription Model)
        {
            string id = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var currentUser = _unitOfWork.ApplicationUsers.Find(predicate => predicate.Id == id).ToArray();

            if (Model.Id == 0)
            {
              if(HttpContext.Request.Form.Files.Count>0)
                Model.Image = ImageManager.ConvertToByteArray(HttpContext.Request.Form.Files[0]);
                Model.UserId = id;
                if (ModelState.IsValid)
                {
                    _unitOfWork.ShortDescriptions.Add(Model);
                    _unitOfWork.Save();
                    _unitOfWork.ShortDescriptions.Reload(Model);
                 
                   ShortPreviewModel shortDescriptionModel = new ShortPreviewModel();
                    shortDescriptionModel.ShortDescription = Model;

                    shortDescriptionModel.NickName = currentUser[0].NickName;
                    shortDescriptionModel.ImageString = ImageManager.ConvertToString(Model.Image);

                    return View("ShortPreview", shortDescriptionModel);
                }
            }
            else
            {
                _unitOfWork.ShortDescriptions.Update(Model);
                _unitOfWork.Save();
                ShortPreviewModel shortDescriptionModel = new ShortPreviewModel();
                shortDescriptionModel.ShortDescription = Model;

                shortDescriptionModel.NickName = currentUser[0].NickName;
                shortDescriptionModel.ImageString = ImageManager.ConvertToString(Model.Image);
                return View("ShortPreview", shortDescriptionModel);
            }
            return View();
        }
        [HttpPost]
        public IActionResult Edit(int id)
        {
           ShortDescription shortDescription = _unitOfWork.ShortDescriptions.Find(predicate => predicate.Id == id).FirstOrDefault();
            shortDescription.Image = Array.Empty<byte>();
            return View("Index", _unitOfWork.ShortDescriptions.Find(predicate => predicate.Id == id).FirstOrDefault());
        }

        [HttpPost]
        public IActionResult RedirectToLongDescription()
        {
        
           return View("LongDescription");
          
        }
    }
}
