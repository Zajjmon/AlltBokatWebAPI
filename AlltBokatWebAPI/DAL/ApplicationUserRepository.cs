﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AlltBokatWebAPI.Models;
using static AlltBokatWebAPI.Models.ViewModels.ApplicationUserViewModels;
using AlltBokatWebAPI.DAL.Services;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System.Data.Entity;

namespace AlltBokatWebAPI.DAL
{
    public class ApplicationUserRepository : IApplicationUserRepository, IDisposable

    {
        private ApplicationDbContext context;
        private ApplicationUserManager UserManager;
        private ApplicationUserServices ApplicationUserServices;

        public ApplicationUserRepository(ApplicationDbContext context)
        {
            this.context = context;
            this.UserManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            this.ApplicationUserServices = new ApplicationUserServices();
        }




        public async Task<ApplicationUserInfoViewModelWhithId> GetApplicationUserInfoById(string id)
        {
            using (context)
            {
                ApplicationUser user = await UserManager.FindByIdAsync(id);
                ApplicationUserInfoViewModelWhithId userInfo = ApplicationUserServices.ConvertToApplicationUserInfoViewModelWhitIdSingle(user);



                
                return userInfo;
            }
        }



        public async Task<List<ApplicationUserInfoViewModelWhithId>> GetApplicationUserNames()
        {
            using (context)
            {

                
                 var FullList =await UserManager.Users.ToListAsync();

                List<ApplicationUserInfoViewModelWhithId> usrList = new List<ApplicationUserInfoViewModelWhithId>();
                usrList = ApplicationUserServices.ConvertToApplicationUserInfoViewModelWithId(FullList);





                return usrList;
            }
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


    }
}