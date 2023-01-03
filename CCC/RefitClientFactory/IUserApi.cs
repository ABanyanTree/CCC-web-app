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


        [Get(path: "/api/usermaster/getuser")]
        Task<ApiResponse<UserMasterRequest>> GetUser(string userId);

        [Post(path: "/api/usermaster/addedituser")]
        Task<HttpResponseMessage> AddEditUser(UserMasterRequest request);

        [Get(path: "/api/usermaster/getalluserlist")]
        Task<ApiResponse<List<GetAllUserResponse>>> GetAllUserDetailList(UserMasterRequest request);

        [Get(path: "/api/usermaster/getallusers")]
        Task<ApiResponse<List<GetAllUserResponse>>> GetAllUserDetail();

        [Get(path: "/api/usermaster/isinusecount")]
        Task<HttpResponseMessage> IsInUseCount(string userId);

        [Delete(path: "/api/usermaster/deleteuser")]
        Task<HttpResponseMessage> DeleteUser(string userId);

        [Get(path: "/api/usermaster/isusernameinuse")]
        Task<ApiResponse<UserMasterRequest>> IsUserNameInUse(string userName);

        [Post(path: "/api/usermaster/forgotpassword")]
        Task<ApiResponse<AuthSuccessResponseVM>> ForgotPasswordAsync(UserLoginRequestVM model);

        [Post(path: "/api/usermaster/checkexistingpassword")]
        Task<HttpResponseMessage> CheckExistingPassword(UserLoginRequestVM model);

        [Post(path: "/api/usermaster/changepassword")]
        Task<HttpResponseMessage> ChangePassword(UserLoginRequestVM model);

    }
}
