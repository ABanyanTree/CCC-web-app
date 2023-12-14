using CCC.UI.RefitClientFactory;
using CCC.UI.Utility;
using CCC.UI.ViewModels;
using DataTables.Mvc;
using Microsoft.AspNetCore.Mvc;
using Refit;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCC.UI.Controllers
{
	public class VetMasterController : Controller
    {
        public async Task<ActionResult> ManageVet()
        {
            VetMasterRequest obj = new VetMasterRequest();
            return View(obj);
        }

        [HttpPost("/VetMaster/FillTableVetMasterAsync")]
        public async Task<IActionResult> FillTableVetMasterAsync([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest dt)
        {
            var objSessionUSer = HttpContext.Session.GetSessionUser();

            List<ColumnNameValue> colList = new List<ColumnNameValue>();
            ColumnNameValue columns = new ColumnNameValue();

            int iPageSize;
            string sortdir = " asc ";
            int TotalCount = 0;

            if (dt.Length <= 0)
                iPageSize = 10;
            else
                iPageSize = dt.Length;

            if (dt.SortDirection.Equals(Column.OrderDirection.Ascendant))
                sortdir = " asc ";
            else
                sortdir = " desc ";

            VetMasterRequest searchObj = new VetMasterRequest();
            //searchObj. = objSessionUSer.UserId;
            //if (Active == "1")
            //    searchObj.Status = true;

            if (!string.IsNullOrEmpty(dt.SortColumnName))
                searchObj.SortExp = dt.SortColumnName + " " + sortdir;

            searchObj.PageSize = iPageSize;

            if (dt.PageIndex == 0)
                searchObj.PageIndex = 1;
            else
                searchObj.PageIndex = dt.PageIndex;

            foreach (var col in dt.Columns)
            {
                columns = new ColumnNameValue();
                if (!string.IsNullOrEmpty(col.Search.Value))
                {
                    columns.ColName = col.Name;
                    columns.ColValue = col.Search.Value;
                    colList.Add(columns);
                    switch (col.Name)
                    {
                        case "VetName":
                            if (!string.IsNullOrEmpty(col.Search.Value))
                            {
                                searchObj.VetName = col.Search.Value.Trim();
                            }
                            break;
                    }
                }
            }

            var cachedToken = HttpContext.Session.GetBearerToken();

            var vetMasterAPI = RestService.For<IVetMasterApi>(hostUrl: ApplicationSettings.WebApiUrl, new RefitSettings
            {
                AuthorizationHeaderValueGetter = () => Task.FromResult(cachedToken)
            });
            var apiResponse = await vetMasterAPI.GetAllVetList(searchObj);
            var response = apiResponse.Content;

            var lst = response;

            var lst1 = lst?.ToList();

            if (lst1 != null && lst1.Count > 0)
            {
                TotalCount = lst1[0].TotalCount;
            }
            bool set = false;
            if (searchObj.PageIndex > 1 && TotalCount == 0)
                set = true;
            return Json(new DataTablesResponse(dt.Draw, lst1, TotalCount, TotalCount, colList, set));
        }

        [HttpGet]
        public async Task<IActionResult> AddEditVet(string vetId)
        {
            var objSessionUser = HttpContext.Session.GetSessionUser();
            var cachedToken = HttpContext.Session.GetBearerToken();


            var vetMasterAPI = RestService.For<IVetMasterApi>(hostUrl: ApplicationSettings.WebApiUrl, new RefitSettings
            {
                AuthorizationHeaderValueGetter = () => Task.FromResult(cachedToken)
            });

            VetMasterRequest model = new VetMasterRequest();
            if (!string.IsNullOrEmpty(vetId))
            {
                var updateResponse = await vetMasterAPI.GetVetDetail(vetId);
                model = updateResponse.Content;
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddEditVet(VetMasterRequest model)
        {
            bool IsNewRecord = string.IsNullOrEmpty(model.VetId) ? true : false;
            VetMasterRequest modelobj = new VetMasterRequest();

            var objSessionUSer = HttpContext.Session.GetSessionUser();
            var cachedToken = HttpContext.Session.GetBearerToken();

            var vetMasterAPI = RestService.For<IVetMasterApi>(hostUrl: ApplicationSettings.WebApiUrl, new RefitSettings
            {
                AuthorizationHeaderValueGetter = () => Task.FromResult(cachedToken)
            });
            model.CreatedBy = objSessionUSer.UserId;
            var apiResponse = await vetMasterAPI.AddEditVet(model);
            string vetId = apiResponse?.Content?.ReadAsStringAsync().Result;

            if (apiResponse != null && apiResponse.IsSuccessStatusCode)
            {
                string msg = IsNewRecord ? "Vet Details added successfully." : "Vet Details updated successfully.";
                return Json(new { VetId = vetId, VetName = model.VetName, isSuccess = true, message = msg });
            }
            else
            {
                return Json(new { VetId = 0, isSuccess = false, message = "" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> IsInUseCount(string vetId)
        {
            VetMasterRequest modelobj = new VetMasterRequest();

            var objSessionUSer = HttpContext.Session.GetSessionUser();
            var cachedToken = HttpContext.Session.GetBearerToken();
            var vetMasterAPI = RestService.For<IVetMasterApi>(hostUrl: ApplicationSettings.WebApiUrl, new RefitSettings
            {
                AuthorizationHeaderValueGetter = () => Task.FromResult(cachedToken)
            });
            var apiResponse = await vetMasterAPI.IsInUseCount(vetId);
            string Count = apiResponse?.Content?.ReadAsStringAsync().Result;

            if (apiResponse != null && apiResponse.IsSuccessStatusCode)
            {
                return Json(new { isSuccess = true, Count = Count });
            }
            else
            {
                return Json(new { isSuccess = false, Count = 0 });
            }

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteVet(string vetId)
        {
            VetMasterRequest modelobj = new VetMasterRequest();

            var objSessionUSer = HttpContext.Session.GetSessionUser();
            var cachedToken = HttpContext.Session.GetBearerToken();
            var vetMasterAPI = RestService.For<IVetMasterApi>(hostUrl: ApplicationSettings.WebApiUrl, new RefitSettings
            {
                AuthorizationHeaderValueGetter = () => Task.FromResult(cachedToken)
            });
            var apiResponse = await vetMasterAPI.DeleteVet(vetId);

            if (apiResponse != null && apiResponse.IsSuccessStatusCode)
            {
                return Json(new { isSuccess = true });
            }
            else
            {
                return Json(new { isSuccess = false });
            }

        }

        [HttpPost]
        public async Task<JsonResult> IsVetNameInUse(string vetName, string vetId = "")
        {
            if (vetName == null || string.IsNullOrEmpty(vetName.Trim()))
            {
                return Json("Please enter vet Name");
            }
            else
            {
                var objSessionUser = HttpContext.Session.GetSessionUser();
                var cachedToken = HttpContext.Session.GetBearerToken();
                var vetMasterAPI = RestService.For<IVetMasterApi>(hostUrl: ApplicationSettings.WebApiUrl, new RefitSettings
                {
                    AuthorizationHeaderValueGetter = () => Task.FromResult(cachedToken)
                });

                var IsNameExists = false;
                var apiResponse = await vetMasterAPI.IsVetNameInUse(vetName.Trim());
                if (apiResponse != null)
                {
                    if (string.IsNullOrEmpty(vetId))
                    {
                        IsNameExists = (apiResponse.Content == null) ? false : true;
                    }
                    else
                    {
                        IsNameExists = apiResponse.Content == null ? false :
                            (vetId != apiResponse.Content.VetId) ? true : false;
                    }
                }
                return Json(IsNameExists);
            }
        }

        public async Task<IActionResult> AddVetQuick()
        {
            VetMasterRequest model = new VetMasterRequest();
            return PartialView("_AddVetQuick", model);
        }
    }
}
