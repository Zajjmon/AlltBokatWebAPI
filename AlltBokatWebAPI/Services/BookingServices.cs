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
            
         
          return ConvertBookingModelstoBookingRequestDTO(await bookingRepository.PostBookingModels(ConvertBookingRequestDTOtoBookingModels(input)));
               
            

        }

        public async Task<BookingDTOs.SingleBookingDTO> DeleteSingleBooking(int bookingId, string userId)
        {
            
            return ConvertBookingModelToSingleBookingDTO(await bookingRepository.DeleteBookingModels(bookingId, userId));
            
        }

        public void Dispose()
        {
            bookingRepository.Dispose();
        }

        public async Task<List<BookingDTOs.SingleBookingDTO>> GetListOfBookingByApplicationUserId(string Id)
        {
           
            return ConvertListOfBookingModelsToListOfBookingsDTO(await bookingRepository.GetBookingsByApplicationUserId(Id));
        }

        public async Task<List<BookingDTOs.SingleBookingDTO>> GetListOfBookings()
        {
            return ConvertListOfBookingModelsToListOfBookingsDTO(await bookingRepository.GetAllBookings());
            
        }

        public async Task<BookingDTOs.SingleBookingDTO> GetSingleBooking(int inputId)
        {
            return ConvertBookingModelToSingleBookingDTO(await bookingRepository.GetBookingModelByIdAsync(inputId));
                
            
        }

        public async Task<List<BookingDTOs.SingleBookingDTO>> GetListOfUnapprovedBookingsByUserId(string Id)
        {
            return ConvertListOfBookingModelsToListOfBookingsDTO(await bookingRepository.GetUnapprovedBookingsByUserId(Id));
        }

        public async Task<BookingDTOs.BookingRequestDTO> UpdateSingleBooking(int inputId, BookingDTOs.BookingRequestDTO bookingRequest)
        {
            
            return ConvertBookingModelstoBookingRequestDTO(await bookingRepository.PutBookingModels(inputId, ConvertBookingRequestDTOtoBookingModels(bookingRequest)));
            
            
        }

        public async Task<BookingDTOs.SingleBookingDTO> PutApproveBooking(int Id)
        {
            return ConvertBookingModelToSingleBookingDTO(await bookingRepository.PutApproveBooking(Id));
        }
    }
}