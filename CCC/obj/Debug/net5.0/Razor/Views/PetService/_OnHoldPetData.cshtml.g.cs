#pragma checksum "D:\Shahen-WorkFront\Projects\CodeZen\CCC\CCC\Views\PetService\_OnHoldPetData.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d22a271d3363b0e26aee30f4dad20074652aba21"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_PetService__OnHoldPetData), @"mvc.1.0.view", @"/Views/PetService/_OnHoldPetData.cshtml")]
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
#line 1 "D:\Shahen-WorkFront\Projects\CodeZen\CCC\CCC\Views\PetService\_OnHoldPetData.cshtml"
using CCC.UI.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d22a271d3363b0e26aee30f4dad20074652aba21", @"/Views/PetService/_OnHoldPetData.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6bc7222c5ea61ced56de2aeb71f1897d8d758eaa", @"/Views/_ViewImports.cshtml")]
    public class Views_PetService__OnHoldPetData : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<PetDataNotificationResponse>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<div id=""dvContactList"">
    <div class=""col-lg-12 col-md-12 col-sm-12 col-xs-12"">
        <div class=""table-responsive mimTable"">
            <table class=""table rmvtbl Tbl_ClientContacts"">
                <thead>
                    <tr>
                        <th>Pet</th>
                        <th>Gender</th>
                        <th>Center Name</th>
                        <th>Surgery Date</th>
                    </tr>
                </thead>
                <tbody>
");
#nullable restore
#line 17 "D:\Shahen-WorkFront\Projects\CodeZen\CCC\CCC\Views\PetService\_OnHoldPetData.cshtml"
                     if (Model.Count > 0)
                    {
                        foreach (PetDataNotificationResponse item in Model)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td>");
#nullable restore
#line 22 "D:\Shahen-WorkFront\Projects\CodeZen\CCC\CCC\Views\PetService\_OnHoldPetData.cshtml"
                               Write(item.PetType);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 23 "D:\Shahen-WorkFront\Projects\CodeZen\CCC\CCC\Views\PetService\_OnHoldPetData.cshtml"
                               Write(item.Gender);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 24 "D:\Shahen-WorkFront\Projects\CodeZen\CCC\CCC\Views\PetService\_OnHoldPetData.cshtml"
                               Write(item.CenterName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 25 "D:\Shahen-WorkFront\Projects\CodeZen\CCC\CCC\Views\PetService\_OnHoldPetData.cshtml"
                               Write(item.SurgeryDateDisplay);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            </tr>\r\n");
#nullable restore
#line 27 "D:\Shahen-WorkFront\Projects\CodeZen\CCC\CCC\Views\PetService\_OnHoldPetData.cshtml"
                        }
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                </tbody>
            </table>
            <div class=""bottomSpace"">&nbsp;</div>
        </div>
    </div>
</div>

<script>
    $(document).ready(function () {
        $(""#spPetDataCart"").text('');
        $(""#spPetDataCart"").removeClass('badge badge-counter');
    });
</script>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<PetDataNotificationResponse>> Html { get; private set; }
    }
}
#pragma warning restore 1591
