#pragma checksum "C:\Users\acer\Desktop\Back-end-Project\EduHome\EduHome\Views\Shared\Components\Subscribe\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c54dd12d297ab114184c3d002bd46437d56bd3b5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_Subscribe_Default), @"mvc.1.0.view", @"/Views/Shared/Components/Subscribe/Default.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c54dd12d297ab114184c3d002bd46437d56bd3b5", @"/Views/Shared/Components/Subscribe/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e7af49b5d3cda8b8f85d8f3f819ee9cc7290556d", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_Subscribe_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Subscribe>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n    <div class=\"col-md-8 col-md-offset-2\">\r\n        <div class=\"subscribe-content section-title text-center\">\r\n            <h2>");
#nullable restore
#line 5 "C:\Users\acer\Desktop\Back-end-Project\EduHome\EduHome\Views\Shared\Components\Subscribe\Default.cshtml"
           Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n            <p>");
#nullable restore
#line 6 "C:\Users\acer\Desktop\Back-end-Project\EduHome\EduHome\Views\Shared\Components\Subscribe\Default.cshtml"
          Write(Model.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        </div>\r\n        <div class=\"newsletter-form mc_embed_signup\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c54dd12d297ab114184c3d002bd46437d56bd3b54573", async() => {
                WriteLiteral("\r\n                <div id=\"mc_embed_signup_scroll\" class=\"mc-form\">\r\n                    <input type=\"email\"  name=\"Email\" class=\"email\"");
                BeginWriteAttribute("id", " id=\"", 481, "\"", 505, 2);
#nullable restore
#line 11 "C:\Users\acer\Desktop\Back-end-Project\EduHome\EduHome\Views\Shared\Components\Subscribe\Default.cshtml"
WriteAttributeValue("", 486, ViewBag.Page, 486, 13, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 499, "-EMAIL", 499, 6, true);
                EndWriteAttribute();
                WriteLiteral(" placeholder=\"Enter your e-mail address\" required>\r\n                    <!-- real people should not fill this in and expect good things - do not remove this or risk form bot signups-->\r\n");
                WriteLiteral("                    <button");
                BeginWriteAttribute("id", " id=\"", 879, "\"", 907, 2);
#nullable restore
#line 14 "C:\Users\acer\Desktop\Back-end-Project\EduHome\EduHome\Views\Shared\Components\Subscribe\Default.cshtml"
WriteAttributeValue("", 884, ViewBag.Page, 884, 13, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 897, "-subscribe", 897, 10, true);
                EndWriteAttribute();
                WriteLiteral(" type=\"button\" class=\"default-btn\" name=\"subscribe\"><span>subscribe</span></button>\r\n                </div>\r\n                <div><span");
                BeginWriteAttribute("id", " id=\"", 1043, "\"", 1066, 2);
#nullable restore
#line 16 "C:\Users\acer\Desktop\Back-end-Project\EduHome\EduHome\Views\Shared\Components\Subscribe\Default.cshtml"
WriteAttributeValue("", 1048, ViewBag.Page, 1048, 13, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 1061, "-span", 1061, 5, true);
                EndWriteAttribute();
                WriteLiteral("></span></div>\r\n            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "id", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 9 "C:\Users\acer\Desktop\Back-end-Project\EduHome\EduHome\Views\Shared\Components\Subscribe\Default.cshtml"
AddHtmlAttributeValue("", 314, ViewBag.Page, 314, 13, false);

#line default
#line hidden
#nullable disable
            AddHtmlAttributeValue("", 327, "-subscribe-form", 327, 15, true);
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
            <!-- mailchimp-alerts Start -->
            <div class=""mailchimp-alerts"">
                <div class=""mailchimp-submitting""></div><!-- mailchimp-submitting end -->
                <div class=""mailchimp-success""></div><!-- mailchimp-success end -->
                <div class=""mailchimp-error""></div><!-- mailchimp-error end -->
            </div>
            <!-- mailchimp-alerts end -->
        </div>
    </div>
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Subscribe> Html { get; private set; }
    }
}
#pragma warning restore 1591
