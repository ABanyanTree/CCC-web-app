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
        Task<ApiResponse<VanMasterRequest>> GetVanDetail(string vanId);

        [Post(path: "/api/vanmaster/addeditvandetail")]
        Task<HttpResponseMessage> AddEditVanDetail(VanMasterRequest request);

        [Get(path: "/api/vanmaster/getallvandetaillist")]
        Task<ApiResponse<List<GetAllVanDeatailResponse>>> GetAllVanDetailList(VanMasterRequest request);

        [Get(path: "/api/vanmaster/getallvansdetails")]
        Task<ApiResponse<List<GetAllVanDeatailResponse>>> GetAllVanDetail();

        [Get(path: "/api/vanmaster/isinusecount")]
        Task<HttpResponseMessage> IsInUseCount(string vanId);

        [Delete(path: "/api/vanmaster/deletevan")]
        Task<HttpResponseMessage> DeleteVan(string vanId);

        [Get(path: "/api/vanmaster/isvannumberinuse")]
        Task<HttpResponseMessage> IsVanNumberInUse(string vanNumber);
    }
}
