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


        public async Task<BookingModels> DeleteBookingModels(int id)
        {
            BookingModels bookingModels = await context.Bookings.FindAsync(id);
            BookingTimeSlotModels bookingtimeslot = bookingModels.BookingTimeSlotModels;
            if (bookingModels == null)
                return null;

            context.Bookings.Remove(bookingModels);
            context.BookingTimeSlots.Remove(bookingtimeslot);
            await context.SaveChangesAsync();
            return bookingModels;

        }
    

        public async Task<BookingModels> GetBookingModelByIdAsync(int id)
        {
            // gammal lösning som inte fungerade, ligger kvar som referenspunkt
            //var bookingModel = await context.Bookings
            //               .Where(p => p.Id == id)
            //               .Select(p => new 
            //               {
            //                   Id = p.Id,
            //                   description = p.description,
            //                   BookingTimeSlotModels = p.BookingTimeSlotModels,
            //                   ApplicationUserId = p.ApplicationUser.Id,
            //                   ApplicationUser = new ApplicationUser()
            //                   {
            //                       FirstName = p.ApplicationUser.FirstName,
            //                       LastName = p.ApplicationUser.LastName
            //                   }
            //               }).FirstAsync();

            //return bookingModel;

            var asd = await (from p in context.Bookings
                       where p.Id == id
                       select new { id = p.Id,
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
                            }}).ToListAsync();


            return (asd.Select(x => new BookingModels {
                Id = x.id, description = x.description,
                CustomerEmail = x.customerEmail,
                CustomerName = x.customerName,
                ApplicationUserId = x.ApplicationUserId,
                ApplicationUser = new ApplicationUser { FirstName = x.ApplicationUser.FirstName, LastName = x.ApplicationUser.LastName},
                BookingTimeSlotModelsId = x.bookingTimeSlotModelId,
                BookingTimeSlotModels = x.bookingTimeSlotModel
            }).FirstOrDefault());
        }

        public async Task<List<BookingModels>> GetAllBookings()
        {

            // gammal lösning som inte fungerade, liggar kvar som referens
            //var bookingModels = await context.Bookings

            //               .Select(p => new BookingModels()
            //               {
            //                   Id = p.Id,
            //                   description = p.description,
            //                   BookingTimeSlotModels = p.BookingTimeSlotModels,
            //                   ApplicationUserId = p.ApplicationUser.Id,
            //                   ApplicationUser = new ApplicationUser()
            //                   {
            //                       FirstName = p.ApplicationUser.FirstName,
            //                       LastName = p.ApplicationUser.LastName

            //                   }

            //               }).ToListAsync();

            //return bookingModels;
            var asd = await (from p in context.Bookings
                             
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


            return (asd.Select(x => new BookingModels
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
            //var asd = await context.Bookings.FindAsync(id);
            //bookingModels.BookingTimeSlotModels = asd.BookingTimeSlotModels;
            //bookingModels.BookingTimeSlotModelsId = asd.BookingTimeSlotModelsId;
            //bookingModels.ApplicationUser = asd.ApplicationUser;
            //bookingModels.ApplicationUserId = asd.ApplicationUserId;
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
        //public IQueryable<BookingInfoViewModelWithId> GetBookingsByApplicationUserId(string IdByParameter)
        //{
        //    List<BookingInfoViewModelWithId> BookingListWithoutNavProp = new List<BookingInfoViewModelWithId>();
        //    try
        //    {
        //        using (context)
        //    {
                
        //            IQueryable<BookingModels> bookings = context.Bookings.Where(b => b.ApplicationUserId == IdByParameter).AsQueryable();
        //            BookingListWithoutNavProp = BookingServices.ConvertToBookingWithoutNavProps(bookings);

        //        }
        //    return BookingListWithoutNavProp.AsQueryable();
        //    }
        //     catch (DbUpdateException)
        //    {
        //        return null;
        //        throw;
        //    }
        //}

        public async Task<List<BookingModels>> GetBookingsByApplicationUserId(string Id)
        {

            //var bookingModels = await context.Bookings
            //               .Where(p => p.ApplicationUserId == Id)
            //               .Select(p => new BookingModels()
            //               {
            //                   Id = p.Id,
            //                   description = p.description,
            //                   BookingTimeSlotModels = p.BookingTimeSlotModels,
            //                   ApplicationUserId = p.ApplicationUser.Id,
            //                   ApplicationUser = new ApplicationUser()
            //                   {
            //                       FirstName = p.ApplicationUser.FirstName,
            //                       LastName = p.ApplicationUser.LastName

            //                   }

            //               }).ToListAsync();

            //return bookingModels;
            var asd = await (from p in context.Bookings
                             where p.ApplicationUserId == Id
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


            return (asd.Select(x => new BookingModels
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