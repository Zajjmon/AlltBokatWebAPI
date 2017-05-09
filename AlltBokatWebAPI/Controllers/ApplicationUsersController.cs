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
        public async Task<IHttpActionResult> Get()
        {

            return Ok(await ApplicationUserService.GetAllApplicationUsersPersonInfo());
        }

        // GET: api/ApplicationUsers/5 
        //Returns a users info including id
        [ResponseType(typeof(List<ApplicationUserPersonInfoDTO>))]
        public async Task<IHttpActionResult> Get(string id)
        {


            return Ok(await ApplicationUserService.GetApplicationUserPersonInfoById(id));
        }

        //GET: api/ApplicationUsers/BookingWithinTimeRange/2012-08-17T20!16/2012-03-12T20!16
        //Returns all users with a booking within the two Datetimes provided.
        
        [Route("api/BookingWithinTimeRange/{startTime}/{endTime}")]
        [ResponseType(typeof(List<ApplicationUserPersonInfoDTO>))]
        public async Task<IHttpActionResult> GetWithinTimeRange(string startTime, string endTime)
        {

            DateTime startTimeFinished = DateTime.Parse(startTime.Replace("!", ":"));
            DateTime endTimeFinished = DateTime.Parse(endTime.Replace("!", ":"));

            return Ok(await ApplicationUserService.GetUsersWithBookingWithinTimeRange(startTimeFinished, endTimeFinished));
        }

        //GET: api/ApplicationUsers/BookingNOTWithinTimeRange/2012-08-17T20!16/2012-03-12T20!16
        //Returns all users whom does NOT have a booking within the two provided Datetimes.
        [Route("api/BookingNOTWithinTimeRange/{startTime}/{endTime}")]
        [ResponseType(typeof(List<ApplicationUserPersonInfoDTO>))]
        public async Task<IHttpActionResult> GetNOTWithinTimeRange(string startTime, string endTime)
        {

          

            DateTime startTimeFinished = DateTime.Parse(startTime.Replace("!", ":"));
            DateTime endTimeFinished = DateTime.Parse(endTime.Replace("!", ":"));


            return Ok(await ApplicationUserService.GetUsersWithBookingNOTWithinTimeRange(startTimeFinished, endTimeFinished));
        }

       


    }
}
