using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Cours")]
    public  class Cours
    {[Key]
        public int? id_cours { get; set; }
        public string Titre { get; set; }
        public string Sprécialite { get; set; }
        public string Description { get; set; }
        public string Fichier { get; set; }
    }
}
