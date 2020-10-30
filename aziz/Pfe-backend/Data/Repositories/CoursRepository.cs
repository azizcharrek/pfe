using Domain.Entities;
using Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class CoursRepository : RepositoryBase<Cours>, ICoursRepository
    {
        public CoursRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {
        }

    }
    public interface ICoursRepository : IRepository<Cours>
    {

    }

}
