using CCC.Domain;
using System;
using System.Threading.Tasks;

namespace CCC.Service.Interfaces
{
	public interface IRefreshTokenService
    {
        Task<int> SaveRefreshToken(RefreshToken RefreshToken);
        Task<int> UpdateRefreshToken(RefreshToken RefreshToken);
        Task<RefreshToken> GetRefreshToken(RefreshToken RefreshToken);

        Task<int> SaveSaltTime(DateTime start, DateTime end, string APIName);
    }
}
