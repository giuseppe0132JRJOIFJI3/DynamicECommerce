﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DECommerce.Models
{
    public class Roles
    {
        [Key]
        public int RoleID { get; set; }
        public string? Field1 { get; set; }


        //--------------------------------------------------Relazioni Tra Tabelle----------------------------------------------------------------------

        public List<UserRole> UserRole { get; set; }//relazione con tabella UserRole
    }
}
