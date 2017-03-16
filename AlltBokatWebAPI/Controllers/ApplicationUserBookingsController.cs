using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using AlltBokatWebAPI.Models;
using AlltBokatWebAPI.DAL;
using AlltBokatWebAPI.Models.ViewModels;


namespace AlltBokatWebAPI.Controllers
{
    public class ApplicationUserBookingsController : ApiController
    {
        private IBookingRepository bookingRepository;

        public ApplicationUserBookingsController()
        {
            this.bookingRepository = new BookingRepository(new ApplicationDbContext());
        }

        public ApplicationUserBookingsController(IBookingRepository bookingRepository)
        {
            this.bookingRepository = bookingRepository;
        }



        //tex: api/ApplicationUserBookings/14290799-13b1-4985-9a72-3fc6666cbfdb Returns the bookings thats connected to a Applicationuser

        public IQueryable<BookingWithoutNavProp> GetBookingModelsByUserId(string Id)
        {
            IQueryable<BookingWithoutNavProp> BookingWithoutNavPropList = bookingRepository.GetBookingsByApplicationUserId(Id);
            return BookingWithoutNavPropList;

        }









        protected override void Dispose(bool disposing)
        {
            bookingRepository.Dispose();
            base.Dispose(disposing);
        }



      





        

    }
}