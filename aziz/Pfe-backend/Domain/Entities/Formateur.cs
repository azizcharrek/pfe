using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Formateur")]
    public  class Formateur
    {
        [Key]
        public int? id_formateur { get; set; }
        public string nom { get; set; } 
        public string prenom { get; set; }
        public string Email { get; set; }
        public string image { get; set; }
        public int age { get; set; }
        public string specialite { get; set; }
        public string compagnie { get; set; }
        virtual public List<Employe> Employes { get; set; }

    }
}
