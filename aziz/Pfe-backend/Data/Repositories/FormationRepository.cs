using Domain.Entities;
using Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class FormationRepository : RepositoryBase<Formation>, IFormationRepository
    {
        public FormationRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {
        }

    }
    public interface IFormationRepository : IRepository<Formation> { }

}
