#pragma checksum "C:\Users\acer\Desktop\Back-end-Project\EduHome\EduHome\Views\Shared\Components\Testimonials\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "94dcfa95bcfe4eb28d8c5224f789c7dfa0fb2fb3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_Testimonials_Default), @"mvc.1.0.view", @"/Views/Shared/Components/Testimonials/Default.cshtml")]
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
#line 1 "C:\Users\acer\Desktop\Back-end-Project\EduHome\EduHome\Views\_ViewImports.cshtml"
using EduHome;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\acer\Desktop\Back-end-Project\EduHome\EduHome\Views\_ViewImports.cshtml"
using EduHome.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\acer\Desktop\Back-end-Project\EduHome\EduHome\Views\_ViewImports.cshtml"
using EduHome.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"94dcfa95bcfe4eb28d8c5224f789c7dfa0fb2fb3", @"/Views/Shared/Components/Testimonials/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e7af49b5d3cda8b8f85d8f3f819ee9cc7290556d", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_Testimonials_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Testimonials>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("testimonial"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"col-md-8 col-md-offset-2 col-sm-12\">\r\n");
#nullable restore
#line 4 "C:\Users\acer\Desktop\Back-end-Project\EduHome\EduHome\Views\Shared\Components\Testimonials\Default.cshtml"
     foreach (Testimonials tstm in Model)
    {


#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"single-testimonial\">\r\n            <div class=\"testimonial-info\">\r\n                <div class=\"testimonial-img\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "94dcfa95bcfe4eb28d8c5224f789c7dfa0fb2fb34261", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 294, "~/img/testimonial/", 294, 18, true);
#nullable restore
#line 10 "C:\Users\acer\Desktop\Back-end-Project\EduHome\EduHome\Views\Shared\Components\Testimonials\Default.cshtml"
AddHtmlAttributeValue("", 312, tstm.ImageURL, 312, 14, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </div>\r\n                <div class=\"testimonial-content\">\r\n                    <p>");
#nullable restore
#line 13 "C:\Users\acer\Desktop\Back-end-Project\EduHome\EduHome\Views\Shared\Components\Testimonials\Default.cshtml"
                  Write(tstm.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    <h4>");
#nullable restore
#line 14 "C:\Users\acer\Desktop\Back-end-Project\EduHome\EduHome\Views\Shared\Components\Testimonials\Default.cshtml"
                   Write(tstm.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                    <h5>");
#nullable restore
#line 15 "C:\Users\acer\Desktop\Back-end-Project\EduHome\EduHome\Views\Shared\Components\Testimonials\Default.cshtml"
                   Write(tstm.Position);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                </div>\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 19 "C:\Users\acer\Desktop\Back-end-Project\EduHome\EduHome\Views\Shared\Components\Testimonials\Default.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n   ");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Testimonials>> Html { get; private set; }
    }
}
#pragma warning restore 1591
