#pragma checksum "D:\testProjectFootball\WcfServiceLibrary1\WebSite\Views\Players\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1b1baa0a07a68e31ebb7eeaea4f573632d7eaebe"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Players_Index), @"mvc.1.0.view", @"/Views/Players/Index.cshtml")]
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
#line 1 "D:\testProjectFootball\WcfServiceLibrary1\WebSite\Views\_ViewImports.cshtml"
using WebSite;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\testProjectFootball\WcfServiceLibrary1\WebSite\Views\_ViewImports.cshtml"
using WebSite.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1b1baa0a07a68e31ebb7eeaea4f573632d7eaebe", @"/Views/Players/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b9751a11891ba42cf18e84a4b82e03210f652818", @"/Views/_ViewImports.cshtml")]
    public class Views_Players_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<WebSite.Models.PlayerViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("nav-link text-dark"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Players", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\testProjectFootball\WcfServiceLibrary1\WebSite\Views\Players\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Players</h1>\r\n\r\n<p>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1b1baa0a07a68e31ebb7eeaea4f573632d7eaebe4964", async() => {
                WriteLiteral("Create New");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 13 "D:\testProjectFootball\WcfServiceLibrary1\WebSite\Views\Players\Index.cshtml"
     using (Html.BeginForm("Index", "Players", FormMethod.Get))
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <b> Search Option: </b> ");
            WriteLiteral(" Team ");
#nullable restore
#line 16 "D:\testProjectFootball\WcfServiceLibrary1\WebSite\Views\Players\Index.cshtml"
   Write(Html.TextBox("search"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" <input type=\"submit\"\r\n                                       name=\"submit\"\r\n                                       value=\"Search\" />\r\n");
#nullable restore
#line 19 "D:\testProjectFootball\WcfServiceLibrary1\WebSite\Views\Players\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 26 "D:\testProjectFootball\WcfServiceLibrary1\WebSite\Views\Players\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 29 "D:\testProjectFootball\WcfServiceLibrary1\WebSite\Views\Players\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 32 "D:\testProjectFootball\WcfServiceLibrary1\WebSite\Views\Players\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.DateBirth));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 35 "D:\testProjectFootball\WcfServiceLibrary1\WebSite\Views\Players\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.MarketValue));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 38 "D:\testProjectFootball\WcfServiceLibrary1\WebSite\Views\Players\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Position));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 41 "D:\testProjectFootball\WcfServiceLibrary1\WebSite\Views\Players\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Height));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 44 "D:\testProjectFootball\WcfServiceLibrary1\WebSite\Views\Players\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Team));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 50 "D:\testProjectFootball\WcfServiceLibrary1\WebSite\Views\Players\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 54 "D:\testProjectFootball\WcfServiceLibrary1\WebSite\Views\Players\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 57 "D:\testProjectFootball\WcfServiceLibrary1\WebSite\Views\Players\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 60 "D:\testProjectFootball\WcfServiceLibrary1\WebSite\Views\Players\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.DateBirth));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 63 "D:\testProjectFootball\WcfServiceLibrary1\WebSite\Views\Players\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.MarketValue));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 66 "D:\testProjectFootball\WcfServiceLibrary1\WebSite\Views\Players\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Position));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 69 "D:\testProjectFootball\WcfServiceLibrary1\WebSite\Views\Players\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Height));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 72 "D:\testProjectFootball\WcfServiceLibrary1\WebSite\Views\Players\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Team.TeamName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 75 "D:\testProjectFootball\WcfServiceLibrary1\WebSite\Views\Players\Index.cshtml"
               Write(Html.ActionLink("Edit", "Edit", new { Id = item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                    ");
#nullable restore
#line 76 "D:\testProjectFootball\WcfServiceLibrary1\WebSite\Views\Players\Index.cshtml"
               Write(Html.ActionLink("Details", "Details", new { Id = item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                    ");
#nullable restore
#line 77 "D:\testProjectFootball\WcfServiceLibrary1\WebSite\Views\Players\Index.cshtml"
               Write(Html.ActionLink("Delete", "Delete", new { Id = item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 80 "D:\testProjectFootball\WcfServiceLibrary1\WebSite\Views\Players\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n\r\n</table>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1b1baa0a07a68e31ebb7eeaea4f573632d7eaebe13136", async() => {
                WriteLiteral("Back");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<WebSite.Models.PlayerViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
