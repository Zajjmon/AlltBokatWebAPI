using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AlltBokatWebAPI.Models;
using AlltBokatWebAPI.Models.ViewModels;
using System.Threading.Tasks;
using System.Web.Http;

namespace AlltBokatWebAPI.DAL
{
    public interface IBookingRepository : IDisposable
    {
        IQueryable<BookingWithoutNavProp> GetBookings();
        Task<BookingModels> GetBookingModelByIdAsync(int id);
        Task<BookingModels> PutBookingModels(int id, BookingModels bookingModels);
        Task<BookingModels> PostBookingModels(BookingRequest BookingRequest);
        Task<BookingModels> DeleteBookingModels(int id);
        IQueryable<BookingWithoutNavProp> GetBookingsByApplicationUserId(string Id);

    }
}