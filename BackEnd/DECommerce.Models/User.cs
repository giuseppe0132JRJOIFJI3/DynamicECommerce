using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DECommerce.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string? Username { get; set; }
        public string? PasswordHash { get; set; }

        //public static explicit operator User(Users? v)
        //{
        //    if (v == null) return null;

        //    return new User
        //    {
        //        UserID = v.UserID,
        //        Username = v.Username,
        //        PasswordHash = v.Password
        //        // altre proprietà da copiare
        //    };
        //}
    }
}
