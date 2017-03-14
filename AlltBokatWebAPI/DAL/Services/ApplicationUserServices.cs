using AlltBokatWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using static AlltBokatWebAPI.Models.ViewModels.ApplicationUserViewModels;

namespace AlltBokatWebAPI.DAL.Services
{
    public class ApplicationUserServices
    { 
        
        
        
        //Converts a List of ApplicationUsers to  a list of ApplicationUserInfoViewModels
        public List<ApplicationUserInfoViewModel> ConvertToApplicationUserInfoViewModel(List<ApplicationUser> FullUserList)
        {
            var PartOfUserList = new List<ApplicationUserInfoViewModel>();


            
             foreach (ApplicationUser item in FullUserList)
            {
                ApplicationUserInfoViewModel user = new ApplicationUserInfoViewModel();
                user.Email = item.Email;
                user.UserName = item.UserName;

                PartOfUserList.Add(user);


            }

             return PartOfUserList;
        }
    }
}