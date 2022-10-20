using CCC.Domain;
using CCC.Domain.DomainInterface;
using CCC.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCC.Service.Services
{
    public class UserRoleMastersService : IUserRoleMastersService
    {
        private IUserRoleMastersRepository _iUserRoleMastersRepository;
        public UserRoleMastersService(IUserRoleMastersRepository UserRoleMastersRepository) : base()
        {
            _iUserRoleMastersRepository = UserRoleMastersRepository;
        }

        public Task<int> AddEditAsync(UserRoleMasters obj)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(UserRoleMasters obj)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserRoleMasters>> GetAllAsync(UserRoleMasters obj)
        {
            throw new NotImplementedException();
        }

        public Task<UserRoleMasters> GetAsync(UserRoleMasters obj)
        {
            throw new NotImplementedException();
        }
    }
}
