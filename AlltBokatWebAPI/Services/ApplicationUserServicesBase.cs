using AlltBokatWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static AlltBokatWebAPI.Services.DTOs.ApplicationUserDTOs;

namespace AlltBokatWebAPI.Services
{
    public abstract class ApplicationUserServicesBase
    {
        public virtual ApplicationUserPersonInfoDTO ConvertApplicationUserToApplicationUserPersonInfoDTO(ApplicationUser input)
        {
            return new ApplicationUserPersonInfoDTO {
                Id = input.Id,
                Email = input.Email,
                FirstName = input.FirstName,
                LastName = input.LastName,
                UserName = input.UserName };
        }

        public virtual List<ApplicationUserPersonInfoDTO> ConvertListofApplicationUserToListofApplicationUserPersonInfoDTO(List<ApplicationUser> input)
        {
            var ListOfApplicationUserDTOs = new List<ApplicationUserPersonInfoDTO>();

            foreach (var item in input)
            {
                ListOfApplicationUserDTOs.Add(ConvertApplicationUserToApplicationUserPersonInfoDTO(item));
            }
            return ListOfApplicationUserDTOs;
        }
    }
}