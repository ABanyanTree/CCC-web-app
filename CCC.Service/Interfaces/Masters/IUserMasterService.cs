using CCC.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CCC.Service.Interfaces
{
    public interface IUserMasterService : IServiceBase<UserMaster>
    {
        Task<string> AddEditUser(UserMaster request);
        Task<UserMaster> IsUserNameInUse(string userName);
        Task<IEnumerable<UserMaster>> GetAllUsers();
        Task<UserMaster> IsInUseCount(string userId);
        UserMaster LoginAndGetFeatures(UserMaster request);
        UserMaster GetByEmailAsync(UserMaster obj);
        Task<int> SetNewPassword(UserMaster obj);
        Task<int> ChangePassword(UserMaster request);
    }
}
