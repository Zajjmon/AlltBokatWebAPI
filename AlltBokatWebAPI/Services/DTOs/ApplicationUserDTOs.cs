using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlltBokatWebAPI.Services.DTOs
{ 
    public class ApplicationUserDTOs
    {
        public class ApplicationUserPersonInfoDTO
        {
            public string Id { get; set; }
            public string Email { get; set; }
            public string UserName { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
    }
}