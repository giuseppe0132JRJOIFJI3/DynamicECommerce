using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DECommerce.Models
{
    public class Users
    {
        [Key]
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string? Field1 { get; set; }//il punto interrogativo perche sono dei campi che possono essere anche null
        public string? Field2 { get; set; }
        public DateTime? Field3 { get; set; }
        public int? Field4 { get; set; }
        public int? Field5 { get; set; }
        public int? Field6 { get; set; }


        //--------------------------------------------------Relazioni Tra Tabelle----------------------------------------------------------------------

        public List<UserRole> UserRole { get; set; }//relazione con UserRole table
        public List<Orders> Orders { get; set; }// relazione con tabella orders

    }
}
