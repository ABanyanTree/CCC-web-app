#pragma checksum "D:\Shahen-WorkFront\Applications\CCC\CCC\Views\Report\ManageVetReport.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "635fe3767c28291cf079380ba62fd723da6b9753"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Report_ManageVetReport), @"mvc.1.0.view", @"/Views/Report/ManageVetReport.cshtml")]
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
#line 1 "D:\Shahen-WorkFront\Applications\CCC\CCC\Views\_ViewImports.cshtml"
using CCC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Shahen-WorkFront\Applications\CCC\CCC\Views\_ViewImports.cshtml"
using CCC.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\Shahen-WorkFront\Applications\CCC\CCC\Views\Report\ManageVetReport.cshtml"
using CCC.UI.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"635fe3767c28291cf079380ba62fd723da6b9753", @"/Views/Report/ManageVetReport.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6bc7222c5ea61ced56de2aeb71f1897d8d758eaa", @"/Views/_ViewImports.cshtml")]
    public class Views_Report_ManageVetReport : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SearchPetData>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/autocomplete.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/bootstrap-datepicker/css/bootstrap-datepicker.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/bootstrap-datepicker/js/bootstrap-datepicker.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/jquery.btnswitch.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/jquery.btnswitch.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/jquery-ui.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/bootstrap-multiselect/bootstrap-multiselect.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/bootstrap-multiselect/bootstrap-multiselect.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("ddlCenter"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_12 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("ddlMonth"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_13 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("ddlYear"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\Shahen-WorkFront\Applications\CCC\CCC\Views\Report\ManageVetReport.cshtml"
  
    ViewData["Title"] = "ManageVetReport";
    Layout = "~/Views/Shared/_Layout.cshtml";

    SelectList lstCenter = ViewBag.lstCenter;
    SelectList lstMonth = ViewBag.lstMonth;
    SelectList lstYears = ViewBag.lstYears;
    //SelectList lstVet = ViewBag.lstVet;
    //SelectList lstPetType = ViewBag.lstPetType;


#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "635fe3767c28291cf079380ba62fd723da6b97539084", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "635fe3767c28291cf079380ba62fd723da6b975310198", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "635fe3767c28291cf079380ba62fd723da6b975311313", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "635fe3767c28291cf079380ba62fd723da6b975312353", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "635fe3767c28291cf079380ba62fd723da6b975313393", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "635fe3767c28291cf079380ba62fd723da6b975314508", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "635fe3767c28291cf079380ba62fd723da6b975315627", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "635fe3767c28291cf079380ba62fd723da6b975316742", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

<script type=""text/javascript"">
    $(document).ready(function () {

        $(""#mydatatable"").tableHeadFixer({ ""head"": true, ""top"": 1 });
        var langUrl = $(""#LangUrl"").val();
        var mytable = $('#mydatatable').dataTable({
            ""ajax"": {
                ""url"": """);
#nullable restore
#line 33 "D:\Shahen-WorkFront\Applications\CCC\CCC\Views\Report\ManageVetReport.cshtml"
                   Write(Url.Content("~/Report/FillTableVetReportAsync"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@""",
                ""type"": ""POST"",
                ""error"": function (x, y, z) {
                }
            },
            ""dataSrc"": function (json) {
                if (json.Columns != null && json.Columns.length > 0) {
                    for (var i = 0; i < json.Columns.length; i++) {
                        //if (json.Columns[i].ColName == ""ShowName"")
                        //    $("".filterShowName"").val(json.Columns[i].ColValue);
                    }
                }
                if (json.IsResetPaging) {
                    mytable.fnPageChange(0);
                }
                return json.data;
            },
            ""aaSorting"": [[1, ""asc""]],
            ""pageLength"": 50,
            ""serverSide"": true,
            ""bStateSave"": false,
            // ""pagingType"": ""listbox"",  //pagination type using pulgin
            ""processing"": true,
            ""pagingType"": ""full_numbers"",  //pagination type using pulgin
            ""dom"": '<""top""i>rt<""bottom""flp><""clea");
            WriteLiteral(@"r"">',
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
            ""aoColumns"":
                [
                    { ""data"": ""CenterName"", ""sName"": ""Center Name"" },
                    { ""data"": ""AreaName"", ""sName"": ""Area Name"" },
                    { ""data"": ""VetName"", ""sName"": ""Vet Name"" },
                    { ""data"": ""PetType"", ""sName"": ""PetType"" },
                    { ""data"": ""SurgeryDateDisplay"", ""sName"": ""SurgeryDate"" },
                    { ""data"": ""MedicalComments"", ""sName"": ""Medical Comments"" },
                    { ""data"": ""CenterId"", ""sName"": ""CenterId"", ""visible"": fa");
            WriteLiteral(@"lse },
                    { ""data"": ""Month"", ""sName"": ""Month"", ""visible"": false },
                    { ""data"": ""Year"", ""sName"": ""Year"", ""visible"": false }
                    //{ ""data"": ""SurgeryDateFrom"", ""sName"": ""SurgeryDateFrom"", ""visible"": false },
                    //{ ""data"": ""SurgeryDateTo"", ""sName"": ""SurgeryDateTo"", ""visible"": false }
                ]
        });
        mytable.on('order.dt', function () { $('.dataTables_paginate,.dataTables_info').show(); });
        mytable.on('length.dt', function (e, settings, len) { $('.dataTables_paginate,.dataTables_info').show(); });

        $(""#divDataTable_length"").append($("".dataTables_info""));
        $(""#divdataTables_info"").append($("".dataTables_length""));
        $(""#divdataTables_info"").append($("".dataTables_paginate""));

        function fnGetDataForActivities() {
            var searchObj = new Object();
            searchObj.CenterId = $('#ddlCenter').val();
            searchObj.Month = $('#ddlMonth').val();
            s");
            WriteLiteral(@"earchObj.Year = $('#ddlYear').val();
            return searchObj;
        }

        function fnFilterActivities() {
            searchObj = fnGetDataForActivities();
            $(""#mydatatable"").dataTable().fnMultiFilter({
                ""CenterId"": searchObj.CenterId,
                ""Month"": searchObj.Month ,
                ""Year"": searchObj.Year
            });
        }

        function clearfilter() {
            $('#pnlSearch').find('input:text').val('');
            $(""#pnlSearch select"").each(function () {
                $(this).val('');
            });
            fnFilterActivities();
        }

        $('#btnClear').click(function () {
            clearfilter();
        });


        $('#btnSearch1').click(function () {
            fnFilterActivities();
        });
    });

</script>

<div class=""mainContent"">
    <div class=""conHeader"">
        <div class=""row"">
            <div class=""col-lg-12 col-md-12 col-sm-12 col-xs-12"">
                <div class");
            WriteLiteral(@"=""pull-left"">
                    <ol class=""breadcrumb"">
                        <li class=""breadcrumb-item active"" aria-current=""page"">Vet Report</li>
                    </ol>
                </div>
            </div>
        </div>
    </div>
    <div class=""conInner"">
        <div class=""conInner"">
            <div class=""mobileFilter"">
                <div class=""hideShowfilter"">
                    <div class=""filterData mobilecofilters"">
                        <div class=""formGroupTop pos mobile4Lis"" id=""pnlSearch"">
                            <div class=""row"">
                                <div class=""col-lg-3 col-md-3 col-sm-3 col-xs-12"">
                                    <div class=""form-group"">
                                        <label>Center</label>
                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "635fe3767c28291cf079380ba62fd723da6b975323643", async() => {
                WriteLiteral("\r\n                                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "635fe3767c28291cf079380ba62fd723da6b975323948", async() => {
                    WriteLiteral("--Select--");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_9.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_9);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
#nullable restore
#line 150 "D:\Shahen-WorkFront\Applications\CCC\CCC\Views\Report\ManageVetReport.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.CenterId);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 150 "D:\Shahen-WorkFront\Applications\CCC\CCC\Views\Report\ManageVetReport.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = lstCenter;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_11);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                        <span id=""spCenterId"" class=""redColor""></span>
                                    </div>
                                </div>
                                <div class=""col-lg-3 col-md-3 col-sm-3 col-xs-12"">
                                    <div class=""form-group"">
                                        <label>Month</label>
                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "635fe3767c28291cf079380ba62fd723da6b975327486", async() => {
                WriteLiteral("\r\n                                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
#nullable restore
#line 159 "D:\Shahen-WorkFront\Applications\CCC\CCC\Views\Report\ManageVetReport.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Month);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 159 "D:\Shahen-WorkFront\Applications\CCC\CCC\Views\Report\ManageVetReport.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = lstMonth;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_12);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_11);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                        <span id=""spMonth"" class=""redColor""></span>
                                    </div>
                                </div>
                                <div class=""col-lg-3 col-md-3 col-sm-3 col-xs-12"">
                                    <div class=""form-group"">
                                        <label>Year</label>
                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "635fe3767c28291cf079380ba62fd723da6b975330049", async() => {
                WriteLiteral("\r\n                                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
#nullable restore
#line 167 "D:\Shahen-WorkFront\Applications\CCC\CCC\Views\Report\ManageVetReport.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Year);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 167 "D:\Shahen-WorkFront\Applications\CCC\CCC\Views\Report\ManageVetReport.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = lstYears;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_13);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_11);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                        <span id=""spYear"" class=""redColor""></span>
                                    </div>
                                </div>
                                <div class=""col-lg-3 col-md-3 col-sm-3 col-xs-12"">
                                    <div class=""form-group"">
                                        <div class=""row""></div><br />
                                        <div class=""row"">
                                            <button type=""button"" class=""btn btn-primary btn-search"" id=""btnSearch1""><img");
            BeginWriteAttribute("src", " src=\'", 8189, "\'", 8230, 1);
#nullable restore
#line 176 "D:\Shahen-WorkFront\Applications\CCC\CCC\Views\Report\ManageVetReport.cshtml"
WriteAttributeValue("", 8195, Url.Content("~/images/search.png"), 8195, 35, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" /> </button>&nbsp;\r\n                                            <button type=\"button\" class=\"btn btn-default btn-clear\" id=\"btnClear\"><img");
            BeginWriteAttribute("src", " src=\'", 8370, "\'", 8412, 1);
#nullable restore
#line 177 "D:\Shahen-WorkFront\Applications\CCC\CCC\Views\Report\ManageVetReport.cshtml"
WriteAttributeValue("", 8376, Url.Content("~/images/refresh.png"), 8376, 36, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" /></button>
                                        </div>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class=""row"">
        <div class=""col-lg-12 col-md-12 col-sm-12 col-xs-12"">
            <div class=""userBoxFooter"">
                <div class=""pull-right"">
                    <div class=""form-group""></div>
                    <button type=""button"" class=""btn btn-primary btn-search"" id=""btnExportExcel"">Export Exel</button>
                </div>
            </div>
        </div>
    </div>

    <div class=""chkTBL"">
        <div class=""bulkImpLogHT mngEventpage mobileTablenowrap"">
            <table id=""mydatatable"" class=""table"">
                <thead>
                    <tr>
                        <th>Center Name</th>
                        <th>Area Name</th>
        ");
            WriteLiteral(@"                <th>Vet Name</th>
                        <th>Pet</th>
                        <th>Surgery Date</th>
                        <th>Medical Notes/Comments</th>
                    </tr>
                </thead>
                <tbody></tbody>
            </table>
        </div>
    </div>
    <div id=""divdataTables_info""></div>
    <div id=""divDataTable_length""></div>
</div>

<script>
    $(""#btnExportExcel"").on('click', function () {
        var searchObj = new Object();
        var CenterId = $('#ddlCenter').val();
        var Month = $('#ddlMonth').val();
        var Year = $('#ddlYear').val();

        if (CenterId == '' || CenterId == null || CenterId == undefined) {
            showWarningMsg(""Please select center"");
            return;
        }

        var url = '");
#nullable restore
#line 233 "D:\Shahen-WorkFront\Applications\CCC\CCC\Views\Report\ManageVetReport.cshtml"
              Write(Url.Action("ExportVetReport", "Report"));

#line default
#line hidden
#nullable disable
            WriteLiteral("?CenterId=\' + CenterId + \'&selectedMonth=\' + Month + \'&selectedYear=\' + Year;\r\n        document.location.href = url;\r\n\r\n");
            WriteLiteral("\r\n\r\n    });\r\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SearchPetData> Html { get; private set; }
    }
}
#pragma warning restore 1591
