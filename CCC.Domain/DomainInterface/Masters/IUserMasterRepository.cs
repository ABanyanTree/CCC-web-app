using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCC.Domain.DomainInterface
{
    public interface IUserMasterRepository : IRepository<UserMaster>
    {
        Task<int> AddEditUser(UserMaster obj);
        Task<int> DeleteUser(UserMaster obj);
        Task<IEnumerable<UserMaster>> GetAllUserList(UserMaster obj);
        Task<IEnumerable<UserMaster>> GetAllUsers();
        Task<UserMaster> GetUser(UserMaster obj);
        Task<UserMaster> IsInUseCount(string userId);
        Task<UserMaster> IsUserNameInUse(string userName);
        Task<UserMaster> GetByEmailAsync(UserMaster obj);
        UserMaster LoginAndGetFeatures(UserMaster obj);
        Task<int> ForgotPassword(UserMaster obj);
        Task<int> ChangePassword(UserMaster obj);
        Task<IEnumerable<UserMaster>> GetUsersByCenter(UserMaster obj);
    }
}
