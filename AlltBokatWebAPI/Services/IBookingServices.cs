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
        
        Task<SingleBookingDTO> DeleteSingleBooking(int inputId);
        Task<BookingRequestDTO> UpdateSingleBooking(int inputId, BookingRequestDTO bookingRequest);
        
        Task<SingleBookingDTO> GetSingleBooking(int inputId);
        Task<List<SingleBookingDTO>> GetListOfBookings();
        Task<List<SingleBookingDTO>> GetListOfBookingByApplicationUserId(string Id);

        Task<BookingRequestDTO> AddBookingRequest(BookingRequestDTO input);


        // detta TODO att skapa abstract bas-klass på servicen
        //Task<BookingModels> ConvertBookingRequestDTOtoBookingModels(BookingRequestDTO input);
        //Task<ListOfBookingsDTO> ConvertListOfBookingModelsToListOfBookingsDTO(IQueryable<BookingModels> input); 
        //Task<SingleBookingDTO> ConvertBookingModelToSingleBookingDTO(BookingModels input);

    }
}