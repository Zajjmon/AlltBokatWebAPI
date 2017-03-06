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

namespace AlltBokatWebAPI.Controllers
{
    public class BookingModelsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/BookingModels
        public IQueryable<BookingModels> GetBookings()
        {
            return db.Bookings;
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
        [ResponseType(typeof(BookingModels))]
        public async Task<IHttpActionResult> PostBookingModels(BookingModels bookingModels, DateTime StartTime, DateTime EndTime)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            BookingTimeSlotModels TimeSloten = new BookingTimeSlotModels();
            TimeSloten.startTime = StartTime;
            TimeSloten.endTime = EndTime;

            bookingModels.bookingTimeSlot = TimeSloten;
            try
            { 
            db.Bookings.Add(bookingModels);
            await db.SaveChangesAsync();
                






            db.Bookings.Add(bookingModels);
            ApplicationUser user = new ApplicationUser();
            var userid = user.Id;
            
          

                

            }
            catch (DbUpdateException)
            {                                     // fungerar denna OR-operand??
                if (BookingModelsExists(bookingModels.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
                
            }

            return CreatedAtRoute("DefaultApi", new { id = bookingModels.Id }, bookingModels);
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
            return db.BookingTimeSlots.Count(e => e.bookingTimeSlotId == id) > 0;
        }
        private void SendBookingNotificationMail(BookingModels bookingModels, BookingTimeSlotModels bookingTimeSlotModels)
        {
            //MailTestKlass Mail = new MailTestKlass();
            //Users.GetApplicationUserbyId(bookingModels.)
            //Mail.sendmail(bookingModels.CustomerEmail, bookingModels.CustomerName, bookingModels.ApplicationUser.) // TO DO
        }
    }
}