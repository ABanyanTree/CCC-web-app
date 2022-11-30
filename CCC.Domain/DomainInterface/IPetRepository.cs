using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCC.Domain.DomainInterface
{
    public interface IPetRepository : IRepository<PetServiceDetails>
    {
        Task<int> AddEditPetData(PetServiceDetails obj);
        Task<PetServiceDetails> GetPetData(PetServiceDetails obj);
        Task<IEnumerable<PetServiceDetails>> GetAllPetData(PetServiceDetails obj);
        Task<int> DeletePetData(PetServiceDetails obj);
        Task<int> ChangePetCenters(PetServiceDetails obj);
    }
}
