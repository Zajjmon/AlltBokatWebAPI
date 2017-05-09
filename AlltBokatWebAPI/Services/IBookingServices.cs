using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using AlltBokatWebAPI.Models;
using static AlltBokatWebAPI.Services.DTOs.BookingDTOs;

namespace AlltBokatWebAPI.Services
{
    public interface IBookingServices : IDisposable
    {
        
        Task<SingleBookingDTO> DeleteSingleBooking(int bookingId, string userId);
        Task<BookingRequestDTO> UpdateSingleBooking(int inputId, BookingRequestDTO bookingRequest);
        
        Task<SingleBookingDTO> GetSingleBooking(int inputId);
        Task<List<SingleBookingDTO>> GetListOfBookings();
        Task<List<SingleBookingDTO>> GetListOfBookingByApplicationUserId(string Id);

        Task<BookingRequestDTO> AddBookingRequest(BookingRequestDTO input);

        Task<List<SingleBookingDTO>> GetListOfUnapprovedBookingsByUserId(string Id);

        Task<SingleBookingDTO> PutApproveBooking(int Id);



    }
}