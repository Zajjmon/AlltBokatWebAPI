using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using AlltBokatWebAPI.Models;
using AlltBokatWebAPI.Models.ViewModels;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using AlltBokatWebAPI.DAL.Services;

namespace AlltBokatWebAPI.DAL
{
    public class BookingRepository : IBookingRepository, IDisposable
    {

        private ApplicationDbContext context;
        private BookingServices BookingServices;

        public BookingRepository(ApplicationDbContext context)
        {
            this.context = context;
            BookingServices = new BookingServices();
        }

        public async Task<BookingModels> DeleteBookingModels(int id)
        {
            BookingModels bookingModels = await context.Bookings.FindAsync(id);
            if (bookingModels == null)
                return null;

            context.Bookings.Remove(bookingModels);
            await context.SaveChangesAsync();
            return bookingModels;

        }

        public async Task<BookingModels> GetBookingModelByIdAsync(int id)
        {
            BookingModels bookingModels = await context.Bookings.FindAsync(id);

            return bookingModels;
        }

        public IQueryable<BookingWithoutNavProp> GetBookings()
        {

            return BookingDAL.GetAllBookingsWithoutNavProps();
        }

        public async Task<BookingModels> PostBookingModels(BookingRequest bookingRequest)
        {
            var booking = bookingRequest.BookingModel;
            var timeSlot = bookingRequest.BookingTimeSlotModel;

            try
            {
                context.BookingTimeSlots.Add(timeSlot);

                await context.SaveChangesAsync();
                booking.BookingTimeSlotModelsId = timeSlot.Id;

                context.Bookings.Add(booking);
                await context.SaveChangesAsync();

                return booking;

            }
            catch (DbUpdateException)
            {
                return null;
                throw;
            }


        }

        public async Task<BookingModels> PutBookingModels(int id, BookingModels bookingModels)
        {

            context.Entry(bookingModels).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
                return bookingModels;
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }




        //Returns a list of bookingsWithOutNavProp 
        public IQueryable<BookingWithoutNavProp> GetBookingsByApplicationUserId(string IdByParameter)
        {
            List<BookingWithoutNavProp> BookingListWithoutNavProp = new List<BookingWithoutNavProp>();

            using (context)
            {


                IQueryable<BookingModels> bookings = context.Bookings.Where(b => b.ApplicationUserId == IdByParameter).AsQueryable();
                BookingListWithoutNavProp = BookingServices.ConvertToBookingWithoutNavProps(bookings);



            }
            return BookingListWithoutNavProp.AsQueryable();

        }






















    }
}