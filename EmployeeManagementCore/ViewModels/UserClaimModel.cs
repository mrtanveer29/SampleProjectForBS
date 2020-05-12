﻿using EmployeeManagementCore.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementCore.ViewModels
{
    public class UserClaimModel
    {
        public UserClaimModel()
        {
            Claims = new List<UserClaim>();
        }
        public string UserId { get; set; }
        public List<UserClaim> Claims {get;set;}
    }
   
}
