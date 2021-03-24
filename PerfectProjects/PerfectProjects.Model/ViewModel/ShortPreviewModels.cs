using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectProjects.Model.ViewModel
{
    public class ShortPreviewModels
    {
        public int SkipCounter { get; set; }
        public IEnumerable<ShortPreviewModel> shortPreviewModels { get; set; }

        public ShortPreviewModels()
        {
            SkipCounter = 0;
        }
    }
}
