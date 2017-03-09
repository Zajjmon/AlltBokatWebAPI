using AlltBokatWebAPI.DAL;
using AlltBokatWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AlltBokatWebAPI.Controllers
{
    public class ApplicationUsersController : ApiController
    {
        // GET: api/ApplicationUsers
        public IEnumerable<string> Get()
        {

          

            return new string[] { "value1", "value2","value3","value4","value5" };
        }

        // GET: api/ApplicationUsers/5
        public ApplicationUser Get(string id)
        {

            string userName = Users.GetApplicationUserNameById(id);
            ApplicationUser usr = new ApplicationUser();
            usr.UserName = userName;

            return usr;
        }

        // POST: api/ApplicationUsers
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ApplicationUsers/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ApplicationUsers/5
        public void Delete(int id)
        {
        }
    }
}
