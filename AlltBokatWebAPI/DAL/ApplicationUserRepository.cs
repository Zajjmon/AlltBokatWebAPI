using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AlltBokatWebAPI.Models;
using static AlltBokatWebAPI.Models.ViewModels.ApplicationUserViewModels;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using System.Data.SqlClient;
using AlltBokatWebAPI.Services;

namespace AlltBokatWebAPI.DAL
{
    public class ApplicationUserRepository : IApplicationUserRepository, IDisposable

    {
        private ApplicationDbContext context;
        private ApplicationUserManager UserManager;
        

        public ApplicationUserRepository(ApplicationDbContext context)
        {
            this.context = context;
            this.UserManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            
        }

        public async Task<List<ApplicationUser>> GetAllApplicationUsers()
        {
            return await UserManager.Users.ToListAsync();
        }
        

        public async Task<ApplicationUser> GetApplicationUserInfoById(string id)
        {
            return await UserManager.FindByIdAsync(id);
            
        }




        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<List<ApplicationUser>> GetUsersWithBookingWithinTimeRange(DateTime startTime, DateTime endTime)
        {
            List<ApplicationUser> users = await context.Database.SqlQuery<ApplicationUser>("dbo.SelectUsersWithBookingWithinTimeRange @inputStartTime, @inputEndTime", new SqlParameter("@inputStartTime", startTime), new SqlParameter("@inputEndTime", endTime)).ToListAsync();
            return users;
        }

        public async Task<List<ApplicationUser>> GetUsersWithBookingNOTWithinTimeRange(DateTime startTime, DateTime endTime)
        {
            List<ApplicationUser> users = await context.Database.SqlQuery<ApplicationUser>("dbo.SelectUsersWithBookingNOTWithinTimeRange @inputStartTime, @inputEndTime", new SqlParameter("@inputStartTime", startTime), new SqlParameter("@inputEndTime", endTime)).ToListAsync();
            return users;
        }
        
    }
}