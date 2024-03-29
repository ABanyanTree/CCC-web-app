﻿using CCC.API.ApiPath;
using CCC.API.Filters;
using CCC.API.Options;
using CCC.Domain;
using CCC.Domain.Email;
using CCC.Service.Infra;
using CCC.Service.Infra.EmailStuff;
using CCC.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CCC.API.Controllers.Masters
{
    public class UserMasterController : Controller
    {
        private readonly IUserMasterService _iUserMasterService;
        private readonly ICenterMasterService _iCenterMasterService;
        private readonly JwtSettings _jwtSettings;
        private readonly IRefreshTokenService _iRefreshTokenService;
        private IEmailSender _iEmailSender;


        public UserMasterController(IUserMasterService UserMasterService, JwtSettings jwtSettings, ICenterMasterService CenterMasterService, IRefreshTokenService RefreshTokenService, IEmailSender iEmailSender)
        {
            _iUserMasterService = UserMasterService;
            _jwtSettings = jwtSettings;
            _iRefreshTokenService = RefreshTokenService;
            _iCenterMasterService = CenterMasterService;
            _iEmailSender = iEmailSender;
        }

        [HttpPost(ApiRoutes.UserMaster.AddEditUser), DisableRequestSizeLimit]
        [ProducesResponseType(typeof(string), statusCode: 200)]
        [ProducesResponseType(typeof(ErrorLogs), statusCode: 401)]
        [ProducesResponseType(typeof(ErrorLogs), statusCode: 400)]
        //[CustomAuthorizeAttribute(FeatureId = FeatureAccess.FEATURE_ManageUsers)]
        public async Task<IActionResult> AddEditUser([FromBody] UserMaster request)
        {
            var userId = await _iUserMasterService.AddEditUser(request);
            return Ok(userId);

        }

        [HttpGet(ApiRoutes.UserMaster.GetUser)]
        [ProducesResponseType(typeof(UserMaster), statusCode: 200)]
        //[CustomAuthorizeAttribute(FeatureId = FeatureAccess.FEATURE_ManageUsers)]
        public async Task<IActionResult> GetUser([FromQuery] string userId)
        {
            var objResponse = await _iUserMasterService.GetAsync(new UserMaster { UserId = userId });
            if (!string.IsNullOrEmpty(objResponse.UserId))
            {
                var lstCenters = await _iCenterMasterService.GetAllCenterByUser(new CenterMaster { UserId = userId });
                objResponse.lstCenters = new List<CenterMaster>();
                objResponse.lstCenters.AddRange(lstCenters);
            }
            // string ss = Cryptography.Decrypt(objResponse.Password);

            return Ok(objResponse);
        }

        [HttpDelete(ApiRoutes.UserMaster.DeleteUser)]
        [ProducesResponseType(typeof(string), statusCode: 200)]
        // [CustomAuthorizeAttribute(FeatureId = FeatureAccess.FEATURE_ManageUsers)]
        public async Task<IActionResult> DeleteUser([FromQuery] string userId)
        {
            var objResponse = await _iUserMasterService.DeleteAsync(new UserMaster { UserId = userId });
            return Ok(objResponse);
        }


        [HttpGet(ApiRoutes.UserMaster.GetAllUserList)]
        [ProducesResponseType(typeof(UserMaster), statusCode: 200)]
        //[CustomAuthorizeAttribute(FeatureId = FeatureAccess.FEATURE_ManageUsers)]
        public async Task<IActionResult> GetAllUserList(UserMaster request)
        {
            var objResponse = await _iUserMasterService.GetAllAsync(request);
            return Ok(objResponse);
        }


        [HttpGet(ApiRoutes.UserMaster.IsUserNameInUse)]
        [ProducesResponseType(typeof(UserMaster), statusCode: 200)]
        // [CustomAuthorizeAttribute(FeatureId = FeatureAccess.FEATURE_ManageUsers)]
        public async Task<IActionResult> IsUserNameInUse([FromQuery] string userName)
        {
            var objResponse = await _iUserMasterService.IsUserNameInUse(userName);
            return Ok(objResponse);

        }


        [HttpGet(ApiRoutes.UserMaster.GetAllUsers)]
        [ProducesResponseType(typeof(UserMaster), statusCode: 200)]
        [ProducesResponseType(typeof(ErrorLogs), statusCode: 400)]
        //[CustomAuthorizeAttribute]
        public async Task<IActionResult> GetAllUsers()
        {
            var objResponse = await _iUserMasterService.GetAllUsers();
            return Ok(objResponse);
        }


        [HttpGet(ApiRoutes.UserMaster.IsInUseCount)]
        [ProducesResponseType(typeof(string), statusCode: 200)]
        //[CustomAuthorizeAttribute(FeatureId = FeatureMasterInfra.FEATURE_Country)]
        public async Task<IActionResult> IsInUseCount([FromQuery] string userId)
        {
            var objResponse = await _iUserMasterService.IsInUseCount(userId);
            return Ok(objResponse.TotalCount);
        }




        [HttpPost(ApiRoutes.UserMaster.Login)]
        [ProducesResponseType(typeof(UserMaster), statusCode: 200)]
        [ProducesResponseType(typeof(ErrorModel), statusCode: 400)]
        public IActionResult Login([FromBody] UserLogin request)
        {
            DateTime startTime = DateTime.Now;
            var userReq = new UserMaster();
            userReq.Email = request.Email;
            userReq.Password = request.Password;
            userReq.Salt = request.Salt;
            var user = _iUserMasterService.LoginAndGetFeatures(userReq);

            if (user != null && !string.IsNullOrEmpty(user.UserId))
            {
                user = GenerateToken(user);
                //var responseObj = _mapper.Map<AuthSuccessResponse>(user);
                //var responseFeaturesObj = _mapper.Map<List<FeatureMasterResponse>>(user.Features);
                ////var responseHirarchyObj = _mapper.Map<UserHierarchyResponse>(user.userHierarchy);
                //var responseRolesObj = _mapper.Map<List<UserRoleResponse>>(user.userRoles);


                //responseObj.UserFeatures = responseFeaturesObj;
                //responseObj.userRoles = responseRolesObj;
                //// responseObj.userHierarchy = responseHirarchyObj;
                //responseObj.IsSuccess = true;

                UserMaster objCart = new UserMaster()
                {
                    RequesterUserId = user.UserId,
                    IsAdmin = true
                };
                //objCart = _user.GetCartCount(objCart).Result;
                //responseObj.AdminCartCount = objCart.TotalCartItems;

                //objCart = new UserMaster()
                //{
                //    RequesterUserId = responseObj.UserId,
                //    IsAdmin = false
                //};
                //objCart = _user.GetCartCount(objCart).Result;
                //responseObj.UserCartCount = objCart.TotalCartItems;

                DateTime endTime = DateTime.Now;
                _iRefreshTokenService.SaveSaltTime(startTime, endTime, "Login");

                return Ok(user);
            }

            ErrorModel errorModel = new ErrorModel();
            errorModel.FieldName = "Login Failed";
            errorModel.Message = "Invalid Username or Password";
            //ErrorResponse errorResponse = new ErrorResponse();
            //errorResponse.Errors = new List<ErrorModel>();
            //errorResponse.Errors.Add(errorModel);

            return BadRequest(errorModel);
        }

        private UserMaster GenerateToken(UserMaster loggedInUser)
        {
            string strUserFeatures = string.Empty;
            if (loggedInUser.UserFeatures != null && loggedInUser.UserFeatures.Count > 0)
            {
                strUserFeatures = string.Join(",", loggedInUser.UserFeatures.Select(x => x.FeatureId));
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);

            var claims = new List<Claim>
                {
                    new Claim(type:JwtRegisteredClaimNames.Sub,value:loggedInUser.FirstName),
                    new Claim(type:JwtRegisteredClaimNames.Jti,value:Guid.NewGuid().ToString()),
                    new Claim(type:JwtRegisteredClaimNames.Email,value:loggedInUser.Email),
                    new Claim(type:"id",value:loggedInUser.UserId),
                    new Claim(type:"Features",value:strUserFeatures)
                };

            DateTime expiryDate = DateTime.UtcNow.Add(_jwtSettings.TokenLifeTime);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(claims

                    ),
                Expires = expiryDate,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                algorithm: SecurityAlgorithms.HmacSha256Signature)

            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            loggedInUser.Token = tokenHandler.WriteToken(token);



            var refreshToken = new RefreshToken
            {
                JwtId = token.Id,
                UserId = loggedInUser.UserId,
                Creationdate = DateTime.UtcNow,
                Email = loggedInUser.Email,
                ExpiryDate = DateTime.UtcNow.AddMonths(6),
            };
            refreshToken.Token = GenerateRefreshToken();
            loggedInUser.RefreshToken = refreshToken.Token;
            loggedInUser.ExpiryDate = expiryDate;
            _iRefreshTokenService.SaveRefreshToken(refreshToken);

            // remove password before returning



            return loggedInUser;
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }


        [HttpGet(ApiRoutes.UserMaster.GetSalt)]
        [ProducesResponseType(typeof(string), statusCode: 200)]
        [ProducesResponseType(typeof(ErrorModel), statusCode: 400)]
        public IActionResult GetSalt()
        {
            DateTime startTime = DateTime.Now;
            var salt = Cryptography.CreateSalt();
            DateTime endTime = DateTime.Now;

            _iRefreshTokenService.SaveSaltTime(startTime, endTime, "GetSalt");

            return Ok(salt);
        }

        [HttpPost(ApiRoutes.UserMaster.ForgotPassword)]
        public async Task<IActionResult> ForgotPassword([FromBody] UserMaster request)
        {
            var objUser = _iUserMasterService.GetByEmailAsync(request);
            if (string.IsNullOrEmpty(objUser?.Email))
            {
                return Ok(false);
            }
            var obj = await _iUserMasterService.SetNewPassword(objUser);
            return Ok();
        }

        [HttpPost(ApiRoutes.UserMaster.CheckExistingPassword)]
        public async Task<IActionResult> CheckExistingPassword([FromBody] UserMaster request)
        {
            var objUser = await _iUserMasterService.GetAsync(request);
            string hashedPassword = Cryptography.MD5Hash(request?.Salt + objUser?.Password);
            if (hashedPassword != request?.ExistingPassword)
            {
                return Ok(false);
            }
            return Ok(true);
        }

        [HttpPost(ApiRoutes.UserMaster.ChangePassword)]
        public async Task<IActionResult> ChangePassword([FromBody] UserMaster request)
        {
            var obj = await _iUserMasterService.ChangePassword(request);
            return Ok();
        }

        [HttpPost(ApiRoutes.UserMaster.SendTestEmail)]
        public async Task<IActionResult> SendTestEmail([FromBody] string email)
        {
            try
            {
                EmailSenderEntity emailconfig = new EmailSenderEntity();
                emailconfig.EmailTo = email;
                emailconfig.Body = "This is a test email";
                emailconfig.Subject = "Test Email from API";
                var IsEmailSent = await _iEmailSender.SendInstantEmailForTesting(emailconfig);
                if (IsEmailSent)
                {
                    return Ok("Mail Sent");
                }
                else
                {
                    return BadRequest("Not Sent");
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message + ex.StackTrace.ToString();
                return BadRequest(msg);
            }
        }
    }
}
