using CCC.Domain;
using CCC.Domain.DomainInterface;
using CCC.Service.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace CCC.Service.Services
{
	public class RefreshTokenService : IRefreshTokenService
    {
        IRefreshTokenRepository _IRefreshTokenRepository = null;
        private IOptions<FileSystemPath> _options;
        public RefreshTokenService(IRefreshTokenRepository IRefreshTokenRepository, IOptions<FileSystemPath> options)
        {
            _IRefreshTokenRepository = IRefreshTokenRepository;
            _options = options;
        }

        public async Task<RefreshToken> GetRefreshToken(RefreshToken RefreshToken)
        {
            return await _IRefreshTokenRepository.GetStoredRefreshToken(RefreshToken);
        }

        public async Task<int> SaveRefreshToken(RefreshToken RefreshToken)
        {
            return await _IRefreshTokenRepository.SaveRefreshToken(RefreshToken);
        }

        public async Task<int> SaveSaltTime(DateTime start, DateTime end, string APIName)
        {
            string createlog = _options.Value.CreateAPILog;
            if (createlog == "1")
            {
                RefreshToken obj = new RefreshToken()
                {
                    StartTime = start,
                    EndTime = end,
                    APIName = APIName
                };

                return await _IRefreshTokenRepository.SaveSaltTime(obj);
            }

            return 1;
        }

        public async Task<int> UpdateRefreshToken(RefreshToken RefreshToken)
        {
            return await _IRefreshTokenRepository.UpdateRefreshToken(RefreshToken);
        }
    }
}
