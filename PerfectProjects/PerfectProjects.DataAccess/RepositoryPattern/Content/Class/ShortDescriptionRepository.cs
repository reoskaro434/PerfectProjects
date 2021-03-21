using PerfectProjects.DataAccess.Data;
using PerfectProjects.DataAccess.RepositoryPattern.Content.Interfaces;
using PerfectProjects.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectProjects.DataAccess.RepositoryPattern.Content.Class
{
    public class ShortDescriptionRepository : Repository<ShortDescription>, IShortDescriptionRepository
    {
        public ShortDescriptionRepository(ApplicationDbContext db):base(db)
        {
        }

        public IEnumerable<ShortDescription> TakeRequiredRows(int skip, int amount)
        {
           return _db.ShortDescriptions.Skip(skip).Take(amount);
        }
    }
}
