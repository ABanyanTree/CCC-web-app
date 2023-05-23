using CCC.UI.Utility;
using CCC.UI.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCC.UI.Helper
{
    public static class CustomHelpers
    {
        private static IHttpContextAccessor _httpContextAccessor;

        public static void Configure(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public static HttpContext Current => _httpContextAccessor.HttpContext;

        public static FeatureMasterResponseVM GetFeatures(string FeatureId)
        {
            FeatureMasterResponseVM objRight = null;
            var objSessionUSer = Current.Session.GetSessionUser();
            if (objSessionUSer != null)
            {
                objRight = objSessionUSer.UserFeatures.Find(delegate (FeatureMasterResponseVM obj) { return obj.FeatureId == CommonConstants.FEATURE_ManageCenter; });
            }
            return objRight;
        }
    }
}
