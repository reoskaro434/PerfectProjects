using PerfectProjects.DataAccess.Data;
using PerfectProjects.DataAccess.RepositoryPattern.Content.Class;
using PerfectProjects.DataAccess.RepositoryPattern.Content.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectProjects.DataAccess.RepositoryPattern
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public IShortDescriptionRepository ShortDescriptions { get; private set; }

        public IApplicationUserRepository ApplicationUsers { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            ShortDescriptions = new ShortDescriptionRepository(db);
            ApplicationUsers = new ApplicationUserRepository(db);
        }
        public int Save()
        {
            return _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
