#pragma checksum "D:\Shahen-WorkFront\Projects\CodeZen\CCC\CCC\Views\CenterMaster\ManageCenter.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5ce0fbe66d44405cfdcd266ff09cdd203a6fde59"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_CenterMaster_ManageCenter), @"mvc.1.0.view", @"/Views/CenterMaster/ManageCenter.cshtml")]
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
#line 1 "D:\Shahen-WorkFront\Projects\CodeZen\CCC\CCC\Views\CenterMaster\ManageCenter.cshtml"
using CCC.UI.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5ce0fbe66d44405cfdcd266ff09cdd203a6fde59", @"/Views/CenterMaster/ManageCenter.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6bc7222c5ea61ced56de2aeb71f1897d8d758eaa", @"/Views/_ViewImports.cshtml")]
    public class Views_CenterMaster_ManageCenter : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CenterMasterRequest>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "text", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("txtCenterName"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("placeholder", new global::Microsoft.AspNetCore.Html.HtmlString("Center Name"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "D:\Shahen-WorkFront\Projects\CodeZen\CCC\CCC\Views\CenterMaster\ManageCenter.cshtml"
  
    ViewData["Title"] = "Manage Center";
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
#line 27 "D:\Shahen-WorkFront\Projects\CodeZen\CCC\CCC\Views\CenterMaster\ManageCenter.cshtml"
                    Write(Url.Content("~/CenterMaster/FillTableCenterMasterAsync"));

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
            // ""aaSorting"": [[2, ""asc""]],
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
            WriteLiteral(@" ""aoColumns"":
                [

                    { ""data"": ""CenterName"", ""sName"": ""CenterName"" },
                    { ""data"": ""CenterAddress"", ""sName"": ""CenterAddress"" },
                    { ""data"": ""Description"", ""sName"": ""Description"" },
                    {
                        ""data"": ""CenterId"", ""sName"": """", ""class"": ""editTD"", ""orderable"": false, ""mRender"": function (data, type, full) {
                              if (data != null) {
                                   return ""<a class='AddEditBtnPop' onClick=EditEvent('"" + data + ""')><i class='fa fa-edit'></i></a>"";
                                //return ""<div class='tablehoverbuttons'> <i class='fa fa-ellipsis-h'></i> <div class='buttonshover'><div class='editbtn'><a class='' href='javascript:void(0);' onClick=EditEvent('"" + data + ""')><span><img title='Edit' src='");
#nullable restore
#line 65 "D:\Shahen-WorkFront\Projects\CodeZen\CCC\CCC\Views\CenterMaster\ManageCenter.cshtml"
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
                          ""data"": ""CenterId"", ""sName"": """", ""class"": ""deleteTD"", ""orderable"": false, ""mRender"": function (data, type, full) {
                              if (data != null) {
                                  return ""<a class='del' onClick=DeleteEvent('"" + data + ""')><i class='fa fa-trash'></i></a>"";
                                //return ""<div class='tablehoverbuttons'> <i class='fa fa-ellipsis-h'></i> <div class='buttonshover'><div class='editbtn'><a class='' href='javascript:void(0);' onClick=DeleteEvent('"" + data + ""')><span><img title='Delete' src='");
#nullable restore
#line 75 "D:\Shahen-WorkFront\Projects\CodeZen\CCC\CCC\Views\CenterMaster\ManageCenter.cshtml"
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
            searchObj.CenterName = $('#txtCenterName').val();
            return searchObj;
        }

        function fnFilterActivities() {
            searchObj = fnGetDataForActivities();
            var cnterName = searchObj.CenterName;
            $('#mydatata");
            WriteLiteral(@"ble').dataTable().fnMultiFilter({
                ""CenterName"": cnterName
            });
        }

        function clearfilter() {
            $('#txtCenterName').val('');
            fnFilterActivities();
        }

        $('#btnClear').click(function () {
            clearfilter();
        });


        $('#btnSearch1').click(function () {
            fnFilterActivities();
        });


        $(""#txtCenterName"").keyup(function (e) {
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
                        <li class=""breadcrumb-item active"" aria-current=""page"">Manage Centers</li>
                    </ol>
                </div>
                <div class=""filterMenuI");
            WriteLiteral("con\"></div>\r\n                <div class=\"pull-right mobileFilterMenu\">\r\n                    <ul class=\"headerListing\">\r\n");
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
                                        <label class=""pt20"">Center Name</label>
                                    </div>
                                </li>
                                <li class=""firstLastName"">
                                    <div class=""form-group"">");
            WriteLiteral("\n                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "5ce0fbe66d44405cfdcd266ff09cdd203a6fde5912821", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 167 "D:\Shahen-WorkFront\Projects\CodeZen\CCC\CCC\Views\CenterMaster\ManageCenter.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.CenterName);

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
            BeginWriteAttribute("src", " src=\'", 7755, "\'", 7796, 1);
#nullable restore
#line 172 "D:\Shahen-WorkFront\Projects\CodeZen\CCC\CCC\Views\CenterMaster\ManageCenter.cshtml"
WriteAttributeValue("", 7761, Url.Content("~/images/search.png"), 7761, 35, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" /> </button>\r\n                                        <button type=\"button\" class=\"btn btn-default btn-clear\" id=\"btnClear\"><img");
            BeginWriteAttribute("src", " src=\'", 7926, "\'", 7968, 1);
#nullable restore
#line 173 "D:\Shahen-WorkFront\Projects\CodeZen\CCC\CCC\Views\CenterMaster\ManageCenter.cshtml"
WriteAttributeValue("", 7932, Url.Content("~/images/refresh.png"), 7932, 36, false);

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
                            <th>Center Name</th>
                            <th>Address</th>
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
        <div id=""divDataTable_l");
            WriteLiteral("ength\"></div>\r\n    </div>\r\n\r\n</div>\r\n\r\n\r\n\r\n\r\n\r\n\r\n<script>\r\n\r\n");
            WriteLiteral("\r\n    function AddEvent() {\r\n          var url = \'");
#nullable restore
#line 218 "D:\Shahen-WorkFront\Projects\CodeZen\CCC\CCC\Views\CenterMaster\ManageCenter.cshtml"
                Write(Url.Action("AddEditCenter", "CenterMaster"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\';\r\n        document.location.href = url;\r\n        //AddEditDialog(url, \"Add New Center\");\r\n    }\r\n    function EditEvent(centerId) {\r\n      var url = \'");
#nullable restore
#line 223 "D:\Shahen-WorkFront\Projects\CodeZen\CCC\CCC\Views\CenterMaster\ManageCenter.cshtml"
            Write(Url.Action("AddEditCenter", "CenterMaster"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"?centerId=' + centerId + '';
      document.location.href = url;
    }


    //$(""#showBtnID"").click(function () {
    //    $("".hideShowfilter"").slideDown();
    //    $(""#showBtnID"").hide();
    //});

    //$(""#hideBtnId"").click(function () {
    //    $("".hideShowfilter"").slideUp();
    //    $(""#showBtnID"").show();
    //});

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

    function DeleteEvent(CenterId) {
                    $.confirm({
                title: 'Confirm',
                content: ""Are you sure want to delete this Center?"",
                buttons: {
                    confirm: function () {

                        $.ajax({
                            url: """);
#nullable restore
#line 261 "D:\Shahen-WorkFront\Projects\CodeZen\CCC\CCC\Views\CenterMaster\ManageCenter.cshtml"
                             Write(Url.Content("~/CenterMaster/IsInUseCount"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@""",
                            type: ""POST"",
                            dataType: ""json"",
                            data: { CenterId: CenterId },
                            success: function (result) {
                                if (result.isSuccess == true && parseInt(result.Count) > 0) {
                                    showWarningMsg('Center does not delete, This Center associated with the other data.');
                                }
                                else if (result.isSuccess == true && parseInt(result.Count) == 0) {
                                         $.ajax({
                                             url: """);
#nullable restore
#line 271 "D:\Shahen-WorkFront\Projects\CodeZen\CCC\CCC\Views\CenterMaster\ManageCenter.cshtml"
                                              Write(Url.Content("~/CenterMaster/DeleteCenter"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@""",
                                             type: ""Delete"",
                                             dataType: ""json"",
                                             data: { CenterId: CenterId },
                                             success: function (result) {

                                                 if (result.isSuccess == true) {
                                                     showSuccessMsg('Center deleted successfully.', BackToManage);
                                                }
                                                else {
                                                showWarningMsg('something went wrong');
                                                }
                                            }
                                        });
                                    }
                                    else {
                                    showWarningMsg('something went wrong');
                                    }
     ");
            WriteLiteral("                       }\r\n                        });\r\n\r\n\r\n\r\n\r\n\r\n                    },\r\n                    cancel: function () {\r\n\r\n                    }\r\n                }\r\n            });\r\n    }\r\n    function BackToManage() {\r\n        var url = \'");
#nullable restore
#line 304 "D:\Shahen-WorkFront\Projects\CodeZen\CCC\CCC\Views\CenterMaster\ManageCenter.cshtml"
              Write(Url.Action("ManageCenter", "CenterMaster"));

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CenterMasterRequest> Html { get; private set; }
    }
}
#pragma warning restore 1591
