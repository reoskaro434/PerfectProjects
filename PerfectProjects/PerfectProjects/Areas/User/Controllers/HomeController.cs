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
        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View(GetAccessibleShortPreviews());
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

        public ShortPreviewModels GetAccessibleShortPreviews()
        {
            //short description
            IEnumerable<ShortDescription> shortDescriptions = _unitOfWork.ShortDescriptions.GetAll();

            //users info
            IEnumerable<ApplicationUser> applicationUsers = _unitOfWork.ApplicationUsers.GetAll();

            List<ShortPreviewModel> previewModels = new List<ShortPreviewModel>();
            
            foreach (ShortDescription element in shortDescriptions)
            {
               var user = applicationUsers.Where(x => x.Id == element.UserId).FirstOrDefault();//user's id is unique
                if(user != null)
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

            return shortPrevievModels;
        }
    }
}
