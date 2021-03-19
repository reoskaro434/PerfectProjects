using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectProjects.Model.ViewModel
{
    public class UserProfileViewModel
    {
        public string Nickname { get; set; }
        public IEnumerable<ShortDescription> ShortDescriptions { get; set; }
        public string AboutMe { get; set; }
    }
}
