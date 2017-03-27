using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using static AlltBokatWebAPI.Services.DTOs.BookingDTOs;

namespace AlltBokatWebAPI.Services
{
    public class BookingValidation
    {
        
        public List<bool> ValidateBookingRequestDTO(BookingRequestDTO input)
        {
            List<bool> boolList = new List<bool>();
            boolList.Add(ValidateCustomerName(input.CustomerName));
            boolList.Add(ValidateCustomerEmail(input.CustomerEmail));
            boolList.Add(ValidateDescription(input.Description));
            boolList.Add(ValidateApplicationUserId(input.ApplicationUserId));
            boolList.Add(ValidateTime(input.StartTime, input.EndTime));

            return boolList;


        }

        public List<bool> ValidateSingleBookingDTO(SingleBookingDTO input)
        {

            
           
            List<bool> boolList = new List<bool>();
            boolList.Add(ValidateTime(input.StartTime, input.EndTime));
            boolList.Add(ValidateCustomerName(input.CustomerName));
            boolList.Add(ValidateCustomerEmail(input.CustomerEmail));
            boolList.Add(ValidateDescription(input.Description));
            boolList.Add(ValidateApplicationUserFirstName(input.ApplicationUserFirstName));
            boolList.Add(ValidateApplicationUserLastName(input.ApplicationUserLastName));

            return boolList;



        }
        
        private bool ValidateApplicationUserFirstName(string input)
        {
            if (String.IsNullOrEmpty(input))
                return false;

            else
                return true;
        }
        private bool ValidateApplicationUserLastName(string input)
        {
            if (String.IsNullOrEmpty(input))
                return false;

            else
                return true;
        }

        private bool ValidateCustomerEmail(string input)
        {
            if (String.IsNullOrEmpty(input))
                return false;

            try
            {
                MailAddress m = new MailAddress(input);
                return true;
            }
            catch(FormatException)
            {
                return false;
            }
            

        }

        private bool ValidateCustomerName(string input)
        {
            if (String.IsNullOrEmpty(input))
                return false;

            else
                return true;

        }
        private bool ValidateDescription(string input)
        {
            if (String.IsNullOrEmpty(input))
                return false;

            else
                return true;
        }

        private bool ValidateTime(DateTime startTime, DateTime endTime)
        {
            
            if (startTime >= endTime)
                return false;
            if (startTime < DateTime.Now)
                return false;
            else
                return true;

        }
        private bool ValidateApplicationUserId(string input)
        {
            if (String.IsNullOrEmpty(input))
                return false;

            else
                return true;

        }

    }
}