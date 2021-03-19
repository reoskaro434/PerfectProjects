using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PerfectProjects.DataAccess.RepositoryPattern;
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
        public UserProfileController(SignInManager<IdentityUser> SignInManager, IUnitOfWork UnitOfWork)
        {
            _unitOfWork = UnitOfWork;
            _signInManager = SignInManager;
        }

        public IActionResult Index()
        {
            if (_signInManager.IsSignedIn(User))
            {
                UserProfileViewModel userProfileViewModel = new UserProfileViewModel();
                string id = User.FindFirst(ClaimTypes.NameIdentifier).Value;

                userProfileViewModel.ShortDescriptions = _unitOfWork.ShortDescriptions.Find(predicate => predicate.UserId == id);
                userProfileViewModel.AboutMe = "This is a static information about user. Please, enlarge user's proporties and download it from db.";
                userProfileViewModel.Nickname = _unitOfWork.ApplicationUsers.Find(predicate => predicate.Id == id).FirstOrDefault().NickName;

                return View(userProfileViewModel);
            }
            return View();
        }
    }
}
