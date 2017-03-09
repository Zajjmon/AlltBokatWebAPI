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
    public class BookingModelsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/BookingModels
        public IQueryable<BookingWithoutNavProp> GetBookings()
        {
            List<BookingWithoutNavProp> bookingList = BookingDAL.GetAllBookingsWithoutNavProps();

            IQueryable<BookingWithoutNavProp> bookingListan = bookingList.AsQueryable();
            return bookingListan;
            //return db.Bookings.AsQueryable();
        }

        // GET: api/BookingModels/5
        [ResponseType(typeof(BookingModels))]
        public async Task<IHttpActionResult> GetBookingModels(int id)
        {
            BookingModels bookingModels = await db.Bookings.FindAsync(id);
            if (bookingModels == null)
            {
                return NotFound();
            }

            return Ok(bookingModels);
        }

        // PUT: api/BookingModels/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBookingModels(int id, BookingModels bookingModels)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bookingModels.Id)
            {
                return BadRequest();
            }

            db.Entry(bookingModels).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingModelsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/BookingModels
        [ResponseType(typeof(BookingWithTimeViewModel))]
        public async Task<IHttpActionResult> PostBookingModels(BookingWithTimeViewModel BookingRequest)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //var bookingTest = new BookingModels();

            //bookingTest.ApplicationUserId = "3196ceac-7cb4-4ac1-8b16-cd0c0f12dd12";
            //bookingTest.BookingTimeSlotModelsId = 4;
            //bookingTest.CustomerEmail = "zajjmon01@gmail.com";
            //bookingTest.CustomerName = "Simon";
            //bookingTest.description = "test description";
            //bookingTest.Id = 15;
            //bookingTest.BookingTimeSlotModels = db.BookingTimeSlots.Find(4);
            //bookingTest.ApplicationUser = db.Users.Find("3196ceac-7cb4-4ac1-8b16-cd0c0f12dd12");

            
            //db.Bookings.Add(bookingTest);
            //await db.SaveChangesAsync();
            


            var booking = BookingRequest.BookingModel;
            var timeSlot = BookingRequest.BookingTimeSlotModel;
            
            
            
            try
            { 
            db.BookingTimeSlots.Add(timeSlot);

            await db.SaveChangesAsync();
                booking.BookingTimeSlotModelsId = timeSlot.Id;
                



            db.Bookings.Add(booking);
                await db.SaveChangesAsync();

            }
            catch (DbUpdateException)
            {                                     
                if (BookingModelsExists(booking.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
                
            }

            return CreatedAtRoute("DefaultApi", new { id = booking.Id }, booking);
        }

        // DELETE: api/BookingModels/5
        [ResponseType(typeof(BookingModels))]
        public async Task<IHttpActionResult> DeleteBookingModels(int id)
        {
            BookingModels bookingModels = await db.Bookings.FindAsync(id);
            if (bookingModels == null)
            {
                return NotFound();
            }

            db.Bookings.Remove(bookingModels);
            await db.SaveChangesAsync();

            return Ok(bookingModels);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BookingModelsExists(int id)
        {
            return db.Bookings.Count(e => e.Id == id) > 0;
        }
        private bool BookingTimeModelsExists(int id)
        {
            return db.BookingTimeSlots.Count(e => e.Id == id) > 0;
        }
        private void SendBookingNotificationMail(BookingModels bookingModels, BookingTimeSlotModels bookingTimeSlotModels)
        {
            //MailTestKlass Mail = new MailTestKlass();
            //Users.GetApplicationUserbyId(bookingModels.)
            //Mail.sendmail(bookingModels.CustomerEmail, bookingModels.CustomerName, bookingModels.ApplicationUser.) // TO DO
        }
    }
}