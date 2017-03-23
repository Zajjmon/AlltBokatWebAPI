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
using static AlltBokatWebAPI.Models.ViewModels.BookingViewModels;

namespace AlltBokatWebAPI.DAL
{
    public class BookingRepository : IBookingRepository, IDisposable
    {
        public class bookingdto
        {
            public int bookingId { get; set; }
            public string description { get; set; }
            public DateTime startTime { get; set; }
            public string UserId { get; set; }



        }

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
            BookingTimeSlotModels bookingTimeSlotModel = await context.BookingTimeSlots.FindAsync(bookingModels.BookingTimeSlotModelsId);
            if (bookingModels == null)
                return null;

            context.Bookings.Remove(bookingModels);
            context.BookingTimeSlots.Remove(bookingTimeSlotModel);
            await context.SaveChangesAsync();
            return bookingModels;

        }
        public IQueryable <BookingModels> getbookingdto()
        {
            var bookingdtos = context.Bookings
                           .Where(p => p.description == "asd")
                           .Select(p => new BookingModels()
                           {
                               Id = p.Id,
                               description = p.description,
                               BookingTimeSlotModels = p.BookingTimeSlotModels,
                               ApplicationUserId = p.ApplicationUser.Id,
                               ApplicationUser = new ApplicationUser()
                               {
                                   FirstName  = p.ApplicationUser.FirstName,
                                   LastName = p.ApplicationUser.LastName
                                   
                               }
                               
                               
                               
                               

                           });

            return bookingdtos;
        }

        public async Task<BookingModels> GetBookingModelByIdAsync(int id)
        {
            BookingModels bookingModels = await context.Bookings.FindAsync(id);

            return bookingModels;
        }

        

       
           //Returns all bookings
        public IQueryable<BookingInfoViewModelWithId> GetBookings()
        {

            
            List<BookingInfoViewModelWithId> BookingListWithoutNavProp = new List<BookingInfoViewModelWithId>();
            try
            {
                using (context)
                {

                    IQueryable<BookingModels> bookings = context.Bookings.AsQueryable(); 
                    BookingListWithoutNavProp = BookingServices.ConvertToBookingWithoutNavProps(bookings);

                }
                return BookingListWithoutNavProp.AsQueryable();
            }
            catch (DbUpdateException)
            {
                return null;
                throw;
            }
        }


        public async Task<BookingInfoViewModelWithId> GetSingleBooking(int id)
        {
            var bookingModel = await context.Bookings.FindAsync(id);
            var singleBooking = BookingServices.ConvertToSingleBookingInfoViewModelWithId(bookingModel);
            return singleBooking;

        }



        public async Task<BookingModels> PostBookingModels(BookingRequest bookingRequest)
        {

            
            var booking = bookingRequest.BookingModel;
          //  var timeSlot = bookingRequest.BookingTimeSlotModel;

            try
            {
                //context.BookingTimeSlots.Add(timeSlot);

                //await context.SaveChangesAsync();
                //booking.BookingTimeSlotModelsId = timeSlot.Id;

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




        //Returns a list of bookingsWithOutNavProp depending on aplication user
        public IQueryable<BookingInfoViewModelWithId> GetBookingsByApplicationUserId(string IdByParameter)
        {
            List<BookingInfoViewModelWithId> BookingListWithoutNavProp = new List<BookingInfoViewModelWithId>();
            try
            {
                using (context)
            {
                
                    IQueryable<BookingModels> bookings = context.Bookings.Where(b => b.ApplicationUserId == IdByParameter).AsQueryable();
                    BookingListWithoutNavProp = BookingServices.ConvertToBookingWithoutNavProps(bookings);

                }
            return BookingListWithoutNavProp.AsQueryable();
            }
             catch (DbUpdateException)
            {
                return null;
                throw;
            }
        }






















    }
}