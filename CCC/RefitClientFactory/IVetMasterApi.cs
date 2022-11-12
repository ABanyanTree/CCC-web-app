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
        [Get(path: "/api/vetmaster/getvetdetail")]
        Task<ApiResponse<VetMasterRequest>> GetVetDetail(string centerId);

        [Post(path: "/api/vetmaster/addeditvetdetail")]
        Task<HttpResponseMessage> AddEditVet(VetMasterRequest request);

        [Get(path: "/api/vetmaster/getallvetlist")]
        Task<ApiResponse<List<GetVetResponse>>> GetAllVetList(VetMasterRequest request);

        [Get(path: "/api/vetmaster/getallvetdetails")]
        Task<ApiResponse<List<GetVetResponse>>> GetAllVetDetails();
    }
}
