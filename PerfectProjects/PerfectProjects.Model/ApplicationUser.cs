using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectProjects.Model
{
    public class ApplicationUser : IdentityUser
    {    
        [Required]
        [MaxLength(50)]
        public string NickName { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        [NotMapped]
        public string Role { get; set; }
    }
}
