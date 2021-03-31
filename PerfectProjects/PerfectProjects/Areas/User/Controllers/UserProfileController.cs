using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PerfectProjects.DataAccess.RepositoryPattern;
using PerfectProjects.Model;
using PerfectProjects.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PerfectProjects.Areas.User.Controllers
{
    [Area("User")]
    public class UserProfileController : Controller
    {
        IUnitOfWork _unitOfWork;
        SignInManager<IdentityUser> _signInManager;

        private UserProfileViewModel _getProfileViewModel()
        {
            UserProfileViewModel userProfileViewModel = new UserProfileViewModel();
            string id = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            userProfileViewModel.ShortDescriptions = _unitOfWork.ShortDescriptions.Find(predicate => predicate.UserId == id);
            userProfileViewModel.AboutMe = "This is a static information about user. Please, enlarge user's proporties and download it from db.";
            userProfileViewModel.Nickname = _unitOfWork.ApplicationUsers.Find(predicate => predicate.Id == id).FirstOrDefault().NickName;

            return userProfileViewModel;
        }
        public UserProfileController(SignInManager<IdentityUser> SignInManager, IUnitOfWork UnitOfWork)
        {
            _unitOfWork = UnitOfWork;
            _signInManager = SignInManager;
        }

        public IActionResult Index()
        {
            if (_signInManager.IsSignedIn(User))
                return View(_getProfileViewModel());
            return View();
        }
        public IActionResult ChangeVisibleToFalse(int shortDescriptionId)
        {
          var description = _unitOfWork.ShortDescriptions.Find(p => p.Id == shortDescriptionId).FirstOrDefault();
            if (description != null)
            {
                description.IsVisible = false;
                _unitOfWork.ShortDescriptions.Update(description);
                _unitOfWork.Save();
                if (_signInManager.IsSignedIn(User))
                    return View("Index", _getProfileViewModel());
            }
            return View("Index");
        }
        public IActionResult ChangeVisibleToTrue(int shortDescriptionId)
        {
            var description = _unitOfWork.ShortDescriptions.Find(p => p.Id == shortDescriptionId).FirstOrDefault();
            if (description != null)
            {
                description.IsVisible = true;
                _unitOfWork.ShortDescriptions.Update(description);
                _unitOfWork.Save();
                if (_signInManager.IsSignedIn(User))
                    return View("Index", _getProfileViewModel());
            }
            
            return View("Index");
        }
    }
}
