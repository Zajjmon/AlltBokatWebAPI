using AlltBokatWebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using static AlltBokatWebAPI.Services.DTOs.BookingDTOs;

namespace AlltBokatWebAPI.Controllers
{
    public class BookingsByApplicationUserController : ApiController
    {
        private BookingServices bookingServices;


        public BookingsByApplicationUserController()
        {
            bookingServices = new BookingServices();
        }


        // GET: api/BookingsByApplicationUser/558763930303hfy33hh22
        [ResponseType(typeof(List<SingleBookingDTO>))]
        public async Task<IHttpActionResult> GetBookingByApplicationUserId(string id)
        {
            List<SingleBookingDTO> bookingList = await bookingServices.GetListOfBookingByApplicationUserId(id);

            return Ok(bookingList);

        }

        protected override void Dispose(bool disposing)
        {
            bookingServices.Dispose();
            base.Dispose(disposing);
        }

    }
}
