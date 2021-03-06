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

namespace BetterCms.Module.MediaManager.Views.MediaManager
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
    
    #line 1 "..\..\Views\MediaManager\Index.cshtml"
    using BetterCms.Module.MediaManager.Content.Resources;
    
    #line default
    #line hidden
    
    #line 2 "..\..\Views\MediaManager\Index.cshtml"
    using BetterCms.Module.Root.Mvc.Helpers;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/MediaManager/Index.cshtml")]
    public partial class Index : System.Web.Mvc.WebViewPage<BetterCms.Module.MediaManager.ViewModels.MediaManager.MediaManagerIndexViewModel>
    {
        public Index()
        {
        }
        public override void Execute()
        {


WriteLiteral("\r\n");


WriteLiteral("\r\n<div class=\"bcms-innertab-header\">\r\n    <a class=\"bcms-tab bcms-tab-active\" dat" +
"a-name=\"#bcms-tab-1\" id=\"bcms-tab-images\">");


            
            #line 7 "..\..\Views\MediaManager\Index.cshtml"
                                                                                Write(MediaGlobalization.ImagesTab_Title);

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n    ");



WriteLiteral("\r\n    <a class=\"bcms-tab\" data-name=\"#bcms-tab-4\" id=\"bcms-tab-files\">");


            
            #line 10 "..\..\Views\MediaManager\Index.cshtml"
                                                               Write(MediaGlobalization.FilesTab_Title);

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n</div>\r\n\r\n");


            
            #line 13 "..\..\Views\MediaManager\Index.cshtml"
Write(Html.TabbedContentMessagesBox());

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<div id=\"bcms-tab-1\" class=\"bcms-tab-single\">\r\n    ");


            
            #line 16 "..\..\Views\MediaManager\Index.cshtml"
Write(Html.Partial("Partial/MediaManagerTab"));

            
            #line default
            #line hidden
WriteLiteral("\r\n</div>\r\n");



WriteLiteral("\r\n<div id=\"bcms-tab-4\" class=\"bcms-tab-single\">\r\n    ");



WriteLiteral("\r\n    <div>\r\n");


            
            #line 27 "..\..\Views\MediaManager\Index.cshtml"
         if (Model.CustomFilesMessages != null)
        {
            
            
            #line default
            #line hidden
            
            #line 29 "..\..\Views\MediaManager\Index.cshtml"
       Write(Html.TabbedContentCustomMessagesBox(Model.CustomFilesMessages));

            
            #line default
            #line hidden
            
            #line 29 "..\..\Views\MediaManager\Index.cshtml"
                                                                           
        }

            
            #line default
            #line hidden
WriteLiteral("        ");


            
            #line 31 "..\..\Views\MediaManager\Index.cshtml"
   Write(Html.Partial("Partial/MediaManagerTab"));

            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n</div>\r\n\r\n");


            
            #line 35 "..\..\Views\MediaManager\Index.cshtml"
Write(Html.Partial("Partial/MediaManagerTemplate"));

            
            #line default
            #line hidden

        }
    }
}
#pragma warning restore 1591
