using CCC.Data.Interfaces;
using CCC.Domain;
using CCC.Domain.DomainInterface;
using CCC.Domain.Others;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCC.Data.Services
{
    public class UserMasterRepository : Repository<UserMaster>, IUserMasterRepository
    {
        public UserMasterRepository(IOptions<ReadConfig> connStr, IDapperResolver<UserMaster> resolver) : base(connStr, resolver)
        {
        }

        public async Task<int> AddEditUser(UserMaster obj)
        {
            string[] addParams = new string[]
              {
                UserMaster_Constant.USERID,
                UserMaster_Constant.FIRSTNAME,
                UserMaster_Constant.LASTNAME,
                UserMaster_Constant.EMAIL,
                UserMaster_Constant.MOBILE,
                UserMaster_Constant.LOGINID,
                UserMaster_Constant.PASSWORD,
                UserMaster_Constant.CREATEDBY,
                UserMaster_Constant.MODIFIEDBY,
                UserMaster_Constant.ISACTIVE
               };

            return await ExecuteNonQueryAsync(obj, addParams, UserMaster_Constant.SPROC_USERMASTER_UPS);
        }

        public async Task<int> DeleteUser(UserMaster obj)
        {
            string[] addParams = new string[] { UserMaster_Constant.USERID };
            return await ExecuteNonQueryAsync(obj, addParams, UserMaster_Constant.SPROC_USERMASTER_DEL);
        }

        public async Task<IEnumerable<UserMaster>> GetAllUserList(UserMaster obj)
        {
            string[] addParams = new string[] { BaseEntity_Constant.PAGEINDEX, BaseEntity_Constant.PAGESIZE, BaseEntity_Constant.SORTEXP };
            return await GetAllAsync(obj, addParams, UserMaster_Constant.SPROC_USERMASTER_LSTALL);
        }

        public async Task<IEnumerable<UserMaster>> GetAllUsers()
        {
            string[] addParams = new string[] { };
            return await GetAllAsync(new UserMaster(), addParams, UserMaster_Constant.SPROC_UserMaster_GETALL);
        }

        public Task<UserMaster> GetByEmailAsync(UserMaster obj)
        {
            string[] addParams = new string[] { UserMaster_Constant.EMAIL };
            return GetAsync(obj, addParams, UserMaster_Constant.SPROC_USERBYEMAIL);
        }

        public async Task<UserMaster> GetUser(UserMaster obj)
        {
            string[] addParams = new string[] { UserMaster_Constant.USERID };
            return await GetAsync(obj, addParams, UserMaster_Constant.SPROC_USERMASTER_SEL);
        }

        public async Task<UserMaster> IsInUseCount(string userId)
        {
            UserMaster obj = new UserMaster() { UserId = userId };
            string[] addParams = new string[] { UserMaster_Constant.USERID };
            return await GetAsync(obj, addParams, UserMaster_Constant.SPROC_UserMaster_ISINCOUNTUSE);
        }

        public async Task<UserMaster> IsUserNameInUse(string userName)
        {
            UserMaster obj = new UserMaster() { FirstName = userName };
            string[] addParams = new string[] { UserMaster_Constant.FIRSTNAME };
            return await GetAsync(obj, addParams, UserMaster_Constant.SPROC_USERMASTER_ISUSERNAMEINUSE);
        }

        public UserMaster LoginAndGetFeatures(UserMaster obj)
        {
            IEnumerable<dynamic> mapItems = new List<dynamic>()
                {
                    new MapItem(typeof(UserMaster), "UserMaster"),
                    new MapItem(typeof(UserRoleMasters), "UserRole"),
                    new MapItem(typeof(FeatureMaster), "FeatureMaster")
                };

            string[] addParams = new string[] { UserMaster_Constant.EMAIL };
            dynamic dynamicObject = GetMultipleAsync(obj, addParams, UserMaster_Constant.SPROC_LOGINUSERBYEMAILPASSWORD, mapItems);


            var User = ((List<dynamic>)dynamicObject.UserMaster).Cast<UserMaster>().ToList()?.FirstOrDefault();
            var UserRoleList = ((List<dynamic>)dynamicObject.UserRole).Cast<UserRoleMasters>().ToList();
            var FeatureList = ((List<dynamic>)dynamicObject.FeatureMaster).Cast<FeatureMaster>().ToList();

            if (User != null)
            {
                User.userRoles = UserRoleList;
                User.Features = FeatureList;
                return User;
            }

            return null;
        }
    }
}
