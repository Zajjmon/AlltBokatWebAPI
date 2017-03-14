using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlltBokatWebAPI.Models.ViewModels
{
    public class ApplicationUserViewModels
    {
        public class ApplicationUserInfoViewModel
        {
            public string Email { get; set; }
            public string UserName { get; set; }


        }
        public class ApplicationUserInfoViewModelWhithId
        {
            public int Id { get; set; }
            public string Email { get; set; }
            public string UserName { get; set; }


        }

    }
}