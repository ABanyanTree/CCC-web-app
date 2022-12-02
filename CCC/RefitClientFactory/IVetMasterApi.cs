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
        Task<ApiResponse<VetMasterRequest>> GetVetDetail(string vetId);

        [Post(path: "/api/vetmaster/addeditvetdetail")]
        Task<HttpResponseMessage> AddEditVet(VetMasterRequest request);

        [Get(path: "/api/vetmaster/getallvetlist")]
        Task<ApiResponse<List<GetVetResponse>>> GetAllVetList(VetMasterRequest request);

        [Get(path: "/api/vetmaster/getallvetdetails")]
        Task<ApiResponse<List<GetVetResponse>>> GetAllVetDetails();

        [Get(path: "/api/vetmaster/isinusecount")]
        Task<HttpResponseMessage> IsInUseCount(string vetId);

        [Delete(path: "/api/vetmaster/deletevet")]
        Task<HttpResponseMessage> DeleteVet(string vetId);

        [Get(path: "/api/vetmaster/isvetnameinuse")]
        Task<ApiResponse<VetMasterRequest>> IsVetNameInUse(string vetName);
    }
}
