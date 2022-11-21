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
    public interface ICityAreaMasterApi
    {
        [Get(path: "/api/cityareamaster/getcityarea")]
        Task<ApiResponse<CityAreaMasterRequest>> GetCityArea(string areaId);

        [Post(path: "/api/cityareamaster/addeditcityarea")]
        Task<HttpResponseMessage> AddEditCityArea(CityAreaMasterRequest request);

        [Get(path: "/api/cityareamaster/getallcityarealist")]
        Task<ApiResponse<List<GetCityAreaResponse>>> GetAllCityAreaList(CityAreaMasterRequest request);

        [Get(path: "/api/cityareamaster/getallcityareas")]
        Task<ApiResponse<List<GetCityAreaResponse>>> GetAllCityAreas();

        [Get(path: "/api/cityareamaster/isinusecount")]
        Task<HttpResponseMessage> IsInUseCount(string areaId);

        [Delete(path: "/api/cityareamaster/deletecityarea")]
        Task<HttpResponseMessage> DeleteArea(string areaId);

        [Get(path: "/api/cityareamaster/iscityareanameinuse")]
        Task<HttpResponseMessage> IsCityAreaNameInUse(string areaName);

       


    }
}
