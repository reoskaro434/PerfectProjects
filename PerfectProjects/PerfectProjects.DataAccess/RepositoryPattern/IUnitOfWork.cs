using PerfectProjects.DataAccess.RepositoryPattern.Content.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectProjects.DataAccess.RepositoryPattern
{
    public interface IUnitOfWork : IDisposable
    {
        IShortDescriptionRepository ShortDescriptions { get; }
        IApplicationUserRepository ApplicationUsers { get; }
        int Save();
    }
}
