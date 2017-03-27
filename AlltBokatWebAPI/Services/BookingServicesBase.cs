using AlltBokatWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using static AlltBokatWebAPI.Services.DTOs.BookingDTOs;

namespace AlltBokatWebAPI.Services
{
    public abstract class BookingServicesBase
    {

        public virtual  BookingRequestDTO ConvertBookingModelstoBookingRequestDTO(BookingModels input)
        {
            BookingRequestDTO bookingRequest = new BookingRequestDTO()
            {
                Id = input.Id,
                ApplicationUserId = input.ApplicationUserId,
                CustomerEmail = input.CustomerEmail,
                CustomerName = input.CustomerName,
                Description = input.description,
                StartTime = input.BookingTimeSlotModels.startTime,
                EndTime = input.BookingTimeSlotModels.endTime
            };
            return bookingRequest;
        }

        public virtual BookingModels ConvertBookingRequestDTOtoBookingModels(BookingRequestDTO input)
        {
            BookingModels bookingModel =  new BookingModels()
            {
                CustomerName = input.CustomerName,
                CustomerEmail = input.CustomerEmail,
                description = input.Description,
                ApplicationUserId = input.ApplicationUserId,
                BookingTimeSlotModels = new BookingTimeSlotModels()
                {
                    startTime = input.StartTime,
                    endTime = input.EndTime
                }
            };
            return bookingModel;
        }
        
        // TO-DO kolla hur man konverterar en lista med modeller till en lista med DTO's
        public virtual List<SingleBookingDTO> ConvertListOfBookingModelsToListOfBookingsDTO(List<BookingModels> input)
        {
            var ListOfBookingDTOs = new List<SingleBookingDTO>();

            foreach (var item in input)
            {
                ListOfBookingDTOs.Add(ConvertBookingModelToSingleBookingDTO(item));
            }
            return ListOfBookingDTOs;
            
        }
        
        public virtual SingleBookingDTO ConvertBookingModelToSingleBookingDTO(BookingModels input)
        {
            SingleBookingDTO BookingDTO = new SingleBookingDTO()
            {
                Id = input.Id,
                CustomerEmail = input.CustomerEmail,
                CustomerName = input.CustomerName,
                Description = input.description,
                StartTime = input.BookingTimeSlotModels.startTime,
                EndTime = input.BookingTimeSlotModels.endTime,
                ApplicationUserFirstName = input.ApplicationUser.FirstName,
                ApplicationUserLastName = input.ApplicationUser.LastName
                
            };
            return BookingDTO;
        }
        
    }
}