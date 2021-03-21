using PerfectProjects.DataAccess.RepositoryPattern.Content.Class;
using PerfectProjects.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectProjects.DataAccess.RepositoryPattern.Content.Interfaces
{
    public interface IShortDescriptionRepository :IRepository<ShortDescription>
    {
        public IEnumerable<ShortDescription> TakeRequiredRows(int skip, int amount);
    }
}
