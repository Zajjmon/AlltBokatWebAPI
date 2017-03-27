using AlltBokatWebAPI.Models;
using AlltBokatWebAPI.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AlltBokatWebAPI.Services.DTOs;
using System.Threading.Tasks;
using AlltBokatWebAPI.DAL;

namespace AlltBokatWebAPI.Services
{
    public class BookingServices : BookingServicesBase, IBookingServices
    {

        private IBookingRepository bookingRepository;

        public BookingServices()
        {
            this.bookingRepository = new BookingRepository(new ApplicationDbContext());
        }

        public BookingServices(IBookingRepository bookingRepository)
        {
            this.bookingRepository = bookingRepository;
        }




        public async Task<BookingDTOs.BookingRequestDTO> AddBookingRequest(BookingDTOs.BookingRequestDTO input)
        {
            //ConvertBookingRequestDTOtoBookingModels(input);
            
          var bookingModel = await bookingRepository.PostBookingModels(ConvertBookingRequestDTOtoBookingModels(input));
          var retur = ConvertBookingModelstoBookingRequestDTO(bookingModel);
                return retur;
            

        }

        public async Task<BookingDTOs.SingleBookingDTO> DeleteSingleBooking(int inputId)
        {
            var bookingModel = await bookingRepository.DeleteBookingModels(inputId);
            var retur = ConvertBookingModelToSingleBookingDTO(bookingModel);
            return retur;
            
        }

        public void Dispose()
        {
            bookingRepository.Dispose();
        }

        public async Task<List<BookingDTOs.SingleBookingDTO>> GetListOfBookingByApplicationUserId(string Id)
        {
            var listOfBookings = await bookingRepository.GetBookingsByApplicationUserId(Id);
            var retur = ConvertListOfBookingModelsToListOfBookingsDTO(listOfBookings);
            return retur;
        }

        public async Task<List<BookingDTOs.SingleBookingDTO>> GetListOfBookings()
        {
            var listOfBookings = await bookingRepository.GetAllBookings();
            var retur = ConvertListOfBookingModelsToListOfBookingsDTO(listOfBookings);
            return retur;
            
        }

        public async Task<BookingDTOs.SingleBookingDTO> GetSingleBooking(int inputId)
        {
            var bookingModel = await bookingRepository.GetBookingModelByIdAsync(inputId);
            var retur = ConvertBookingModelToSingleBookingDTO(bookingModel);
                return retur;
            
        }

        public async Task<BookingDTOs.BookingRequestDTO> UpdateSingleBooking(int inputId, BookingDTOs.BookingRequestDTO bookingRequest)
        {
            
            var updatedBookingModel = await bookingRepository.PutBookingModels(inputId, ConvertBookingRequestDTOtoBookingModels(bookingRequest));
            var retur = ConvertBookingModelstoBookingRequestDTO(updatedBookingModel);
            return retur;
            
        }


    }
}