#pragma checksum "D:\Shahen-WorkFront\Projects\CodeZen\CCC\CCC\Views\VetMaster\_AddVetQuick.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "355a85aa901c2aa0425af2146de85bf01d663c18"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_VetMaster__AddVetQuick), @"mvc.1.0.view", @"/Views/VetMaster/_AddVetQuick.cshtml")]
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
#line 1 "D:\Shahen-WorkFront\Projects\CodeZen\CCC\CCC\Views\VetMaster\_AddVetQuick.cshtml"
using CCC.UI.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"355a85aa901c2aa0425af2146de85bf01d663c18", @"/Views/VetMaster/_AddVetQuick.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6bc7222c5ea61ced56de2aeb71f1897d8d758eaa", @"/Views/_ViewImports.cshtml")]
    public class Views_VetMaster__AddVetQuick : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<VetMasterRequest>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "text", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("AddEditVet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddEditVet", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "VetMaster", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "355a85aa901c2aa0425af2146de85bf01d663c185817", async() => {
                WriteLiteral(@"
    <div class=""mainContent"">
        <div class=""conInner"">
            <div class="" row"">
                <div class=""col-lg-12 col-md-12 col-sm-12 col-xs-12"">
                    <div class=""row"">
                        <div class=""col-lg-3 col-md-3 col-sm-3 col-xs-12"">
                            <div class=""form-group"">
                                <label class=""pt20"">Vet Name<span class=""redColor"">*</span></label>
                                <div class=""form-group2"">
                                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "355a85aa901c2aa0425af2146de85bf01d663c186625", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 14 "D:\Shahen-WorkFront\Projects\CodeZen\CCC\CCC\Views\VetMaster\_AddVetQuick.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.VetName);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                                    <span id=""spVetName"" class=""redColor""></span>
                                </div>
                            </div>
                        </div>
                        <div class=""col-lg-3 col-md-3 col-sm-3 col-xs-12"">
                            <div class=""form-group"">
                                <label class=""pt20"">Registration No<span class=""redColor"">*</span></label>
                                <div class=""form-group2"">
                                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "355a85aa901c2aa0425af2146de85bf01d663c188952", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 23 "D:\Shahen-WorkFront\Projects\CodeZen\CCC\CCC\Views\VetMaster\_AddVetQuick.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.RegistrationNo);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                                    <span id=""spRegistrationNo"" class=""redColor""></span>
                                </div>
                            </div>
                        </div>
                        <div class=""col-lg-3 col-md-3 col-sm-3 col-xs-12"">
                            <div class=""form-group"">
                                <label class=""pt20"">Email Address<span class=""redColor"">*</span></label>
                                <div class=""form-group2"">
                                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "355a85aa901c2aa0425af2146de85bf01d663c1811291", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 32 "D:\Shahen-WorkFront\Projects\CodeZen\CCC\CCC\Views\VetMaster\_AddVetQuick.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Email);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                                    <span id=""spEmail"" class=""redColor""></span>
                                </div>
                            </div>
                        </div>
                        <div class=""col-lg-3 col-md-3 col-sm-3 col-xs-12"">
                            <div class=""form-group"">
                                <label class=""pt20"">Mobile No<span class=""redColor"">*</span></label>
                                <div class=""form-group2"">
                                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "355a85aa901c2aa0425af2146de85bf01d663c1813609", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 41 "D:\Shahen-WorkFront\Projects\CodeZen\CCC\CCC\Views\VetMaster\_AddVetQuick.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Mobile);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                                    <span id=""spMobile"" class=""redColor""></span>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class=""row"">
                        <div class=""col-lg-12 col-md-12 col-sm-12 col-xs-12"">
                            <div class=""pull-right"">
                                <div class=""form-group"">
                                    <button type=""button"" class=""btn btn-primary btnSearch"" id=""btnAddVet"">Add</button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

<script>
    $(""#btnAddVet"").on('click', function (e) {

        e.preventDefault();

        $('#AddEditVet').find('input:text').each(function () {
            $(this).val($.trim($(this).val()));
        });

        if ($('#AddEditVet').valid()) {
            var formAction = $('#AddEditVet').attr(""action"");
            var fdata = new FormData();
            var params = $('#AddEditVet').serializeArray();
            $.each(params, function (i, val) {
                fdata.append(val.name, val.value);
            });

            var IsSuccess = true;
            var vetName = $(""#VetName"").val();
            var RegistrationNo = $(""#RegistrationNo"").val();
            var Email = $(""#Email"").val();
            var Mobile = $(""#Mobile"").val();
            var pattern = /^[_a-z0-9-]+(\.[_a-z0-9-]+)*");
            WriteLiteral(@"@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$/;

            if (vetName == '' || vetName == undefined) {
                $('#spVetName').text('Please enter vet name');
                IsSuccess = false;
            } else {
                $('#spVetName').text('');
                IsSuccess = true;
            }
            if (RegistrationNo == '' || RegistrationNo == undefined) {
                $('#spRegistrationNo').text('Please enter Registration number');
                IsSuccess = false;
            } else {
                $('#spRegistrationNo').text('');
                IsSuccess = true;
            }
            if (Email == '' || Email == undefined) {
                $('#spEmail').text('Please enter Email');
                IsSuccess = false;
            } else if (!pattern.test(Email)) {
                $('#spEmail').text('Please enter valid email address');
                IsSuccess = false;
            } else {
                $('#spEmail').text('');
                IsSucce");
            WriteLiteral(@"ss = true;
            }
            if (Mobile == '' || Mobile == undefined) {
                $('#spMobile').text('Please enter mobile number');
                IsSuccess = false;
            } else {
                $('#Mobile').text('');
                IsSuccess = true;
            }

            if (IsSuccess) {
                var chkData = { vetName: vetName}
            var urlNameChk = '");
#nullable restore
#line 120 "D:\Shahen-WorkFront\Projects\CodeZen\CCC\CCC\Views\VetMaster\_AddVetQuick.cshtml"
                         Write(Url.Action("IsVetNameInUse", "VetMaster"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"';
            var IsSuccess = true;
            $.ajax({
                type: 'POST',
                url: urlNameChk,
                data: chkData,
                cache: false,
                dataType: ""Json"",
            }).done(function (result) {
                if (result == true) {
                    $(""#spVetName"").text('Vet name is already exists');
                    IsSuccess=false;
                } else {
                    $(""#spVetName"").text('');
                    IsSuccess = true;
                    $.ajax({
                        type: 'post',
                        url: formAction,
                        data: fdata,
                        processData: false,
                        contentType: false
                    }).done(function (result) {
                        if (result.isSuccess == true) {
                            showSuccessMsg('New Vet Added Successfully', reload('VetId', result.VetId, result.VetName));

                        } els");
            WriteLiteral("e {\r\n                            showWarningMsg(\'something went wrong \');\r\n                        }\r\n                    });\r\n                }\r\n            });\r\n\r\n               \r\n\r\n            }\r\n        }\r\n    });\r\n\r\n</script>");
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
