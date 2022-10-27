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
    public class RefreshTokenRepository : Repository<RefreshToken>, IRefreshTokenRepository
    {
        public RefreshTokenRepository(IOptions<ReadConfig> connStr, IDapperResolver<RefreshToken> resolver) : base(connStr, resolver)
        {
        }

        public async Task<int> SaveRefreshToken(RefreshToken RefreshToken)
        {
            string[] Params = new string[] { RefreshToken_Constant.Token, RefreshToken_Constant.JwtId,
                 RefreshToken_Constant.Creationdate,
                 RefreshToken_Constant.ExpiryDate,
                 RefreshToken_Constant.Used,
                 RefreshToken_Constant.InValidated,
                 RefreshToken_Constant.UserId,
                 RefreshToken_Constant.EmailAddress
            };
            var userResponse = await ExecuteNonQueryAsync(RefreshToken, Params, RefreshToken_Constant.sproc_RefreshToken_Ups);
            return userResponse;
        }
        public async Task<int> UpdateRefreshToken(RefreshToken RefreshToken)
        {
            string[] Params = new string[] { RefreshToken_Constant.Token
            };
            var userResponse = await ExecuteNonQueryAsync(RefreshToken, Params, RefreshToken_Constant.sproc_RefreshToken_Ups_Used);
            return userResponse;
        }

        public async Task<RefreshToken> GetStoredRefreshToken(RefreshToken RefreshToken)
        {
            string[] Params = new string[] { RefreshToken_Constant.Token
            };
            var userResponse = await GetAsync(RefreshToken, Params, RefreshToken_Constant.sproc_RefreshToken_Get);
            return userResponse;
        }

        public async Task<int> SaveSaltTime(RefreshToken obj)
        {
            string[] addparams = new string[] { "StartTime", "EndTime", "APIName" };
            return await ExecuteNonQueryAsync(obj, addparams, "sproc_SaltTime");
        }
    }
}
