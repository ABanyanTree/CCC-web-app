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
    public interface IPetServiceApi
    {
        [Get(path: "/api/petservice/getpetdata")]
        Task<ApiResponse<CreatePetService>> GetPetData(string serviceId);

        [Post(path: "/api/petservice/addeditpetdata")]
        Task<HttpResponseMessage> AddEditPetData(CreatePetService request);

        [Get(path: "/api/petservice/getallpetdata")]
        Task<ApiResponse<List<GetAllPetDataResponse>>> GetAllPetDataList(SearchPetData request);

        [Post(path: "/api/petservice/changepetcenters")]
        Task<HttpResponseMessage> ChangePetCenters(CreatePetService request);

        [Get(path: "/api/petservice/getvetreport")]
        Task<ApiResponse<List<GetAllPetDataResponse>>> GetVetReport(SearchPetData request);

        [Get(path: "/api/petservice/getcentermgrdahsboardlist")]
        Task<ApiResponse<List<GetAllPetDataResponse>>> GetCenterMgrDashboardList(SearchPetData request);

        [Post(path: "/api/petservice/addpetdatanotification")]
        Task<HttpResponseMessage> AddPetDataNotification(PetDataNotificationRequest request);

        [Get(path: "/api/petservice/readpetdatabyuser")]
        Task<ApiResponse<List<PetDataNotificationResponse>>> ReadPetDataByUser(string userId, bool IsAdmin);

        [Get(path: "/api/petservice/getpetunreaddata")]
        Task<ApiResponse<PetDataNotificationResponse>> GetPetUnReadData(string userId, bool IsAdmin);

        [Get(path: "/api/petservice/getpetcountdetails")]
        Task<ApiResponse<List<PetCountDetails>>> GetPetCountDetails();

        [Get(path: "/api/petservice/getcenterreportdata")]
        Task<ApiResponse<List<GetAllPetDataResponse>>> GetCenterReportData(SearchPetData request);



    }
}
