using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Infrastructure;

namespace Data.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        IEmployeRepository EmployeRepository { get; }
        IFormationRepository FormationRepository { get; }
        IFormateurRepository FormateurRepository { get; }
        ISessionRepository SessionRepository { get; }
        ICoursRepository CoursRepository { get; }
    }

}
