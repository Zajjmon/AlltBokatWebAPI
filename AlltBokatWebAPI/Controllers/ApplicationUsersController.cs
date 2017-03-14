using AlltBokatWebAPI.DAL;
using AlltBokatWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using static AlltBokatWebAPI.Models.ViewModels.ApplicationUserViewModels;


namespace AlltBokatWebAPI.Controllers
{
    public class ApplicationUsersController : ApiController
    {

        private IApplicationUserRepository ApplicationUserRepository;

        public ApplicationUsersController()
        {
            this.ApplicationUserRepository = new ApplicationUserRepository(new ApplicationDbContext());
        }










        // GET: api/ApplicationUsers
        public async Task <List<ApplicationUserInfoViewModel>> Get()
        {
            List<ApplicationUserInfoViewModel> userList =await  ApplicationUserRepository.GetApplicationUserNames();

            return userList;
        }

        // GET: api/ApplicationUsers/5
        public async Task <ApplicationUser> Get(string id)
        {

            string userName =  await ApplicationUserRepository.GetApplicationUserNameById(id);
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
