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
    public interface ICenterMasterApi
    {
        [Get(path: "/api/centerMaster/getcenter")]
        Task<ApiResponse<CenterMasterRequest>> GetCenter(string centerId);

        [Post(path: "/api/centerMaster/addeditcenter")]
        Task<HttpResponseMessage> AddEditCenter(CenterMasterRequest request);

        [Get(path: "/api/centerMaster/getallcenterlist")]
        Task<ApiResponse<List<GetCentersResponse>>> GetAllCenterList(CenterMasterRequest request);

        [Get(path: "/api/centerMaster/getallcenters")]
        Task<ApiResponse<List<GetCentersResponse>>> GetAllCenters();

        [Get(path: "/api/centerMaster/isinusecount")]
        Task<HttpResponseMessage> IsInUseCount(string centerId);

        [Delete(path: "/api/centerMaster/deletecenter")]
        Task<HttpResponseMessage> DeleteCenter(string centerId);

        [Get(path: "/api/centerMaster/iscenternameinuse")]
        Task<ApiResponse<CenterMasterRequest>> IsCenterNameInUse(string CenterName);
    }
}
