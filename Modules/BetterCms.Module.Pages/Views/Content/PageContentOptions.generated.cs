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

namespace BetterCms.Module.Pages.Views.Content
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
    
    #line 1 "..\..\Views\Content\PageContentOptions.cshtml"
    using BetterCms.Module.Pages;
    
    #line default
    #line hidden
    
    #line 2 "..\..\Views\Content\PageContentOptions.cshtml"
    using BetterCms.Module.Pages.Controllers;
    
    #line default
    #line hidden
    
    #line 3 "..\..\Views\Content\PageContentOptions.cshtml"
    using BetterCms.Module.Pages.ViewModels.Content;
    
    #line default
    #line hidden
    
    #line 4 "..\..\Views\Content\PageContentOptions.cshtml"
    using BetterCms.Module.Root.Mvc.Helpers;
    
    #line default
    #line hidden
    
    #line 5 "..\..\Views\Content\PageContentOptions.cshtml"
    using Microsoft.Web.Mvc;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Content/PageContentOptions.cshtml")]
    public partial class PageContentOptions : System.Web.Mvc.WebViewPage<PageContentOptionsViewModel>
    {
        public PageContentOptions()
        {
        }
        public override void Execute()
        {





WriteLiteral("\r\n");


WriteLiteral("           \r\n<div class=\"bcms-scroll-window\">\r\n    \r\n    ");


            
            #line 11 "..\..\Views\Content\PageContentOptions.cshtml"
Write(Html.TabbedContentMessagesBox());

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n    <div class=\"bcms-input-list-holder\">\r\n");


            
            #line 14 "..\..\Views\Content\PageContentOptions.cshtml"
         using (Html.BeginForm<ContentController>(c => c.PageContentOptions((PageContentOptionsViewModel)null), FormMethod.Post, new
                                                                                                                                     {
                                                                                                                                         @id = "bcms-options-form", 
                                                                                                                                         @class = "bcms-ajax-form",
                                                                                                                                         data_readonly = Model.IsReadOnly.ToString().ToLower()
                                                                                                                                     }))
        {              
            
            
            #line default
            #line hidden
            
            #line 21 "..\..\Views\Content\PageContentOptions.cshtml"
       Write(Html.Partial(PagesConstants.OptionValuesGridTemplate));

            
            #line default
            #line hidden
            
            #line 21 "..\..\Views\Content\PageContentOptions.cshtml"
                                                                  
            
            
            
            #line default
            #line hidden
            
            #line 23 "..\..\Views\Content\PageContentOptions.cshtml"
       Write(Html.HiddenFor(model => model.PageContentId));

            
            #line default
            #line hidden
            
            #line 23 "..\..\Views\Content\PageContentOptions.cshtml"
                                                         
        }

            
            #line default
            #line hidden
WriteLiteral("    </div>\r\n</div>\r\n");


        }
    }
}
#pragma warning restore 1591
