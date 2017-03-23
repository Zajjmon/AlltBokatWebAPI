using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AlltBokatWebAPI.Models;
using AlltBokatWebAPI.Models.ViewModels;
using System.Threading.Tasks;
using System.Web.Http;
using static AlltBokatWebAPI.Models.ViewModels.BookingViewModels;

namespace AlltBokatWebAPI.DAL
{
    public interface IBookingRepository : IDisposable
    {
        IQueryable<BookingInfoViewModelWithId> GetBookings();
        Task<BookingModels> GetBookingModelByIdAsync(int id);
        Task<BookingModels> PutBookingModels(int id, BookingModels bookingModels);
        Task<BookingModels> PostBookingModels(BookingRequest BookingRequest);
        Task<BookingModels> DeleteBookingModels(int id);
        IQueryable<BookingInfoViewModelWithId> GetBookingsByApplicationUserId(string Id);
        Task<BookingInfoViewModelWithId> GetSingleBooking(int id);
        //void Save();

    }
}