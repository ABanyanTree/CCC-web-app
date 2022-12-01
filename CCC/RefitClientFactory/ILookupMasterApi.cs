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
    interface ILookupMasterApi
    {
        [Get(path: "/api/lookupmaster/getlookuptypes")]
        Task<ApiResponse<List<GetLookupResponse>>> GetLookupTypes();

        [Get(path: "/api/lookupmaster/getalllookuplist")]
        Task<ApiResponse<List<GetLookupResponse>>> GetAllLookupList(LookupMasterRequest obj);

        [Get(path: "/api/lookupmaster/getlookupbytype")]
        Task<ApiResponse<List<GetLookupResponse>>> GetLookupData(string lookupType);

        [Get(path: "/api/lookupmaster/getlookup")]
        Task<ApiResponse<LookupMasterRequest>> GetLookup(string lookupId);

        [Post(path: "/api/lookupmaster/addeditlookup")]
        Task<HttpResponseMessage> AddEditLookup(LookupMasterRequest request);

        [Get(path: "/api/lookupmaster/isinusecount")]
        Task<HttpResponseMessage> IsInUseCount(string lookupId);

        [Delete(path: "/api/lookupmaster/deletelookup")]
        Task<HttpResponseMessage> DeleteLookup(string lookupId);

        [Get(path: "/api/lookupmaster/islookupnameinuse")]
        Task<HttpResponseMessage> IsCityAreaNameInUse(string LookupValue);
    }
}
