﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCC.Domain
{
    public class AuthSuccessResponse
    {
        public string Token { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string LoginId { get; set; }
        public string ContactNumber { get; set; }
        public DateTime? HiringDate { get; set; }
        public string ZipCode { get; set; }
        public bool Status { get; set; }
        public string DepartmentId { get; set; }
        public string DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
        public string JobCodeId { get; set; }
        public string JobCode { get; set; }
        public string JobRole { get; set; }
        public DateTime? RoleChangeDate { get; set; }
        public string TimeZoneId { get; set; }
        public string TimeZoneName { get; set; }
        public string TimeZoneDescription { get; set; }
        public string ProfilePic { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsOnLearnerSide { get; set; }
        public List<FeatureMaster> UserFeatures { get; set; } = new List<FeatureMaster>();

        // public UserHierarchyResponseVM userHierarchy { get; set; } = new UserHierarchyResponseVM();
        public List<UserRoleMasters> userRoles { get; set; } = new List<UserRoleMasters>();

        public bool IsPasswordChanged { get; set; }
        public string RefreshToken { get; set; }
        public DateTime ExpiryDate { get; set; }

        public int AdminCartCount { get; set; }
        public int UserCartCount { get; set; }

        public string LoginUniqueId { get; set; }


        ////
        public string URoleId { get; set; }
    }
}
