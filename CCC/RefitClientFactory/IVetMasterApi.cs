using CCC.UI.ViewModels;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CCC.UI.RefitClientFactory
{
    [Headers("Authorization: Bearer")]
    public interface IVetMasterApi
    {
        [Get(path: "/api/vetmaster/getallvetdetails")]
        Task<ApiResponse<List<GetVetResponse>>> GetAllVetDetails();
    }
}
