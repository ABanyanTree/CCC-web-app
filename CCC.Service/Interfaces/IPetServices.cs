using CCC.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCC.Service.Interfaces
{
    public interface IPetServices : IServiceBase<PetServiceDetails>
    {
        Task<string> AddEditPetData(PetServiceDetails obj);
    }
}
