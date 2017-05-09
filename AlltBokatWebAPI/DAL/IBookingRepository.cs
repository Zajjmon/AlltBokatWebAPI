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
        Task<List<BookingModels>> GetAllBookings();
        Task<BookingModels> GetBookingModelByIdAsync(int id);
        Task<BookingModels> PutBookingModels(int id, BookingModels bookingModels);
        Task<BookingModels> PostBookingModels(BookingModels BookingRequest);
        Task<BookingModels> DeleteBookingModels(int bookingId, string userId);
        Task<List<BookingModels>> GetBookingsByApplicationUserId(string Id);
        Task<List<BookingModels>> GetUnapprovedBookingsByUserId(string id);
        Task<BookingModels> PutApproveBooking(int id);
       

    }
}