using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{[Table("Employe")]
    public class Employe
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? id_emp { get; set; }
        
        public string prenom { get; set; }
        public string nom { get; set; }
        public string Email { get; set; }
       // public byte[] photo { get; set; }
        public int cin { get; set; }
        public string adress { get; set; }
        //[Column(TypeName = "image")]
        public string image { get; set; }
        public Type type { get; set; }//BIATOS Ense ...
        public string departement { get; set; } // dsi
        public string specialite { get; set; }//dev
        public int forma { get; set; }
        public DateTime date_de_naissance { get; set; }
        public string Password { get; set; }
        virtual public Formation formation { get; set; }

      
    }
}
