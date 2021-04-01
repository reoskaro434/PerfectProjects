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

        public IEnumerable<string> LongDescriptions { get; set; }

        [MaxLength(83886080)]
        public IEnumerable<byte[]> Images { get; set; }

        public ShortDescription ShortDescription { get; set; }
    }
}

