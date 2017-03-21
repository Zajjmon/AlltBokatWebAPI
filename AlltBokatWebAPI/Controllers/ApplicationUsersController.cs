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








        //public async Task<List<ApplicationUserInfoViewModelWhithId>> GetGetUsersWithBookingWithinTimeRange(DateTime startTime, DateTime endTime)
        //{
        //    var asd = await ApplicationUserRepository.GetUsersWithBookingWithinTimeRange(startTime, endTime);
        //    var dsa = 
        //}

        // GET: api/ApplicationUsers
        //Returns a list of users with Id
        public async Task <List<ApplicationUserInfoViewModelWhithId>> Get()
        {
            
            return await ApplicationUserRepository.GetApplicationUserNames();
        }

        // GET: api/ApplicationUsers/5 
        //Returns a users info including id
        public async Task <ApplicationUserInfoViewModelWhithId> Get(string id)
        {
              

            return await ApplicationUserRepository.GetApplicationUserInfoById(id); ;
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
