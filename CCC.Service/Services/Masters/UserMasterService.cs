using CCC.Domain;
using CCC.Domain.DomainInterface;
using CCC.Domain.Email;
using CCC.Service.Infra;
using CCC.Service.Infra.EmailStuff;
using CCC.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCC.Service.Services
{
    public class UserMasterService : IUserMasterService
    {
        private IUserMasterRepository _iUserMasterRepository;
        private IEmailSender _iEmailSender;
        public UserMasterService(IUserMasterRepository UserMasterRepository, IEmailSender EmailSender) : base()
        {
            _iUserMasterRepository = UserMasterRepository;
            _iEmailSender = EmailSender;
        }

        public async Task<int> AddEditAsync(UserMaster obj)
        {
            throw new NotImplementedException();
        }

        public async Task<string> AddEditUser(UserMaster obj)
        {
            if (string.IsNullOrEmpty(obj.UserId))
            {
                obj.UserId = Utility.GeneratorUniqueId("USR_");
                obj.IsActive = true;
            }

            if (!string.IsNullOrEmpty(obj.Password))
            {
                obj.Password = Cryptography.MD5Hash(obj.Password);
            }

            int successCount = await _iUserMasterRepository.AddEditUser(obj);
            return successCount > 0 ? obj.UserId : string.Empty;
        }

        public async Task<int> DeleteAsync(UserMaster obj)
        {
            return await _iUserMasterRepository.DeleteUser(obj);
        }

        public async Task<IEnumerable<UserMaster>> GetAllAsync(UserMaster obj)
        {
            return await _iUserMasterRepository.GetAllUserList(obj);
        }
        public async Task<IEnumerable<UserMaster>> GetAllUsers()
        {
            return await _iUserMasterRepository.GetAllUsers();
        }

        public async Task<UserMaster> GetAsync(UserMaster obj)
        {
            return await _iUserMasterRepository.GetUser(obj);
        }

        public UserMaster GetByEmailAsync(UserMaster obj)
        {
            return _iUserMasterRepository.GetByEmailAsync(obj).Result;
        }

        public async Task<UserMaster> IsInUseCount(string userId)
        {
            return await _iUserMasterRepository.IsInUseCount(userId);
        }

        public async Task<UserMaster> IsUserNameInUse(string userName)
        {
            return await _iUserMasterRepository.IsUserNameInUse(userName);
        }

        public UserMaster LoginAndGetFeatures(UserMaster obj)
        {
            obj.IsLogin = true;
            UserMaster returnObj = _iUserMasterRepository.GetByEmailAsync(obj)?.Result;

            //Original Code
            string hashedPassword = Cryptography.MD5Hash(obj?.Salt + returnObj?.Password);
            if (hashedPassword != obj?.Password)
                return null;


            //extra line temp use
            //string encryptPass = Cryptography.MD5Hash(obj.Password);
            //encryptPass = Cryptography.MD5Hash(obj?.Salt + encryptPass);
            //string hashedPassword = Cryptography.MD5Hash(obj?.Salt + returnObj?.Password);
            //if (hashedPassword != encryptPass)
            //    return null;


            var response = _iUserMasterRepository.LoginAndGetFeatures(obj);

            //if (response == null || response.userRoles.Count < 1)
            //{
            //    response.IsAdmin = false;
            //}
            //else
            //{
            //    response.IsAdmin = true;
            //}
            //response.LoginUniqueId = returnObj.LoginUniqueId;//Vikas - to track login details
            return response;
        }

        public async Task<int> SetNewPassword(UserMaster obj)
        {
            string randomPassword = Utility.CreateRandomPassword(8);
            obj = GetByEmailAsync(obj);
            //SEND EMAIL TO USER
            if (!string.IsNullOrEmpty(obj.Email))
            {
                string strBody = string.Empty;
                string strSubject = string.Empty;
                obj.Password = randomPassword;
                EmailSenderEntity emailconfig = new EmailSenderEntity();

                //EmailSender data = new EmailSender();
                _iEmailSender.GetForgotPasswordBodyAndSubject(obj, ref strBody, ref strSubject);
                //data.GetForgotPasswordBodyAndSubject(obj, ref strBody, ref strSubject);
                emailconfig.EmailTo = obj.Email;
                emailconfig.Body = strBody;
                emailconfig.Subject = strSubject;
                var emailSentLog = await _iEmailSender.SendInstantEmailFunctionality(emailconfig, obj);

                //await _emailSentLog.AddEditAsync(emailSentLog);

            }
            //ENCRYPT NEW PASSWORD AND UPDATE IN DATABASE
            randomPassword = Cryptography.MD5Hash(randomPassword);
            obj.Password = randomPassword;

            return await _iUserMasterRepository.ForgotPassword(obj);
        }

        public async Task<int> ChangePassword(UserMaster obj)
        {
            obj.Password = Cryptography.MD5Hash(obj.Password);
            return await _iUserMasterRepository.ChangePassword(obj);
        }
    }
}
