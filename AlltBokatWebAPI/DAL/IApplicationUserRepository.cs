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

        Task<ApplicationUserInfoViewModelWhithId> GetApplicationUserInfoById(string id);
        Task<List<ApplicationUserInfoViewModelWhithId>> GetApplicationUserNames();
       

    }










}