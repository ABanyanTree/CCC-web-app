#pragma checksum "D:\Shahen-WorkFront\Projects\CodeZen\CCC\CCC\Views\UserMaster\ManageUsers.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0db5b314efdeb801b6bc7b081eeafe687ce93a8f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_UserMaster_ManageUsers), @"mvc.1.0.view", @"/Views/UserMaster/ManageUsers.cshtml")]
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
#line 1 "D:\Shahen-WorkFront\Projects\CodeZen\CCC\CCC\Views\UserMaster\ManageUsers.cshtml"
using CCC.UI.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0db5b314efdeb801b6bc7b081eeafe687ce93a8f", @"/Views/UserMaster/ManageUsers.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6bc7222c5ea61ced56de2aeb71f1897d8d758eaa", @"/Views/_ViewImports.cshtml")]
    public class Views_UserMaster_ManageUsers : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<UserMasterRequest>
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
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("txtUserName"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_12 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("placeholder", new global::Microsoft.AspNetCore.Html.HtmlString("User Name"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "D:\Shahen-WorkFront\Projects\CodeZen\CCC\CCC\Views\UserMaster\ManageUsers.cshtml"
  
    ViewData["Title"] = "Manage User";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "0db5b314efdeb801b6bc7b081eeafe687ce93a8f8405", async() => {
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
            WriteLiteral("\r\n<script src=\"https://code.jquery.com/ui/1.12.0/jquery-ui.min.js\"></script>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "0db5b314efdeb801b6bc7b081eeafe687ce93a8f9599", async() => {
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0db5b314efdeb801b6bc7b081eeafe687ce93a8f10713", async() => {
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0db5b314efdeb801b6bc7b081eeafe687ce93a8f11753", async() => {
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "0db5b314efdeb801b6bc7b081eeafe687ce93a8f12793", async() => {
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "0db5b314efdeb801b6bc7b081eeafe687ce93a8f13908", async() => {
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "0db5b314efdeb801b6bc7b081eeafe687ce93a8f15023", async() => {
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0db5b314efdeb801b6bc7b081eeafe687ce93a8f16138", async() => {
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
                        <li class=""breadcrumb-item active"" aria-current=""page"">Manage Users</li>
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
                                        <label class=""pt20"">User Name</label>
                                    </div>
                                </li>
                                <li class=""firstLastName"">
                                    <div class=""form-group"">
   ");
            WriteLiteral("                                     ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "0db5b314efdeb801b6bc7b081eeafe687ce93a8f18903", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 51 "D:\Shahen-WorkFront\Projects\CodeZen\CCC\CCC\Views\UserMaster\ManageUsers.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.UserName);

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
            BeginWriteAttribute("src", " src=\'", 2941, "\'", 2982, 1);
#nullable restore
#line 56 "D:\Shahen-WorkFront\Projects\CodeZen\CCC\CCC\Views\UserMaster\ManageUsers.cshtml"
WriteAttributeValue("", 2947, Url.Content("~/images/search.png"), 2947, 35, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" /> </button>\r\n                                        <button type=\"button\" class=\"btn btn-default btn-clear\" id=\"btnClear\"><img");
            BeginWriteAttribute("src", " src=\'", 3112, "\'", 3154, 1);
#nullable restore
#line 57 "D:\Shahen-WorkFront\Projects\CodeZen\CCC\CCC\Views\UserMaster\ManageUsers.cshtml"
WriteAttributeValue("", 3118, Url.Content("~/images/refresh.png"), 3118, 36, false);

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
                            <th>Edit</th>
                            <th>Delete</th>
                            <th>User Name</th>
                            <th>Email Address</th>
                            <th>Mobile No</th>
                            <th>User Role</th>
                            <th>Centers</th>                          
                        </tr>
                    </thead>
                    <tbody></tbody>
                </table>
            </div>
        </div>
        <div");
            WriteLiteral(@" id=""divdataTables_info""></div>
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
#line 98 "D:\Shahen-WorkFront\Projects\CodeZen\CCC\CCC\Views\UserMaster\ManageUsers.cshtml"
                    Write(Url.Content("~/UserMaster/FillTableUserMasterAsync"));

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
             ""aaSorting"": [[1, ""asc""]],
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
            """);
            WriteLiteral(@"aoColumns"":
                [
                      {
                        ""data"": ""UserId"", ""sName"": """", ""class"": """", ""orderable"": false, ""mRender"": function (data, type, full) {
                            if (data != null) {
                                return ""<div class='tablehoverbuttons'> <i class='fa fa-ellipsis-h'></i> <div class='buttonshover'><div class='editbtn'><a class='' href='javascript:void(0);' onClick=EditEvent('"" + data + ""')><span><img title='Edit' src='");
#nullable restore
#line 131 "D:\Shahen-WorkFront\Projects\CodeZen\CCC\CCC\Views\UserMaster\ManageUsers.cshtml"
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
                          ""data"": ""UserId"", ""sName"": """", ""class"": """", ""orderable"": false, ""mRender"": function (data, type, full) {
                            if (data != null) {
                                return ""<div class='tablehoverbuttons'> <i class='fa fa-ellipsis-h'></i> <div class='buttonshover'><div class='editbtn'><a class='' href='javascript:void(0);' onClick=DeleteEvent('"" + data + ""')><span><img title='Delete' src='");
#nullable restore
#line 140 "D:\Shahen-WorkFront\Projects\CodeZen\CCC\CCC\Views\UserMaster\ManageUsers.cshtml"
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
                    { ""data"": ""UserName"", ""sName"": ""UserName"" },
                    { ""data"": ""Email"", ""sName"": ""Email"" },
                    { ""data"": ""Mobile"", ""sName"": ""Mobile"" },                  
                    { ""data"": ""UserType"", ""sName"": ""UserType"" },
                    { ""data"": ""CenterNames"", ""sName"": ""CenterNames"" },
                    ]
        });
        mytable.on('order.dt', function () { $('.dataTables_paginate,.dataTables_info').show(); });
        mytable.on('length.dt', function (e, settings, len) { $('.dataTables_paginate,.dataTables_info').show(); });

        $(""#divDataTable_length"").append($("".dataTables_info""));
        $(""#divdataTables_info"").append($("".dataTables_length""));
        $(""#divdataTables_info"").append($("".dataTables_paginate""));

        function f");
            WriteLiteral(@"nGetDataForActivities() {
            var searchObj = new Object();
            searchObj.UserName = $('#txtUserName').val();
            return searchObj;
        }

        function fnFilterActivities() {
            searchObj = fnGetDataForActivities();
            $(""#mydatatable"").dataTable().fnMultiFilter({
                ""UserName"": searchObj.UserName,
            });
        }

        function clearfilter() {
            $('#txtUserName').val('');
            fnFilterActivities();
        }

        $('#btnClear').click(function () {
            clearfilter();
        });


        $('#btnSearch1').click(function () {
            fnFilterActivities();
        });


        $(""#txtUserName"").keyup(function (e) {
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
#line 201 "D:\Shahen-WorkFront\Projects\CodeZen\CCC\CCC\Views\UserMaster\ManageUsers.cshtml"
                Write(Url.Action("AddEditUser", "UserMaster"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\';\r\n        document.location.href = url;\r\n        //AddEditDialog(url, \"Add New Center\");\r\n    }\r\n    function EditEvent(userId) {\r\n        var url = \'");
#nullable restore
#line 206 "D:\Shahen-WorkFront\Projects\CodeZen\CCC\CCC\Views\UserMaster\ManageUsers.cshtml"
              Write(Url.Action("AddEditUser", "UserMaster"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"?userId=' + userId + '';
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
                content: ""Are you sure want to delete this User?"",
                buttons: {
                    confirm: function () {

                        $.ajax({
                            url: """);
#nullable restore
#line 231 "D:\Shahen-WorkFront\Projects\CodeZen\CCC\CCC\Views\UserMaster\ManageUsers.cshtml"
                             Write(Url.Content("~/UserMaster/IsInUseCount"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@""",
                            type: ""POST"",
                            dataType: ""json"",
                            data: { vetId: vetId },
                            success: function (result) {
                                if (result.isSuccess == true && parseInt(result.Count) > 0) {
                                    showWarningMsg('User does not delete, This User associated with the other data.');
                                }
                                else if (result.isSuccess == true && parseInt(result.Count) == 0) {
                                         $.ajax({
                                             url: """);
#nullable restore
#line 241 "D:\Shahen-WorkFront\Projects\CodeZen\CCC\CCC\Views\UserMaster\ManageUsers.cshtml"
                                              Write(Url.Content("~/UserMaster/DeleteUser"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@""",
                                             type: ""Delete"",
                                             dataType: ""json"",
                                             data: { vetId: vetId },
                                             success: function (result) {
                                                 if (result.isSuccess == true) {
                                                     showSuccessMsg('User deleted successfully.',BackToManage);
                                                //location.reload();
                                                }
                                                else {
                                                showWarningMsg('something went wrong');
                                                }
                                            }
                                        });
                                    }
                                    else {
                                    showWarningMsg('something ");
            WriteLiteral(@"went wrong');
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
#line 270 "D:\Shahen-WorkFront\Projects\CodeZen\CCC\CCC\Views\UserMaster\ManageUsers.cshtml"
              Write(Url.Action("ManageUser", "UserMaster"));

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<UserMasterRequest> Html { get; private set; }
    }
}
#pragma warning restore 1591
