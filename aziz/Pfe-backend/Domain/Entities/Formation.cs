using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Foramtion")]
    public  class Formation
    {
        [Key]
        
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_form { get; set; }
        public string titre { get; set; }
        public string specialite { get; set; }
        public string description { get; set; }
        public int duree { get; set; }
        public int date_debut { get; set; }
        public int date_fin { get; set; }
        public int nbr_part { get; set; }
        public string certification { get; set; }
        [DataType(DataType.Currency)]
        public float prix { get; set; }
        [ForeignKey("sess")]
        virtual public Session session { get; set; }
        virtual public Cours Cours { get; set; }
        public int? sess { get; set; }
        virtual public List<Employe> Employes { get; set; }
        virtual public List<Formateur> Formateurs { get; set; }

    }

}
