using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlltBokatWebAPI.Models;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using AlltBokatWebAPI.Services;

namespace AlltBokatWebAPI.DAL
{
    public class BookingRepository : IBookingRepository, IDisposable
    {


        private ApplicationDbContext context;


        public BookingRepository(ApplicationDbContext context)
        {
            this.context = context;

        }


        public async Task<BookingModels> DeleteBookingModels(int bookingId, string userId)
        {
            BookingModels bookingModels = await context.Bookings.FindAsync(bookingId);
            BookingTimeSlotModels bookingtimeslot = bookingModels.BookingTimeSlotModels;
            if (bookingModels == null)
                return null;
            if (!bookingModels.ApplicationUserId.Equals(userId))
                return null;

            context.Bookings.Remove(bookingModels);
            context.BookingTimeSlots.Remove(bookingtimeslot);
            await context.SaveChangesAsync();
            return bookingModels;

        }


        public async Task<BookingModels> GetBookingModelByIdAsync(int id)
        {


            var a = await (from p in context.Bookings
                           where p.Id == id
                           select new
                           {
                               id = p.Id,
                               customerName = p.CustomerName,
                               customerEmail = p.CustomerEmail,
                               description = p.description,
                               bookingTimeSlotModelId = p.BookingTimeSlotModelsId,
                               bookingTimeSlotModel = p.BookingTimeSlotModels,
                               ApplicationUserId = p.ApplicationUser.Id,
                               Approved = p.Approved,
                               ApplicationUser = new
                               {
                                   FirstName = p.ApplicationUser.FirstName,
                                   LastName = p.ApplicationUser.LastName
                               }
                           }).ToListAsync();


            return (a.Select(x => new BookingModels
            {
                Id = x.id,
                description = x.description,
                CustomerEmail = x.customerEmail,
                CustomerName = x.customerName,
                Approved = x.Approved,
                ApplicationUserId = x.ApplicationUserId,
                ApplicationUser = new ApplicationUser { FirstName = x.ApplicationUser.FirstName, LastName = x.ApplicationUser.LastName },
                BookingTimeSlotModelsId = x.bookingTimeSlotModelId,
                BookingTimeSlotModels = x.bookingTimeSlotModel
            }).FirstOrDefault());
        }

        public async Task<List<BookingModels>> GetAllBookings()
        {


            var a = await (from p in context.Bookings

                           select new
                           {
                               id = p.Id,
                               customerName = p.CustomerName,
                               customerEmail = p.CustomerEmail,
                               description = p.description,
                               approved = p.Approved,
                               bookingTimeSlotModelId = p.BookingTimeSlotModelsId,
                               bookingTimeSlotModel = p.BookingTimeSlotModels,

                               UserFirstName = p.ApplicationUser.FirstName,
                               ApplicationUserId = p.ApplicationUser.Id,
                               ApplicationUser = new
                               {
                                   FirstName = p.ApplicationUser.FirstName,
                                   LastName = p.ApplicationUser.LastName
                               }
                           }).ToListAsync();


            return (a.Select(x => new BookingModels
            {
                Id = x.id,
                description = x.description,
                CustomerEmail = x.customerEmail,
                Approved = x.approved,
                CustomerName = x.customerName,
                ApplicationUserId = x.ApplicationUserId,
                ApplicationUser = new ApplicationUser { FirstName = x.ApplicationUser.FirstName, LastName = x.ApplicationUser.LastName },

                
                BookingTimeSlotModelsId = x.bookingTimeSlotModelId,
                BookingTimeSlotModels = x.bookingTimeSlotModel
            }).ToList());


        }


        public async Task<BookingModels> PostBookingModels(BookingModels bookingRequest)
        {

            try
            {


                context.Bookings.Add(bookingRequest);
                await context.SaveChangesAsync();

                return bookingRequest;

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

        public async Task<BookingModels> PutApproveBooking(int id)
        {

            var approvedBooking = await context.Bookings.FindAsync(id);
            approvedBooking.Approved = true;
            context.Entry(approvedBooking).Property(x => x.Approved).IsModified = true;
            try
            {

                await context.SaveChangesAsync();
                return approvedBooking;
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





        public async Task<List<BookingModels>> GetBookingsByApplicationUserId(string Id)
        {


            var a = await (from p in context.Bookings
                           where p.ApplicationUserId == Id
                           select new
                           {
                               id = p.Id,
                               customerName = p.CustomerName,
                               customerEmail = p.CustomerEmail,
                               description = p.description,
                               bookingTimeSlotModelId = p.BookingTimeSlotModelsId,
                               bookingTimeSlotModel = p.BookingTimeSlotModels,
                               Approved = p.Approved,
                               ApplicationUserId = p.ApplicationUser.Id,
                               ApplicationUser = new
                               {
                                   FirstName = p.ApplicationUser.FirstName,
                                   LastName = p.ApplicationUser.LastName
                               }
                           }).ToListAsync();


            return (a.Select(x => new BookingModels
            {
                Id = x.id,
                description = x.description,
                CustomerEmail = x.customerEmail,
                CustomerName = x.customerName,
                Approved = x.Approved,
                ApplicationUserId = x.ApplicationUserId,
                ApplicationUser = new ApplicationUser { FirstName = x.ApplicationUser.FirstName, LastName = x.ApplicationUser.LastName },
                BookingTimeSlotModelsId = x.bookingTimeSlotModelId,
                BookingTimeSlotModels = x.bookingTimeSlotModel
            }).ToList());

        }

        public async Task<List<BookingModels>> GetUnapprovedBookingsByUserId(string id)
        {
            var a = await (from p in context.Bookings
                           where p.ApplicationUserId == id && p.Approved == false
                           select new
                           {
                               id = p.Id,
                               customerName = p.CustomerName,
                               customerEmail = p.CustomerEmail,
                               description = p.description,
                               bookingTimeSlotModelId = p.BookingTimeSlotModelsId,
                               bookingTimeSlotModel = p.BookingTimeSlotModels,

                               ApplicationUserId = p.ApplicationUser.Id,
                               ApplicationUser = new
                               {
                                   FirstName = p.ApplicationUser.FirstName,
                                   LastName = p.ApplicationUser.LastName
                               }
                           }).ToListAsync();


            return (a.Select(x => new BookingModels
            {
                Id = x.id,
                description = x.description,
                CustomerEmail = x.customerEmail,
                CustomerName = x.customerName,
                ApplicationUserId = x.ApplicationUserId,
                ApplicationUser = new ApplicationUser { FirstName = x.ApplicationUser.FirstName, LastName = x.ApplicationUser.LastName },
                BookingTimeSlotModelsId = x.bookingTimeSlotModelId,
                BookingTimeSlotModels = x.bookingTimeSlotModel
            }).ToList());
        }
    }
}