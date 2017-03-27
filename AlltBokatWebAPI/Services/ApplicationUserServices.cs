using AlltBokatWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using static AlltBokatWebAPI.Models.ViewModels.ApplicationUserViewModels;

namespace AlltBokatWebAPI.Services
{
    public class ApplicationUserServices
    {



        //Converts a List of ApplicationUsers to  a list of ApplicationUserInfoViewModels (A list of users with id)
        public List<ApplicationUserInfoViewModelWhithId> ConvertToApplicationUserInfoViewModelWithId(List<ApplicationUser> FullUserList)
        {
            var PartOfUserList = new List<ApplicationUserInfoViewModelWhithId>();



            foreach (ApplicationUser item in FullUserList)
            {
                ApplicationUserInfoViewModelWhithId user = new ApplicationUserInfoViewModelWhithId();
                user.Email = item.Email;
                user.UserName = item.UserName;
                user.FirstName = item.FirstName;
                user.LastName = item.LastName;
                user.Id = item.Id;
                PartOfUserList.Add(user);


            }

            return PartOfUserList;
        }



        public ApplicationUserInfoViewModelWhithId ConvertToApplicationUserInfoViewModelWhitIdSingle(ApplicationUser User)
        {





            ApplicationUserInfoViewModelWhithId user = new ApplicationUserInfoViewModelWhithId();
            user.Email = User.Email;
            user.UserName = User.UserName;
            user.Id = User.Id;
            user.FirstName = User.FirstName;
            user.LastName = User.LastName;






            return user;
        }





















    }
}