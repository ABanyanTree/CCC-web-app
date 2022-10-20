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
    public class VetMasterService : IVetMasterService
    {
        private IVetMasterRepository _iVetMasterRepository;
        public VetMasterService(IVetMasterRepository iVetMasterRepository) : base()
        {
            _iVetMasterRepository = iVetMasterRepository;
        }

        public Task<int> AddEditAsync(VetMaster obj)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(VetMaster obj)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<VetMaster>> GetAllAsync(VetMaster obj)
        {
            throw new NotImplementedException();
        }

        public Task<VetMaster> GetAsync(VetMaster obj)
        {
            throw new NotImplementedException();
        }
    }
}
