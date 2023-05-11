using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DECommerce.Models
{
    public class UserRole
    {
        [Key]
        public int UserRoleID { get; set; }
        public int RoleID { get; set; }
        public int UserID { get; set; }


        //--------------------------------------------------Relazioni Tra Tabelle----------------------------------------------------------------------
        public Users Users { get; set; }//relazione con tabella User 1 a 1 

        public Roles Roles { get; set; }//relazione con tabella role
    }
}
