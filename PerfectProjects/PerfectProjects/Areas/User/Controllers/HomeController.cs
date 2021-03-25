using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PerfectProjects.DataAccess.RepositoryPattern;
using PerfectProjects.Model;
using PerfectProjects.Model.ViewModel;
using PerfectProjects.Utility;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace PerfectProjects.Controllers
{
    [Area("User")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IUnitOfWork _unitOfWork;
        private const int _projectsPerPage = SD.PROJECT_PER_PAGE;
        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View(GetAccessibleShortPreviews(0));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult ClickedNextButton(int SkipCounter)
        {
            ShortPreviewModels shortPreviewModels = new ShortPreviewModels();
            shortPreviewModels = GetAccessibleShortPreviews(SkipCounter + _projectsPerPage);
            if (shortPreviewModels.shortPreviewModels.Count() <= 0)
                shortPreviewModels = GetAccessibleShortPreviews(SkipCounter);
            return View("Index", shortPreviewModels);
        }
        public IActionResult ClickedBackButton(int SkipCounter)
        {
            if (SkipCounter - _projectsPerPage >= 0)
            {
                ShortPreviewModels shortPreviewModels = new ShortPreviewModels();
                shortPreviewModels = GetAccessibleShortPreviews(SkipCounter - _projectsPerPage);

                return View("Index", shortPreviewModels);
            }

            return View("Index", GetAccessibleShortPreviews(SkipCounter));
        }
        private ShortPreviewModels GetAccessibleShortPreviews(int skipCounter)
        {
            //short description
            IEnumerable<ShortDescription> shortDescriptions = _unitOfWork.ShortDescriptions.TakeRequiredRows(skipCounter, _projectsPerPage);
            //users info
            IEnumerable<ApplicationUser> applicationUsers = _unitOfWork.ApplicationUsers.GetAll();

            List<ShortPreviewModel> previewModels = new List<ShortPreviewModel>();

            foreach (ShortDescription element in shortDescriptions)
            {
                var user = _unitOfWork.ApplicationUsers.Find(x => x.Id == element.UserId).FirstOrDefault();//user's id is unique
                if (user != null)
                {
                    var shortPrevModel = new ShortPreviewModel
                    {
                        ShortDescription = element,
                        NickName = user.NickName,
                        ImageString = ImageManager.ConvertToString(element.Image),
                    };
                    previewModels.Add(shortPrevModel);
                }
                else return null; //smth wrong, returns null
            }

            var shortPrevievModels = new ShortPreviewModels();
            shortPrevievModels.shortPreviewModels = previewModels;
            shortPrevievModels.SkipCounter = skipCounter;
          

            return shortPrevievModels;
        }
       
    }
}
