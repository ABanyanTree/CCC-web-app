#pragma checksum "D:\Shahen-WorkFront\Applications\CCC\CCC\Views\VetMaster\ManageVet.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "537646c5220e102ba902435b559179890adaccdc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_VetMaster_ManageVet), @"mvc.1.0.view", @"/Views/VetMaster/ManageVet.cshtml")]
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
#line 1 "D:\Shahen-WorkFront\Applications\CCC\CCC\Views\VetMaster\ManageVet.cshtml"
using CCC.UI.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"537646c5220e102ba902435b559179890adaccdc", @"/Views/VetMaster/ManageVet.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6bc7222c5ea61ced56de2aeb71f1897d8d758eaa", @"/Views/_ViewImports.cshtml")]
    public class Views_VetMaster_ManageVet : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<VetMasterRequest>
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
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "text", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("txtVetName"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_12 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("placeholder", new global::Microsoft.AspNetCore.Html.HtmlString("Vet Name"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\Shahen-WorkFront\Applications\CCC\CCC\Views\VetMaster\ManageVet.cshtml"
  
    ViewData["Title"] = "Manage Vet data";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "537646c5220e102ba902435b559179890adaccdc8365", async() => {
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "537646c5220e102ba902435b559179890adaccdc9479", async() => {
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "537646c5220e102ba902435b559179890adaccdc10593", async() => {
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "537646c5220e102ba902435b559179890adaccdc11633", async() => {
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "537646c5220e102ba902435b559179890adaccdc12673", async() => {
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "537646c5220e102ba902435b559179890adaccdc13788", async() => {
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
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "537646c5220e102ba902435b559179890adaccdc14903", async() => {
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "537646c5220e102ba902435b559179890adaccdc16018", async() => {
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

<div class=""mainContent"">
    <div class=""conHeader"">
        <div class=""row"">
            <div class=""col-lg-12 col-md-12 col-sm-12 col-xs-12"">
                <div class=""pull-left"">
                    <ol class=""breadcrumb"">
                        <li class=""breadcrumb-item active"" aria-current=""page"">Manage Vet Details</li>
                    </ol>
                </div>
                <div class=""filterMenuIcon""></div>
                <div class=""pull-right mobileFilterMenu"">
                    <ul class=""headerListing"">
");
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
                                        <label class=""pt20"">Vet Name</label>
                                    </div>
                                </li>
                                <li class=""firstLastName"">
                                    <div class=""form-group"">
    ");
            WriteLiteral("                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "537646c5220e102ba902435b559179890adaccdc18788", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 51 "D:\Shahen-WorkFront\Applications\CCC\CCC\Views\VetMaster\ManageVet.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.VetName);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_9.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_9);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_11);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_12);
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
            BeginWriteAttribute("src", " src=\'", 2950, "\'", 2991, 1);
#nullable restore
#line 56 "D:\Shahen-WorkFront\Applications\CCC\CCC\Views\VetMaster\ManageVet.cshtml"
WriteAttributeValue("", 2956, Url.Content("~/images/search.png"), 2956, 35, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" /> </button>\r\n                                        <button type=\"button\" class=\"btn btn-default btn-clear\" id=\"btnClear\"><img");
            BeginWriteAttribute("src", " src=\'", 3121, "\'", 3163, 1);
#nullable restore
#line 57 "D:\Shahen-WorkFront\Applications\CCC\CCC\Views\VetMaster\ManageVet.cshtml"
WriteAttributeValue("", 3127, Url.Content("~/images/refresh.png"), 3127, 36, false);

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
                            <th>Vet Name</th>
                            <th>Registration No</th>
                            <th>Mobile No</th>
                            <th>Email Address</th>
                            <th>Address</th>
                            <th>Description</th>
                            <th align=""left"" class=""editTD"">Edit</th>
                            <th align=""left"" class=""deleteTD"">Delete</th>
                        </tr>
                    </thead");
            WriteLiteral(@">
                    <tbody></tbody>
                </table>
            </div>
        </div>
        <div id=""divdataTables_info""></div>
        <div id=""divDataTable_length""></div>
    </div>
</div>



<script type=""text/javascript"">
    $(document).ready(function () {
        $(""#mydatatable"").tableHeadFixer({ ""head"": true, ""top"": 1 });
        var langUrl = $(""#LangUrl"").val();
        var mytable = $('#mydatatable').dataTable({
            ""ajax"": {
                 ""url"": """);
#nullable restore
#line 99 "D:\Shahen-WorkFront\Applications\CCC\CCC\Views\VetMaster\ManageVet.cshtml"
                    Write(Url.Content("~/VetMaster/FillTableVetMasterAsync"));

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
                    { ""data"": ""VetName"", ""sName"": ""VetName"" },
                    { ""data"": ""RegistrationNo"", ""sName"": ""RegistrationNo"" },
                    { ""data"": ""Mobile"", ""sName"": ""MobileNo"" },
                    { ""data"": ""Email"", ""sName"": ""Email"" },
                    { ""data"": ""Address"", ""sName"": ""Address"" },
                    { ""data"": ""Description"", ""sName"": ""Description"" },
                      {
                          ""data"": ""VetId"", ""sName"": """", ""class"": ""editTD"", ""orderable"": false, ""mRender"": function (data, type, full) {
                             if (data != null) {
                                 return ""<a class='AddEditBtnPop' onClick=EditEvent('"" + data + ""')><i class='fa fa-edit'></i></a>"";
                                //return ""<div class='tablehoverbuttons'> <i class='fa fa-ellipsis-h'></i> <div class='buttonshover'><div class='editbtn'><a class='' href='javascript:void(0);' onClick=EditEvent('"" + data + ""')><span><img title");
            WriteLiteral("=\'Edit\' src=\'");
#nullable restore
#line 139 "D:\Shahen-WorkFront\Applications\CCC\CCC\Views\VetMaster\ManageVet.cshtml"
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
                          ""data"": ""VetId"", ""sName"": """", ""class"": ""deleteTD"", ""orderable"": false, ""mRender"": function (data, type, full) {
                              if (data != null) {
                                  return ""<a class='del' onClick=DeleteEvent('"" + data + ""')><i class='fa fa-trash'></i></a>"";
                                //return ""<div class='tablehoverbuttons'> <i class='fa fa-ellipsis-h'></i> <div class='buttonshover'><div class='editbtn'><a class='' href='javascript:void(0);' onClick=DeleteEvent('"" + data + ""')><span><img title='Delete' src='");
#nullable restore
#line 149 "D:\Shahen-WorkFront\Applications\CCC\CCC\Views\VetMaster\ManageVet.cshtml"
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
            searchObj.VetName = $('#txtVetName').val();
            return searchObj;
        }

        function fnFilterActivities() {
            searchObj = fnGetDataForActivities();
            $(""#mydatatable"").dataTable().fnMultiFilter({
                ""VetNa");
            WriteLiteral(@"me"": searchObj.VetName,
            });
        }

        function clearfilter() {
            $('#txtVetName').val('');
            fnFilterActivities();
        }

        $('#btnClear').click(function () {
            clearfilter();
        });


        $('#btnSearch1').click(function () {
            fnFilterActivities();
        });


        $(""#txtVetName"").keyup(function (e) {
            if (e.which == 13) {
                fnFilterActivities();
            }
        });

    });

</script>

<script>

    function AddEvent() {
          var url = '");
#nullable restore
#line 205 "D:\Shahen-WorkFront\Applications\CCC\CCC\Views\VetMaster\ManageVet.cshtml"
                Write(Url.Action("AddEditVet", "VetMaster"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\';\r\n        document.location.href = url;\r\n        //AddEditDialog(url, \"Add New Center\");\r\n    }\r\n    function EditEvent(vetId) {\r\n        var url = \'");
#nullable restore
#line 210 "D:\Shahen-WorkFront\Applications\CCC\CCC\Views\VetMaster\ManageVet.cshtml"
              Write(Url.Action("AddEditVet", "VetMaster"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"?vetId=' + vetId + '';
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
    function DeleteEvent(vetId) {
                    $.confirm({
                title: 'Confirm',
                content: ""Are you sure want to delete this vet?"",
                buttons: {
                    confirm: function () {

                        $.ajax({
                            url: """);
#nullable restore
#line 235 "D:\Shahen-WorkFront\Applications\CCC\CCC\Views\VetMaster\ManageVet.cshtml"
                             Write(Url.Content("~/VetMaster/IsInUseCount"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@""",
                            type: ""POST"",
                            dataType: ""json"",
                            data: { vetId: vetId },
                            success: function (result) {
                                if (result.isSuccess == true && parseInt(result.Count) > 0) {
                                    showWarningMsg('Vet does not delete, This is associated with the other data.');
                                }
                                else if (result.isSuccess == true && parseInt(result.Count) == 0) {
                                         $.ajax({
                                             url: """);
#nullable restore
#line 245 "D:\Shahen-WorkFront\Applications\CCC\CCC\Views\VetMaster\ManageVet.cshtml"
                                              Write(Url.Content("~/VetMaster/DeleteVet"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@""",
                                             type: ""Delete"",
                                             dataType: ""json"",
                                             data: { vetId: vetId },
                                             success: function (result) {
                                                 if (result.isSuccess == true) {
                                                showSuccessMsg('Vet deleted successfully.',BackToManage);
                                                //location.reload();
                                                }
                                                else {
                                                showWarningMsg('something went wrong');
                                                }
                                            }
                                        });
                                    }
                                    else {
                                    showWarningMsg('something went w");
            WriteLiteral(@"rong');
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
#line 274 "D:\Shahen-WorkFront\Applications\CCC\CCC\Views\VetMaster\ManageVet.cshtml"
              Write(Url.Action("ManageVet", "VetMaster"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\';\r\n        document.location.href = url;\r\n    }\r\n</script>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<VetMasterRequest> Html { get; private set; }
    }
}
#pragma warning restore 1591
