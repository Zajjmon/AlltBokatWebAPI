using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AlltBokatWebAPI.Models;

namespace AlltBokatWebAPI.DAL
{
    public static class Users
    {
        public static ApplicationUser GetApplicationUserbyId(string id)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Users.Find(id);
            }
        }
    }
}