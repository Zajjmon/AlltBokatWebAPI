using AlltBokatWebAPI.DAL;
using AlltBokatWebAPI.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using static AlltBokatWebAPI.Models.ViewModels.ApplicationUserViewModels;
using static AlltBokatWebAPI.Services.DTOs.ApplicationUserDTOs;
using AlltBokatWebAPI.Services.DTOs;

namespace AlltBokatWebAPI.Services
{
    public class ApplicationUserServices : ApplicationUserServicesBase, IApplicationUserServices
    {
        private IApplicationUserRepository ApplicationUserRepository;
        

        public ApplicationUserServices()
        {
            this.ApplicationUserRepository = new ApplicationUserRepository(new ApplicationDbContext());

        }

        public async Task<List<ApplicationUserPersonInfoDTO>> GetAllApplicationUsersPersonInfo()
        {
            
            return ConvertListofApplicationUserToListofApplicationUserPersonInfoDTO(await ApplicationUserRepository.GetAllApplicationUsers());
        }

        public async Task<ApplicationUserPersonInfoDTO> GetApplicationUserPersonInfoById(string Id)
        {
            return ConvertApplicationUserToApplicationUserPersonInfoDTO(await ApplicationUserRepository.GetApplicationUserInfoById(Id));
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~ApplicationUserServices() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion

        public async Task<List<ApplicationUserPersonInfoDTO>> GetUsersWithBookingWithinTimeRange(DateTime startTime, DateTime endTime)
        {
            return ConvertListofApplicationUserToListofApplicationUserPersonInfoDTO(await ApplicationUserRepository.GetUsersWithBookingWithinTimeRange(startTime, endTime));
        }

        public async Task<List<ApplicationUserPersonInfoDTO>> GetUsersWithBookingNOTWithinTimeRange(DateTime startTime, DateTime endTime)
        {
            return ConvertListofApplicationUserToListofApplicationUserPersonInfoDTO(await ApplicationUserRepository.GetUsersWithBookingNOTWithinTimeRange(startTime, endTime));
        }
        
        

    }
}