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
using static AlltBokatWebAPI.Models.ViewModels.BookingViewModels;
using AlltBokatWebAPI.Services;

namespace AlltBokatWebAPI.Controllers
{
    public class BookingModelsController : ApiController
    {
        private IBookingRepository bookingRepository;
        private MailServices Mailservices;
        private ApplicationUserRepository applicationUserRepository;


        public BookingModelsController()
        {
            this.bookingRepository = new BookingRepository(new ApplicationDbContext());
            this.Mailservices = new MailServices();
            applicationUserRepository = new ApplicationUserRepository(new ApplicationDbContext());
        }

        public BookingModelsController(IBookingRepository bookingRepository)
        {
            this.bookingRepository = bookingRepository;
        }

        // GET: api/BookingModels

        public IQueryable<BookingInfoViewModelWithId> GetBookings()
        {

            return bookingRepository.GetBookings();

        }



        // GET: api/BookingModels/5
        [ResponseType(typeof(BookingInfoViewModelWithId))]
        public async Task<IHttpActionResult> GetBookingModels(int id)
        {
            var singleBooking = await bookingRepository.GetSingleBooking(id);

            return Ok(singleBooking);

            ////BookingModels bookingModels = await db.Bookings.FindAsync(id);
            //BookingModels bookingModels = await bookingRepository.GetBookingModelByIdAsync(id);

            //if (bookingModels == null)
            //{
            //    return NotFound();
            //}

            //return Ok(bookingModels);
        }

        // PUT: api/BookingModels/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBookingModels(int id, BookingModels bookingModels)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            BookingModels bookingModel = await bookingRepository.PutBookingModels(id, bookingModels);

            return Ok(bookingModel);
        }

        // POST: api/BookingModels
        [ResponseType(typeof(BookingRequest))]
        public async Task<IHttpActionResult> PostBookingModels(BookingRequest bookingRequest)
        {


            BookingModels booking = await bookingRepository.PostBookingModels(bookingRequest);
            if (booking != null)
            {
                MailModels mailModel = new MailModels();
                ApplicationUserViewModels.ApplicationUserInfoViewModelWhithId user = await applicationUserRepository.GetApplicationUserInfoById(booking.ApplicationUserId);
                mailModel.ToEmail = booking.CustomerEmail;
                mailModel.ToName = booking.CustomerName;

                mailModel.ApplicationUserFirstName = user.FirstName;
                mailModel.ApplicationUserLastName = user.LastName;
                mailModel.StartTime = booking.BookingTimeSlotModels.startTime.ToString();
                await Mailservices.NotifyBookingByMail(mailModel);
            }



            return CreatedAtRoute("DefaultApi", new { id = booking.Id }, booking);


        }

        // DELETE: api/BookingModels/5
        [ResponseType(typeof(BookingModels))]
        public async Task<IHttpActionResult> DeleteBookingModels(int id)
        {


            BookingModels bookingModels = await bookingRepository.DeleteBookingModels(id);
            if (bookingModels == null)
            {
                return NotFound();
            }

            return Ok(bookingModels);
        }

        protected override void Dispose(bool disposing)
        {
            bookingRepository.Dispose();
            base.Dispose(disposing);
        }



        private void SendBookingNotificationMail(BookingModels bookingModels, BookingTimeSlotModels bookingTimeSlotModels)
        {
            //MailTestKlass Mail = new MailTestKlass();
            //Users.GetApplicationUserbyId(bookingModels.)
            //Mail.sendmail(bookingModels.CustomerEmail, bookingModels.CustomerName, bookingModels.ApplicationUser.) // TO DO
        }
    }
}