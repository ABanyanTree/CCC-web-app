using CCC.UI.ViewModels;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CCC.UI.RefitClientFactory
{
    [Headers("Authorization: Bearer")]
    public interface IUserApi
    {
        [Post(path: "/api/usermaster/login")]
        Task<ApiResponse<AuthSuccessResponseVM>> LoginAsync(UserLoginRequestVM model);

        [Get(path: "/api/usermaster/tracksignouttime")]
        Task<HttpResponseMessage> TrackSignOutTime(string loginUniqueId);

        [Get(path: "/api/usermaster/getsalt")]
        Task<HttpResponseMessage> GetMD5Salt();
    }
}
