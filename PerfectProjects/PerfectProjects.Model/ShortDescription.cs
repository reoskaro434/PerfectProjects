using System;
using System.Collections.Generic;
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
        [Required]
        public int UserId { get; set; }

        [Required]
        [MaxLength(80)]
        public string Title { get; set; }

        [Required]
        [MaxLength(400)]
        public string Description { get; set; }

        [Required]
        [MaxLength(83886080)]
        public byte[] Image { get; set; }
    }
}
