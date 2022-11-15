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
    public interface IVanMasterApi
    {
        [Get(path: "/api/vanmaster/getvandetail")]
        Task<ApiResponse<VanMasterRequest>> GetVanDetail(string centerId);

        [Post(path: "/api/vanmaster/addeditvandetail")]
        Task<HttpResponseMessage> AddEditVanDetail(VanMasterRequest request);

        [Get(path: "/api/vanmaster/getallvandetaillist")]
        Task<ApiResponse<List<GetCentersResponse>>> GetAllVanDetailList(VanMasterRequest request);

        [Get(path: "/api/vanmaster/getallvansdetails")]
        Task<ApiResponse<List<GetAllVanDeatailResponse>>> GetAllVanDetail();
    }
}
