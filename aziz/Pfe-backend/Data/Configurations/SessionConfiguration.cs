using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
  public  class SessionConfiguration:EntityTypeConfiguration<Session>
    {
        public SessionConfiguration()
        {
            ToTable("Session");
            HasKey(c => c.id_sess);
            Property(c => c.titre).HasMaxLength(50).IsRequired();
        }
    }
}
