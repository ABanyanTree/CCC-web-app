using CCC.UI.RefitClientFactory;
using CCC.UI.Utility;
using CCC.UI.ViewModels;
using DataTables.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Refit;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCC.UI.Controllers
{
	public class LookupMasterController : Controller
    {
        public async Task<ActionResult> ManageLookup()
        {
            LookupMasterRequest obj = new LookupMasterRequest();
            var objSessionUser = HttpContext.Session.GetSessionUser();
            var cachedToken = HttpContext.Session.GetBearerToken();

            var LookupMasterAPI = RestService.For<ILookupMasterApi>(hostUrl: ApplicationSettings.WebApiUrl, new RefitSettings
            {
                AuthorizationHeaderValueGetter = () => Task.FromResult(cachedToken)
            });

            var lookupTypes = await LookupMasterAPI.GetLookupTypes();
            ViewBag.lstLookupTypes = new SelectList(lookupTypes.Content, "LookupType", "LookupTypeText");
            return View(obj);
        }

        [HttpPost("/LookupMaster/FillTableLookupMasterAsync")]
        public async Task<IActionResult> FillTableLookupMasterAsync([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest dt)
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

            LookupMasterRequest searchObj = new LookupMasterRequest();
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
                        case "LookupType":
                            if (!string.IsNullOrEmpty(col.Search.Value))
                            {
                                searchObj.LookupType = col.Search.Value.Trim();
                            }
                            break;
                    }
                }
            }

            var cachedToken = HttpContext.Session.GetBearerToken();

            var LookupAPI = RestService.For<ILookupMasterApi>(hostUrl: ApplicationSettings.WebApiUrl, new RefitSettings
            {
                AuthorizationHeaderValueGetter = () => Task.FromResult(cachedToken)
            });
            var apiResponse = await LookupAPI.GetAllLookupList(searchObj);
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
        public async Task<IActionResult> AddEditLookup(string lookupId)
        {
            var objSessionUser = HttpContext.Session.GetSessionUser();
            var cachedToken = HttpContext.Session.GetBearerToken();


            var LookupAPI = RestService.For<ILookupMasterApi>(hostUrl: ApplicationSettings.WebApiUrl, new RefitSettings
            {
                AuthorizationHeaderValueGetter = () => Task.FromResult(cachedToken)
            });

            LookupMasterRequest model = new LookupMasterRequest();
            var lookupTypes = await LookupAPI.GetLookupTypes();
            ViewBag.lstLookupTypes = new SelectList(lookupTypes.Content, "LookupType", "LookupTypeText");
            if (!string.IsNullOrEmpty(lookupId))
            {
                var updateResponse = await LookupAPI.GetLookup(lookupId);
                model = updateResponse.Content;
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddEditLookup(LookupMasterRequest model)
        {
            bool IsNewRecord = string.IsNullOrEmpty(model.LookupId) ? true : false;
            LookupMasterRequest modelobj = new LookupMasterRequest();

            var objSessionUSer = HttpContext.Session.GetSessionUser();
            var cachedToken = HttpContext.Session.GetBearerToken();

            var LookupAPI = RestService.For<ILookupMasterApi>(hostUrl: ApplicationSettings.WebApiUrl, new RefitSettings
            {
                AuthorizationHeaderValueGetter = () => Task.FromResult(cachedToken)
            });

            model.CreatedBy = objSessionUSer.UserId;
            var apiResponse = await LookupAPI.AddEditLookup(model);
            string lookupId = apiResponse?.Content?.ReadAsStringAsync().Result;

            if (apiResponse != null && apiResponse.IsSuccessStatusCode)
            {
                string msg = IsNewRecord ? "Area added successfully." : "Area updated successfully.";
                return Json(new { LookupId = lookupId, LookupValue = model.LookupValue, isSuccess = true, message = msg });
            }
            else
            {
                return Json(new { LookupId = 0, isSuccess = false, message = "" });
            }
        }


        public async Task<IActionResult> AddMedicalNotesQuick()
        {
            LookupMasterRequest model = new LookupMasterRequest();
            var objSessionUSer = HttpContext.Session.GetSessionUser();
            var cachedToken = HttpContext.Session.GetBearerToken();
            model.LookupType = CommonConstants.LOOKUPTYPE_MEDICALNOTES;
            return PartialView("_AddMedicalNotesQuick", model);
        }


    }
}
