using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectProjects.Model
{
    public class ShortDescription
    {
        [Key]
        public int Id { get; set; }
     
        [ForeignKey("UserId")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [MaxLength(80)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [MaxLength(400)]
        public string Description { get; set; }

        [MaxLength(83886080)]
        public byte[] Image { get; set; }

        [DefaultValue("False")]
        public bool IsVisible { get; set; }
    }
}
