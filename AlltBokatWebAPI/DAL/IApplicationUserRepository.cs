using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using static AlltBokatWebAPI.Models.ViewModels.ApplicationUserViewModels;

namespace AlltBokatWebAPI.DAL
{


    //Not implemented yet due to the use of static classes in ApplicationUserRepository, maybe later create an instans in the ApplicationUserController

    public interface IApplicationUserRepository : IDisposable
    {

        Task<string> GetApplicationUserNameById(string id);
        Task<List<ApplicationUserInfoViewModel>> GetApplicationUserNames();
       

    }










}