#pragma checksum "E:\.NET\Projects\Online Shop\Online Shop\Areas\Customer\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "75dc6a20f3dcc4c2177bf26e790e4b5c2d233c3a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Customer_Views_Home_Index), @"mvc.1.0.view", @"/Areas/Customer/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Customer/Views/Home/Index.cshtml", typeof(AspNetCore.Areas_Customer_Views_Home_Index))]
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
#line 1 "E:\.NET\Projects\Online Shop\Online Shop\Areas\Customer\Views\_ViewImports.cshtml"
using Online_Shop;

#line default
#line hidden
#line 2 "E:\.NET\Projects\Online Shop\Online Shop\Areas\Customer\Views\_ViewImports.cshtml"
using Online_Shop.Models;

#line default
#line hidden
#line 1 "E:\.NET\Projects\Online Shop\Online Shop\Areas\Customer\Views\Home\Index.cshtml"
using X.PagedList.Mvc.Core;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"75dc6a20f3dcc4c2177bf26e790e4b5c2d233c3a", @"/Areas/Customer/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"06c341d60b42f081b259587877284be7fea141da", @"/Areas/Customer/Views/_ViewImports.cshtml")]
    public class Areas_Customer_Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<X.PagedList.IPagedList<Products>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Card Image"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("card-img-top imageThumNail"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn  pull-right btn-outline-info"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(113, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 6 "E:\.NET\Projects\Online Shop\Online Shop\Areas\Customer\Views\Home\Index.cshtml"
   
        ViewData["Title"] = "Home Page";
    

#line default
#line hidden
            BeginContext(169, 41, true);
            WriteLiteral("    <br /><br />\r\n    <div class=\"row\">\r\n");
            EndContext();
#line 11 "E:\.NET\Projects\Online Shop\Online Shop\Areas\Customer\Views\Home\Index.cshtml"
         foreach (var product in Model)
        {

#line default
#line hidden
            BeginContext(262, 263, true);
            WriteLiteral(@"            <div class=""col-4"">
                <div class=""card mb-4"">
                    <div class=""card-header"">
                        <h4 class=""my-0 font-weight-normal"">
                            <label style=""font-size : 20px ; color : steelblue"">");
            EndContext();
            BeginContext(526, 12, false);
#line 17 "E:\.NET\Projects\Online Shop\Online Shop\Areas\Customer\Views\Home\Index.cshtml"
                                                                           Write(product.Name);

#line default
#line hidden
            EndContext();
            BeginContext(538, 89, true);
            WriteLiteral("</label>\r\n                        </h4>\r\n                    </div>\r\n                    ");
            EndContext();
            BeginContext(627, 83, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "75dc6a20f3dcc4c2177bf26e790e4b5c2d233c3a6436", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 3, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 637, "~/", 637, 2, true);
#line 20 "E:\.NET\Projects\Online Shop\Online Shop\Areas\Customer\Views\Home\Index.cshtml"
AddHtmlAttributeValue("", 639, product.Image, 639, 14, false);

#line default
#line hidden
            AddHtmlAttributeValue(" ", 653, "", 654, 1, true);
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(710, 224, true);
            WriteLiteral("\r\n\r\n                    <div class=\"card-header\">\r\n                        <div class=\"d-flex justify-content-between align-items-center \">\r\n                            <label style=\" font-size : 20px ; color : #a51313\"> <b>");
            EndContext();
            BeginContext(935, 13, false);
#line 24 "E:\.NET\Projects\Online Shop\Online Shop\Areas\Customer\Views\Home\Index.cshtml"
                                                                              Write(product.Price);

#line default
#line hidden
            EndContext();
            BeginContext(948, 42, true);
            WriteLiteral("</b></label>\r\n                            ");
            EndContext();
            BeginContext(990, 108, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "75dc6a20f3dcc4c2177bf26e790e4b5c2d233c3a8912", async() => {
                BeginContext(1082, 12, true);
                WriteLiteral("Details View");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 25 "E:\.NET\Projects\Online Shop\Online Shop\Areas\Customer\Views\Home\Index.cshtml"
                                                      WriteLiteral(product.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1098, 108, true);
            WriteLiteral("\r\n\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n");
            EndContext();
#line 31 "E:\.NET\Projects\Online Shop\Online Shop\Areas\Customer\Views\Home\Index.cshtml"
        }

#line default
#line hidden
            BeginContext(1217, 27, true);
            WriteLiteral("\r\n\r\n    </div>\r\n<div>\r\n    ");
            EndContext();
            BeginContext(1245, 67, false);
#line 36 "E:\.NET\Projects\Online Shop\Online Shop\Areas\Customer\Views\Home\Index.cshtml"
Write(Html.PagedListPager(Model,c=>Href("~/Customer/Home/Index?page="+c)));

#line default
#line hidden
            EndContext();
            BeginContext(1312, 8, true);
            WriteLiteral("\r\n</div>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<X.PagedList.IPagedList<Products>> Html { get; private set; }
    }
}
#pragma warning restore 1591
