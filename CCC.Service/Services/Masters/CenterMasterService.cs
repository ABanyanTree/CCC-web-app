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
    public class CenterMasterService : ICenterMasterService
    {
        private ICenterMasterRepository _iCenterMasterRepository;
        public CenterMasterService(ICenterMasterRepository ICenterMasterRepository) : base()
        {
            _iCenterMasterRepository = ICenterMasterRepository;
        }

        public Task<int> AddEditAsync(CenterMaster obj)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(CenterMaster obj)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CenterMaster>> GetAllAsync(CenterMaster obj)
        {
            throw new NotImplementedException();
        }

        public Task<CenterMaster> GetAsync(CenterMaster obj)
        {
            throw new NotImplementedException();
        }
    }
}
