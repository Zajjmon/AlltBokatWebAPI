using AlltBokatWebAPI.DAL;
using AlltBokatWebAPI.Models;
using AlltBokatWebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using static AlltBokatWebAPI.Models.ViewModels.ApplicationUserViewModels;
using static AlltBokatWebAPI.Services.DTOs.ApplicationUserDTOs;

namespace AlltBokatWebAPI.Controllers
{
    public class ApplicationUsersController : ApiController
    {

        
        private IApplicationUserServices ApplicationUserService;

        public ApplicationUsersController()
        {
           
            this.ApplicationUserService = new ApplicationUserServices();
        }










        // GET: api/ApplicationUsers
        //Returns a list of users with Id
        [ResponseType(typeof(List<ApplicationUserPersonInfoDTO>))]
        public async Task<IHttpActionResult>Get()
        {
            
            return Ok(await ApplicationUserService.GetAllApplicationUsersPersonInfo());
        }

        // GET: api/ApplicationUsers/5 
        //Returns a users info including id
        public async Task<IHttpActionResult>Get(string id)
        {
              

            return Ok(await ApplicationUserService.GetApplicationUserPersonInfoById(id)); 
        }

        //GET: api/ApplicationUsers/BookingWithinTimeRange
        //Returns all users with a booking within the two Datetimes provided.
        [Route("BookingWithinTimeRange")]
        [ResponseType(typeof(List<ApplicationUserPersonInfoDTO>))]
        public async Task<IHttpActionResult>GetWithinTimeRange(DateTime startTime, DateTime endTime)
        {
            return Ok(await ApplicationUserService.GetUsersWithBookingWithinTimeRange(startTime, endTime));
        }

        //GET: api/ApplicationUsers/BookingNOTWithinTimeRange
        //Returns all users whom does NOT have a booking within the two provided Datetimes.
        [Route("BookingNOTWithinTimeRange")]
        [ResponseType(typeof(List<ApplicationUserPersonInfoDTO>))]
        public async Task<IHttpActionResult> GetNOTWithinTimeRange(DateTime startTime, DateTime endTime)
        {
            return Ok(await ApplicationUserService.GetUsersWithBookingNOTWithinTimeRange(startTime, endTime));
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
