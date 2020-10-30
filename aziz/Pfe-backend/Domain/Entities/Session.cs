using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Session")]
    public  class Session
    {
        
       [Key]
       // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_sess { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime date_debut { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime date_fin { get; set; }
        public string titre { get; set; }
        [DataType(DataType.MultilineText)]

        public string description { get; set; }
        virtual public List<Formation> formations { get; set; }

    }
}
