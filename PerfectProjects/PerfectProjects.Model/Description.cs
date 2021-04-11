using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectProjects.Model
{
    public class Description
    {

        [Key]
        public int Id { get; set; }
        public string LongDescription { get; set; }

        [MaxLength(83886080)]
        public byte[] Image1 { get; set; }
        [MaxLength(83886080)]
        public byte[] Image2 { get; set; }
        [MaxLength(83886080)]
        public byte[] Image3 { get; set; }
        [MaxLength(83886080)]
        public byte[] Image4 { get; set; }
        public ShortDescription ShortDescription { get; set; }
    }
}

