﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BetterCms.Module.Pages.Views.Shared.EditorTemplates
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    
    #line 1 "..\..\Views\Shared\EditorTemplates\PageStatus.cshtml"
    using BetterCms.Module.Root.Content.Resources;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/EditorTemplates/PageStatus.cshtml")]
    public partial class PageStatus : System.Web.Mvc.WebViewPage<BetterCms.Core.DataContracts.Enums.PageStatus>
    {
        public PageStatus()
        {
        }
        public override void Execute()
        {

WriteLiteral("\r\n");



            
            #line 4 "..\..\Views\Shared\EditorTemplates\PageStatus.cshtml"
 if (Model == BetterCms.Core.DataContracts.Enums.PageStatus.Published)
{

            
            #line default
            #line hidden
WriteLiteral("    <div class=\"bcms-icn-published\">");


            
            #line 6 "..\..\Views\Shared\EditorTemplates\PageStatus.cshtml"
                               Write(RootGlobalization.Boolean_Yes);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n");


            
            #line 7 "..\..\Views\Shared\EditorTemplates\PageStatus.cshtml"
}
else
{

            
            #line default
            #line hidden
WriteLiteral("    <div class=\"bcms-icn-unpublished\">");


            
            #line 10 "..\..\Views\Shared\EditorTemplates\PageStatus.cshtml"
                                 Write(RootGlobalization.Boolean_No);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n");


            
            #line 11 "..\..\Views\Shared\EditorTemplates\PageStatus.cshtml"
}
            
            #line default
            #line hidden

        }
    }
}
#pragma warning restore 1591
