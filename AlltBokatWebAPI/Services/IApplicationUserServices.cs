using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AlltBokatWebAPI.Services.DTOs.ApplicationUserDTOs;

namespace AlltBokatWebAPI.Services
{
    public interface IApplicationUserServices : IDisposable
    {
        Task<List<ApplicationUserPersonInfoDTO>> GetAllApplicationUsersPersonInfo();
        Task<ApplicationUserPersonInfoDTO> GetApplicationUserPersonInfoById(string Id);

        Task<List<ApplicationUserPersonInfoDTO>> GetUsersWithBookingWithinTimeRange(DateTime startTime, DateTime endTime);
        Task<List<ApplicationUserPersonInfoDTO>> GetUsersWithBookingNOTWithinTimeRange(DateTime startTime, DateTime endTime);

    }
}
