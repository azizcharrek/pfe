using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
   public class FormationConfiguration:EntityTypeConfiguration<Formation>
    {
        public FormationConfiguration()
        {
               HasOptional(p => p.session).WithMany(c => c.formations).HasForeignKey(p => p.id_form).WillCascadeOnDelete(false);
        }
    }
}
