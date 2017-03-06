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

namespace AlltBokatWebAPI.Controllers
{
    public class BookingTimeSlotModelsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/BookingTimeSlotModels
        public IQueryable<BookingTimeSlotModels> GetBookingTimeSlots()
        {
            return db.BookingTimeSlots;
        }

        // GET: api/BookingTimeSlotModels/5
        [ResponseType(typeof(BookingTimeSlotModels))]
        public async Task<IHttpActionResult> GetBookingTimeSlotModels(int id)
        {
            BookingTimeSlotModels bookingTimeSlotModels = await db.BookingTimeSlots.FindAsync(id);
            if (bookingTimeSlotModels == null)
            {
                return NotFound();
            }

            return Ok(bookingTimeSlotModels);
        }

        // PUT: api/BookingTimeSlotModels/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBookingTimeSlotModels(int id, BookingTimeSlotModels bookingTimeSlotModels)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bookingTimeSlotModels.bookingTimeSlotId)
            {
                return BadRequest();
            }

            db.Entry(bookingTimeSlotModels).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingTimeSlotModelsExists(id))
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

        // POST: api/BookingTimeSlotModels
        [ResponseType(typeof(BookingTimeSlotModels))]
        public async Task<IHttpActionResult> PostBookingTimeSlotModels(BookingTimeSlotModels bookingTimeSlotModels)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BookingTimeSlots.Add(bookingTimeSlotModels);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = bookingTimeSlotModels.bookingTimeSlotId }, bookingTimeSlotModels);
        }

        // DELETE: api/BookingTimeSlotModels/5
        [ResponseType(typeof(BookingTimeSlotModels))]
        public async Task<IHttpActionResult> DeleteBookingTimeSlotModels(int id)
        {
            BookingTimeSlotModels bookingTimeSlotModels = await db.BookingTimeSlots.FindAsync(id);
            if (bookingTimeSlotModels == null)
            {
                return NotFound();
            }

            db.BookingTimeSlots.Remove(bookingTimeSlotModels);
            await db.SaveChangesAsync();

            return Ok(bookingTimeSlotModels);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BookingTimeSlotModelsExists(int id)
        {
            return db.BookingTimeSlots.Count(e => e.bookingTimeSlotId == id) > 0;
        }
    }
}