using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerfectProjects.Areas.User.Controllers
{
    [Area("User")]
    public class CreateProjectController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
