using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using AlltBokatWebAPI.Models;
using static AlltBokatWebAPI.Services.DTOs.BookingDTOs;

namespace AlltBokatWebAPI.Services
{
    public interface IBookingServices
    {
        
        Task<SingleBookingDTO> DeleteSingleBooking(int inputId);
        Task<SingleBookingDTO> UpdateSingleBooking(int inputId);
        
        Task<SingleBookingDTO> GetSingleBooking(BookingRequestDTO input);
        Task<ListOfBookingsDTO> GetListOfBookings(BookingRequestDTO input);
        Task<BookingRequestDTO> AddBookingRequest(int inputId);


        // detta TODO att skapa abstract bas-klass på servicen
        Task<BookingModels> ConvertBookingRequestDTOtoBookingModels(BookingRequestDTO input);
        Task<ListOfBookingsDTO> ConvertListOfBookingModelsToListOfBookingsDTO(IQueryable<BookingModels> input); // TODO kolla hur man konverterar en lista med modeller till en lista med DTO's
        Task<SingleBookingDTO> ConvertBookingModelToSingleBookingDTO(BookingModels input);

    }
}