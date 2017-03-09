using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AlltBokatWebAPI.Models;

namespace AlltBokatWebAPI.DAL
{
    public static class Users
    {
        public static string GetApplicationUserNameById(string id)
        {
            using (var db = new ApplicationDbContext())
            {
                ApplicationUser u = new ApplicationUser();
                u = db.Users.Find(id);
                string usrName = u.UserName;
                return usrName;
            }
        }

        public static string GetApplicationUserNamesById(string id)
        {
            using (var db = new ApplicationDbContext())
            {
                ApplicationUser u = new ApplicationUser();
                u = db.Users.Find(id);
                string usrName = u.UserName;
                return usrName;
            }
        }





    }
}