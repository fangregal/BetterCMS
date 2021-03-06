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

namespace BetterCms.Module.MediaManager.Views.History
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
    
    #line 1 "..\..\Views\History\MediaVersion.cshtml"
    using BetterCms.Module.MediaManager.ViewModels.History;
    
    #line default
    #line hidden
    
    #line 2 "..\..\Views\History\MediaVersion.cshtml"
    using BetterCms.Module.Root.Mvc.Helpers;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/History/MediaVersion.cshtml")]
    public partial class MediaVersion : System.Web.Mvc.WebViewPage<MediaPreviewViewModel>
    {

public System.Web.WebPages.HelperResult RenderProperty(MediaPreviewPropertyViewModel property) {
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {



#line 6 "..\..\Views\History\MediaVersion.cshtml"
                                                                
    var value = property.Value;
    if (!string.IsNullOrEmpty(value) && value.Length > 500)
    {
        value = value.Substring(0, 497) + "...";
    }
    

#line default
#line hidden

WriteLiteralTo(@__razor_helper_writer, "    <div class=\"bcms-file-info-text\">\r\n");



#line 14 "..\..\Views\History\MediaVersion.cshtml"
         if (property.IsImageUrl)
        {

#line default
#line hidden

WriteLiteralTo(@__razor_helper_writer, "            <div class=\"bcms-media-history-image-holder\">\r\n                <img s" +
"rc=\"");



#line 17 "..\..\Views\History\MediaVersion.cshtml"
WriteTo(@__razor_helper_writer, property.Value);

#line default
#line hidden

WriteLiteralTo(@__razor_helper_writer, "\" alt=\"");



#line 17 "..\..\Views\History\MediaVersion.cshtml"
                 WriteTo(@__razor_helper_writer, property.Title);

#line default
#line hidden

WriteLiteralTo(@__razor_helper_writer, "\" />\r\n            </div>\r\n");



#line 19 "..\..\Views\History\MediaVersion.cshtml"
        }
        else if (property.IsUrl)
        {

#line default
#line hidden

WriteLiteralTo(@__razor_helper_writer, "            <a href=\"");



#line 22 "..\..\Views\History\MediaVersion.cshtml"
WriteTo(@__razor_helper_writer, property.Value);

#line default
#line hidden

WriteLiteralTo(@__razor_helper_writer, "\" target=\"_blank\">");



#line 22 "..\..\Views\History\MediaVersion.cshtml"
                       WriteTo(@__razor_helper_writer, property.Title);

#line default
#line hidden

WriteLiteralTo(@__razor_helper_writer, "</a>\r\n");



#line 23 "..\..\Views\History\MediaVersion.cshtml"
        }
        else
        {

#line default
#line hidden

WriteLiteralTo(@__razor_helper_writer, "            <b>");



#line 26 "..\..\Views\History\MediaVersion.cshtml"
WriteTo(@__razor_helper_writer, property.Title);

#line default
#line hidden

WriteLiteralTo(@__razor_helper_writer, ": </b>");



#line 26 "..\..\Views\History\MediaVersion.cshtml"
                                    
#line default
#line hidden


#line 26 "..\..\Views\History\MediaVersion.cshtml"
     WriteTo(@__razor_helper_writer, value);

#line default
#line hidden


#line 26 "..\..\Views\History\MediaVersion.cshtml"
                                          
        }

#line default
#line hidden

WriteLiteralTo(@__razor_helper_writer, "    </div>\r\n");



#line 29 "..\..\Views\History\MediaVersion.cshtml"

#line default
#line hidden

});

}


        public MediaVersion()
        {
        }
        public override void Execute()
        {


WriteLiteral("\r\n");


WriteLiteral("           \r\n");



WriteLiteral("\r\n\r\n<div class=\"bcms-media-history-holder\">\r\n    ");


            
            #line 32 "..\..\Views\History\MediaVersion.cshtml"
Write(Html.TabbedContentMessagesBox());

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");


            
            #line 34 "..\..\Views\History\MediaVersion.cshtml"
     if (Model != null)
    {
        foreach (var property in Model.Properties)
        {
            
            
            #line default
            #line hidden
            
            #line 38 "..\..\Views\History\MediaVersion.cshtml"
       Write(RenderProperty(property));

            
            #line default
            #line hidden
            
            #line 38 "..\..\Views\History\MediaVersion.cshtml"
                                     
        }
    }

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n\r\n");


        }
    }
}
#pragma warning restore 1591
