using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("User")]
    public class User
    {[Key]
        public int UserID { get; set; }
     
        public string FirstName { get; set; }
       
        public string LastName { get; set; }
        [MaxLength(255)]
        public string UserName { get; set; }
        [MaxLength(255)]
        public string Email { get; set; }
        [MaxLength(255)]
        public string Password { get; set; }
        public string Role { get; set; }
        public Boolean EmailConfirmed { get; set; }
        [MaxLength(255)]
        public string Token { get; set; }
        public string image { get; set; }
        public int AccessFailCount { get; set; }
        public Type Type { get; set; }
        public Boolean Enabled { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime LockoutDateUtc { get; set; }
    }
}
