using AlltBokatWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using static AlltBokatWebAPI.Models.ViewModels.ApplicationUserViewModels;

namespace AlltBokatWebAPI.DAL
{


    

    public interface IApplicationUserRepository : IDisposable
    {
        
        Task<List<ApplicationUser>> GetUsersWithBookingWithinTimeRange(DateTime startTime, DateTime endTime);
        Task<List<ApplicationUser>> GetUsersWithBookingNOTWithinTimeRange(DateTime startTime, DateTime endTime);
        Task<List<ApplicationUser>> GetAllApplicationUsers();
        Task<ApplicationUser> GetApplicationUserInfoById(string id);
       



    }










}