using Domain.Entities;
using Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class EmployeRepository : RepositoryBase<Employe>, IEmployeRepository
    {
        public EmployeRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {
        }

    }
    public interface IEmployeRepository : IRepository<Employe>
    {
        
    }

}
