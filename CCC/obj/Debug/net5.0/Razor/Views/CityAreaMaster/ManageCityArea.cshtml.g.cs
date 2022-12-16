#pragma checksum "D:\Shahen-WorkFront\Projects\CodeZen\CCC\CCC\Views\CityAreaMaster\ManageCityArea.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "414c4b98cabbb582b0f3d2b07a6256445ea5a28c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_CityAreaMaster_ManageCityArea), @"mvc.1.0.view", @"/Views/CityAreaMaster/ManageCityArea.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\Shahen-WorkFront\Projects\CodeZen\CCC\CCC\Views\_ViewImports.cshtml"
using CCC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Shahen-WorkFront\Projects\CodeZen\CCC\CCC\Views\_ViewImports.cshtml"
using CCC.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\Shahen-WorkFront\Projects\CodeZen\CCC\CCC\Views\CityAreaMaster\ManageCityArea.cshtml"
using CCC.UI.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"414c4b98cabbb582b0f3d2b07a6256445ea5a28c", @"/Views/CityAreaMaster/ManageCityArea.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6bc7222c5ea61ced56de2aeb71f1897d8d758eaa", @"/Views/_ViewImports.cshtml")]
    public class Views_CityAreaMaster_ManageCityArea : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CityAreaMasterRequest>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "text", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("txtAreaName"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("placeholder", new global::Microsoft.AspNetCore.Html.HtmlString("Area Name"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\Shahen-WorkFront\Projects\CodeZen\CCC\CCC\Views\CityAreaMaster\ManageCityArea.cshtml"
  
    ViewData["Title"] = "Manage CityArea";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral(@"


<script type=""text/javascript"">
    $(document).ready(function () {
        $(""#mydatatable"").tableHeadFixer({ ""head"": true, ""top"": 1 });
        var langUrl = $(""#LangUrl"").val();
        var mytable = $('#mydatatable').dataTable({
            ""ajax"": {
                 ""url"": """);
#nullable restore
#line 27 "D:\Shahen-WorkFront\Projects\CodeZen\CCC\CCC\Views\CityAreaMaster\ManageCityArea.cshtml"
                    Write(Url.Content("~/CityAreaMaster/FillTableCityAreaMasterAsync"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@""",
                ""type"": ""POST"",
                ""error"": function (x, y, z) {
                }
            },
            ""language"":
            {
                ""url"": langUrl
            },
            //""aaSorting"": [[1, ""asc""]],
            ""pageLength"": 50,
            ""serverSide"": true,
            ""bStateSave"": false,
           // ""pagingType"": ""listbox"",  //pagination type using pulgin
            ""processing"": true,
            ""pagingType"": ""full_numbers"",  //pagination type using pulgin
            ""dom"": '<""top""i>rt<""bottom""flp><""clear"">',
            ""filter"": false,
            ""oLanguage"": {
            ""oPaginate"": {
            ""sFirst"": ""<i class='fa fa-angle-double-left'></i>"",
            ""sPrevious"": ""«"",
            ""sNext"": ""»"",
            ""sLast"": ""<i class='fa fa-angle-double-right'></i>""
             }
            },
            //""sDom"": 'lrtip',
           ""bDeferRender"": true,//hide the default search filter textbox by removing ""f""
            ");
            WriteLiteral(@"""aoColumns"":
                [

                    { ""data"": ""AreaName"", ""sName"": ""AreaName"" },
                    { ""data"": ""Description"", ""sName"": ""Description"" },
                     {
                         ""data"": ""AreaId"", ""sName"": """", ""class"": ""editTD"", ""orderable"": false, ""mRender"": function (data, type, full) {
                             if (data != null) {
                                 return ""<a class='AddEditBtnPop' onClick=EditEvent('"" + data + ""')><i class='fa fa-edit'></i></a>"";
                                //return ""<div class='tablehoverbuttons'> <i class='fa fa-ellipsis-h'></i> <div class='buttonshover'><div class='editbtn'><a class='' href='javascript:void(0);' onClick=EditEvent('"" + data + ""')><span><img title='Edit' src='");
#nullable restore
#line 64 "D:\Shahen-WorkFront\Projects\CodeZen\CCC\CCC\Views\CityAreaMaster\ManageCityArea.cshtml"
                                                                                                                                                                                                                                                           Write(Url.Content("~/images/edit.png"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"' /></span></a></div> </div> </div>"";
                            }
                            else
                                return """";
                        }
                      },
                      {
                          ""data"": ""AreaId"", ""sName"": """", ""class"": ""deleteTD"", ""orderable"": false, ""mRender"": function (data, type, full) {
                              if (data != null) {
                                  return ""<a class='del' onClick=DeleteEvent('"" + data + ""')><i class='fa fa-trash'></i></a>"";
                                //return ""<div class='tablehoverbuttons'> <i class='fa fa-ellipsis-h'></i> <div class='buttonshover'><div class='editbtn'><a class='' href='javascript:void(0);' onClick=DeleteEvent('"" + data + ""')><span><img title='Delete' src='");
#nullable restore
#line 74 "D:\Shahen-WorkFront\Projects\CodeZen\CCC\CCC\Views\CityAreaMaster\ManageCityArea.cshtml"
                                                                                                                                                                                                                                                               Write(Url.Content("~/images/delete grey.png"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"' /></span></a></div> </div> </div>"";
                            }
                            else
                                return """";
                        }
                      },
                ]
        });
        mytable.on('order.dt', function () { $('.dataTables_paginate,.dataTables_info').show(); });
        mytable.on('length.dt', function (e, settings, len) { $('.dataTables_paginate,.dataTables_info').show(); });

        $(""#divDataTable_length"").append($("".dataTables_info""));
        $(""#divdataTables_info"").append($("".dataTables_length""));
        $(""#divdataTables_info"").append($("".dataTables_paginate""));

        function fnGetDataForActivities() {

            var searchObj = new Object();
            searchObj.AreaName = $('#txtAreaName').val();
            return searchObj;
        }

        function fnFilterActivities() {
            searchObj = fnGetDataForActivities();
            var areaName = searchObj.AreaName;
            $('#mydatatable').dat");
            WriteLiteral(@"aTable().fnMultiFilter({
                ""AreaName"": areaName
            });
        }

        function clearfilter() {
            $('#txtAreaName').val('');
            fnFilterActivities();
        }

        $('#btnClear').click(function () {
            clearfilter();
        });


        $('#btnSearch1').click(function () {
            fnFilterActivities();
        });


        $(""#txtAreaName"").keyup(function (e) {
            if (e.which == 13) {
                fnFilterActivities();
            }
        });

    });

</script>



<div class=""mainContent"">
    <div class=""conHeader"">
        <div class=""row"">
            <div class=""col-lg-12 col-md-12 col-sm-12 col-xs-12"">
                <div class=""pull-left"">
                    <ol class=""breadcrumb"">
                        <li class=""breadcrumb-item active"" aria-current=""page"">Manage City Area</li>
                    </ol>
                </div>
                <div class=""filterMenuIcon""></div>
 ");
            WriteLiteral("               <div class=\"pull-right mobileFilterMenu\">\r\n                    <ul class=\"headerListing\">\r\n");
            WriteLiteral(@"                        <li class=""active""> <a href=""javascript:void(0);"" onclick=""AddEvent()""><span class=""text"">Add</span> <span class=""icon iconUser"">&nbsp;</span></a></li>
                    </ul>
                </div>
            </div>
        </div>
    </div>

    <div class=""conInner"">
        <div class=""conInner"">
            <div class=""mobileFilter"">
                <div class=""hideShowfilter"">
                    <div class=""filterData mobilecofilters"">
                        <div class=""formGroupTop pos mobile4Lis"">
                            <ul class=""formGroupTopListing"">
                                <li>
                                    <div class=""form-group"" style=""margin-top:3px;"">
                                        <label class=""pt20"">Area Name</label>
                                    </div>
                                </li>
                                <li class=""firstLastName"">
                                    <div class=""form-group"">
 ");
            WriteLiteral("                                       ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "414c4b98cabbb582b0f3d2b07a6256445ea5a28c12752", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 165 "D:\Shahen-WorkFront\Projects\CodeZen\CCC\CCC\Views\CityAreaMaster\ManageCityArea.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.AreaName);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                    </div>
                                </li>
                                <li>
                                    <div class=""form-group"">
                                        <button type=""button"" class=""btn btn-primary btn-search"" id=""btnSearch1""><img");
            BeginWriteAttribute("src", " src=\'", 7655, "\'", 7696, 1);
#nullable restore
#line 170 "D:\Shahen-WorkFront\Projects\CodeZen\CCC\CCC\Views\CityAreaMaster\ManageCityArea.cshtml"
WriteAttributeValue("", 7661, Url.Content("~/images/search.png"), 7661, 35, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" /> </button>\r\n                                        <button type=\"button\" class=\"btn btn-default btn-clear\" id=\"btnClear\"><img");
            BeginWriteAttribute("src", " src=\'", 7826, "\'", 7868, 1);
#nullable restore
#line 171 "D:\Shahen-WorkFront\Projects\CodeZen\CCC\CCC\Views\CityAreaMaster\ManageCityArea.cshtml"
WriteAttributeValue("", 7832, Url.Content("~/images/refresh.png"), 7832, 36, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" /></button>
                                    </div>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <br /><br /><br />
        <div class=""chkTBL"">
            <div class=""bulkImpLogHT mngEventpage mobileTablenowrap"">
                <table id=""mydatatable"" class=""table"">
                    <thead>
                        <tr>
                            <th>Area Name</th>
                            <th>Description</th>
                            <th align=""left"" class=""editTD"">Edit</th>
                            <th align=""left"" class=""deleteTD"">Delete</th>
                        </tr>
                    </thead>
                    <tbody></tbody>
                </table>
            </div>
        </div>
        <div id=""divdataTables_info""></div>
        <div id=""divDataTable_length""></div>
    </div>

</div>





");
            WriteLiteral("\n<script>\r\n    function AddEvent() {\r\n          var url = \'");
#nullable restore
#line 209 "D:\Shahen-WorkFront\Projects\CodeZen\CCC\CCC\Views\CityAreaMaster\ManageCityArea.cshtml"
                Write(Url.Action("AddEditCityArea", "CityAreaMaster"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\';\r\n        document.location.href = url;\r\n        //AddEditDialog(url, \"Add New Center\");\r\n    }\r\n    function EditEvent(areaId) {\r\n        var url = \'");
#nullable restore
#line 214 "D:\Shahen-WorkFront\Projects\CodeZen\CCC\CCC\Views\CityAreaMaster\ManageCityArea.cshtml"
              Write(Url.Action("AddEditCityArea", "CityAreaMaster"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"?areaId=' + areaId + '';
      document.location.href = url;
    }

</script>

<script type=""text/javascript"">
    function AddEditDialog(_url, _title) {
        $.dialog({
            title: _title,
            content: 'url:' + _url,
            columnClass: 'col-md-8 col-md-offset-2',
            alignMiddle: true,
            onClose: function () {

            }
        });
    }

    function DeleteEvent(AreaId) {
                    $.confirm({
                title: 'Confirm',
                content: ""Are you sure want to delete this Area?"",
                buttons: {
                    confirm: function () {

                        $.ajax({
                            url: """);
#nullable restore
#line 241 "D:\Shahen-WorkFront\Projects\CodeZen\CCC\CCC\Views\CityAreaMaster\ManageCityArea.cshtml"
                             Write(Url.Content("~/CityAreaMaster/IsInUseCount"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@""",
                            type: ""POST"",
                            dataType: ""json"",
                            data: { areaId: AreaId },
                            success: function (result) {
                                if (result.isSuccess == true && parseInt(result.Count) > 0) {
                                    showWarningMsg('Area does not delete, This area associated with the other data.');
                                }
                                else if (result.isSuccess == true && parseInt(result.Count) == 0) {
                                         $.ajax({
                                             url: """);
#nullable restore
#line 251 "D:\Shahen-WorkFront\Projects\CodeZen\CCC\CCC\Views\CityAreaMaster\ManageCityArea.cshtml"
                                              Write(Url.Content("~/CityAreaMaster/DeleteCityArea"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@""",
                                             type: ""Delete"",
                                             dataType: ""json"",
                                             data: { areaId: AreaId },
                                             success: function (result) {
                                                 
                                                 if (result.isSuccess == true) {
                                                 showSuccessMsg('Area deleted successfully.', BackToManage);
                                                //showSuccessMsg('Area deleted successfully.');
                                                //location.reload();
                                                }
                                                else {
                                                showWarningMsg('something went wrong');
                                                }
                                            }
                                        });");
            WriteLiteral(@"
                                    }
                                    else {
                                    showWarningMsg('something went wrong');
                                    }
                            }
                        });
                    },
                    cancel: function () {

                    }
                }
            });
    }

      function BackToManage() {
        var url = '");
#nullable restore
#line 282 "D:\Shahen-WorkFront\Projects\CodeZen\CCC\CCC\Views\CityAreaMaster\ManageCityArea.cshtml"
              Write(Url.Action("ManageCityArea", "CityAreaMaster"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\';\r\n        document.location.href = url;\r\n    }\r\n</script>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CityAreaMasterRequest> Html { get; private set; }
    }
}
#pragma warning restore 1591
