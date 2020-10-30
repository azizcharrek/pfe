using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private PfeContext dataContext;
        IDatabaseFactory dbFactory;
        public UnitOfWork(IDatabaseFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }
        private IEmployeRepository employeRepository;
        public IEmployeRepository EmployeRepository
        {
            get { return employeRepository = new EmployeRepository(dbFactory); }
        }
        private ICoursRepository coursRepository;
        public ICoursRepository CoursRepository
        {
            get { return coursRepository = new CoursRepository(dbFactory); }
        }
        private IFormationRepository formationRepository;
        public IFormationRepository FormationRepository
        {
            get { return formationRepository = new FormationRepository(dbFactory); }
        }
        private IFormateurRepository formateurRepository;
        public IFormateurRepository FormateurRepository
        {
            get { return formateurRepository = new FormateurRepository(dbFactory); }
        }
        private ISessionRepository sessionRepository;
        public ISessionRepository SessionRepository
        {
            get { return sessionRepository = new SessionRepository(dbFactory); }
        }
        protected PfeContext DataContext
        {
            get
            {
                return dataContext = dbFactory.DataContext;
            }
        }
        public void Commit()
        {
            DataContext.SaveChanges();
        }
        public void Dispose()
        {
            dbFactory.Dispose();
        }
    }

}
