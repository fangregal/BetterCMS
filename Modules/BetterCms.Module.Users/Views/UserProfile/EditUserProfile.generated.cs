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

namespace BetterCms.Module.Users.Views.UserProfile
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
    
    #line 1 "..\..\Views\UserProfile\EditUserProfile.cshtml"
    using BetterCms.Module.Root.Content.Resources;
    
    #line default
    #line hidden
    
    #line 2 "..\..\Views\UserProfile\EditUserProfile.cshtml"
    using BetterCms.Module.Root.Mvc.Helpers;
    
    #line default
    #line hidden
    
    #line 3 "..\..\Views\UserProfile\EditUserProfile.cshtml"
    using BetterCms.Module.Users.Content.Resources;
    
    #line default
    #line hidden
    
    #line 4 "..\..\Views\UserProfile\EditUserProfile.cshtml"
    using BetterCms.Module.Users.Controllers;
    
    #line default
    #line hidden
    
    #line 5 "..\..\Views\UserProfile\EditUserProfile.cshtml"
    using BetterCms.Module.Users.ViewModels.User;
    
    #line default
    #line hidden
    
    #line 6 "..\..\Views\UserProfile\EditUserProfile.cshtml"
    using Microsoft.Web.Mvc;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/UserProfile/EditUserProfile.cshtml")]
    public partial class EditUserProfile : System.Web.Mvc.WebViewPage<EditUserProfileViewModel>
    {
        public EditUserProfile()
        {
        }
        public override void Execute()
        {






WriteLiteral("\r\n");


WriteLiteral("\r\n<div class=\"bcms-scroll-window\" style=\"height: 527px;\">\r\n    ");


            
            #line 11 "..\..\Views\UserProfile\EditUserProfile.cshtml"
Write(Html.TabbedContentMessagesBox());

            
            #line default
            #line hidden
WriteLiteral("\r\n    <div class=\"bcms-new-blog-content\">\r\n");


            
            #line 13 "..\..\Views\UserProfile\EditUserProfile.cshtml"
         using (Html.BeginForm<UserProfileController>(c => c.SaveUserProfile(null), FormMethod.Post, new { @id = "bcms-user-profile-form", @class = "bcms-ajax-form" }))
        {
            
            
            #line default
            #line hidden
            
            #line 15 "..\..\Views\UserProfile\EditUserProfile.cshtml"
       Write(Html.HiddenFor(m => m.Version));

            
            #line default
            #line hidden
            
            #line 15 "..\..\Views\UserProfile\EditUserProfile.cshtml"
                                           
            
            
            #line default
            #line hidden
            
            #line 16 "..\..\Views\UserProfile\EditUserProfile.cshtml"
       Write(Html.HiddenFor(m => m.SecurityHash));

            
            #line default
            #line hidden
            
            #line 16 "..\..\Views\UserProfile\EditUserProfile.cshtml"
                                                
            
            
            #line default
            #line hidden
            
            #line 17 "..\..\Views\UserProfile\EditUserProfile.cshtml"
       Write(Html.HiddenFor(model => model.Image.ImageId, new { data_bind = "value: image().id()" }));

            
            #line default
            #line hidden
            
            #line 17 "..\..\Views\UserProfile\EditUserProfile.cshtml"
                                                                                                    
            

            
            #line default
            #line hidden
WriteLiteral("            <div class=\"bcms-blog-left\">\r\n                <div class=\"bcms-input-" +
"list-holder\">\r\n                    <div class=\"bcms-tooltip-mark\" data-message=\"" +
"");


            
            #line 21 "..\..\Views\UserProfile\EditUserProfile.cshtml"
                                                            Write(UsersGlobalization.EditUser_FirstName_Tooltip_Description);

            
            #line default
            #line hidden
WriteLiteral("\"></div>\r\n                    <div class=\"bcms-content-titles\">");


            
            #line 22 "..\..\Views\UserProfile\EditUserProfile.cshtml"
                                                Write(UsersGlobalization.EditUser_FirstName_Title);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n                    <div class=\"bcms-input-box\">\r\n                       " +
" ");


            
            #line 24 "..\..\Views\UserProfile\EditUserProfile.cshtml"
                   Write(Html.TextBoxFor(m => m.FirstName, new { @class = "bcms-editor-field-box", data_bind = "value: firstName, valueUpdate: 'afterkeydown'" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        ");


            
            #line 25 "..\..\Views\UserProfile\EditUserProfile.cshtml"
                   Write(Html.BcmsValidationMessageFor(m => m.FirstName));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </div>\r\n                </div>\r\n                <div class=" +
"\"bcms-input-list-holder\">\r\n                    <div class=\"bcms-tooltip-mark\" da" +
"ta-message=\"");


            
            #line 29 "..\..\Views\UserProfile\EditUserProfile.cshtml"
                                                            Write(UsersGlobalization.EditUser_LastName_Tooltip_Description);

            
            #line default
            #line hidden
WriteLiteral("\"></div>\r\n                    <div class=\"bcms-content-titles\">");


            
            #line 30 "..\..\Views\UserProfile\EditUserProfile.cshtml"
                                                Write(UsersGlobalization.EditUser_LastName);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n                    <div class=\"bcms-input-box\">\r\n                       " +
" ");


            
            #line 32 "..\..\Views\UserProfile\EditUserProfile.cshtml"
                   Write(Html.TextBoxFor(m => m.LastName, new { @class = "bcms-editor-field-box", data_bind = "value: lastName, valueUpdate: 'afterkeydown'" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        ");


            
            #line 33 "..\..\Views\UserProfile\EditUserProfile.cshtml"
                   Write(Html.BcmsValidationMessageFor(m => m.LastName));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </div>\r\n                </div>\r\n                <div class=" +
"\"bcms-input-list-holder\">\r\n                    <div class=\"bcms-tooltip-mark\" da" +
"ta-message=\"");


            
            #line 37 "..\..\Views\UserProfile\EditUserProfile.cshtml"
                                                            Write(UsersGlobalization.EditUser_UserName_Tooltip_Description);

            
            #line default
            #line hidden
WriteLiteral("\"></div>\r\n                    <div class=\"bcms-content-titles\">");


            
            #line 38 "..\..\Views\UserProfile\EditUserProfile.cshtml"
                                                Write(UsersGlobalization.EditUser_UserName_Title);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n                    <div class=\"bcms-input-box\">\r\n                       " +
" ");


            
            #line 40 "..\..\Views\UserProfile\EditUserProfile.cshtml"
                   Write(Html.TextBoxFor(m => m.UserName, new { @class = "bcms-editor-field-box", data_bind = "value: userName, valueUpdate: 'afterkeydown', event: {keyup: userNameOnKeyUp}" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        ");


            
            #line 41 "..\..\Views\UserProfile\EditUserProfile.cshtml"
                   Write(Html.BcmsValidationMessageFor(m => m.UserName));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </div>\r\n                </div>\r\n                <div class=" +
"\"bcms-input-list-holder\">\r\n                    <div class=\"bcms-tooltip-mark\" da" +
"ta-message=\"");


            
            #line 45 "..\..\Views\UserProfile\EditUserProfile.cshtml"
                                                            Write(UsersGlobalization.EditUser_Email_Tooltip_Description);

            
            #line default
            #line hidden
WriteLiteral("\"></div>\r\n                    <div class=\"bcms-content-titles\">");


            
            #line 46 "..\..\Views\UserProfile\EditUserProfile.cshtml"
                                                Write(UsersGlobalization.EditUser_Email_Title);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n                    <div class=\"bcms-input-box\">\r\n                       " +
" ");


            
            #line 48 "..\..\Views\UserProfile\EditUserProfile.cshtml"
                   Write(Html.TextBoxFor(m => m.Email, new { @class = "bcms-editor-field-box" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        ");


            
            #line 49 "..\..\Views\UserProfile\EditUserProfile.cshtml"
                   Write(Html.BcmsValidationMessageFor(m => m.Email));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </div>\r\n                </div>\r\n                <div class=" +
"\"bcms-input-list-holder\">\r\n                    <div class=\"bcms-tooltip-mark\" da" +
"ta-message=\"");


            
            #line 53 "..\..\Views\UserProfile\EditUserProfile.cshtml"
                                                            Write(UsersGlobalization.EditUser_Password_Tooltip_Description);

            
            #line default
            #line hidden
WriteLiteral("\"></div>\r\n                    <div class=\"bcms-content-titles\">");


            
            #line 54 "..\..\Views\UserProfile\EditUserProfile.cshtml"
                                                Write(UsersGlobalization.EditUser_Password_Title);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n                    <div class=\"bcms-input-box\">\r\n                       " +
" ");


            
            #line 56 "..\..\Views\UserProfile\EditUserProfile.cshtml"
                   Write(Html.TextBoxFor(m => m.Password, new { @class = "bcms-editor-field-box", @type = "password" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        ");


            
            #line 57 "..\..\Views\UserProfile\EditUserProfile.cshtml"
                   Write(Html.BcmsValidationMessageFor(m => m.Password));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </div>\r\n                </div>\r\n                <div class=" +
"\"bcms-input-list-holder\">\r\n                    <div class=\"bcms-tooltip-mark\" da" +
"ta-message=\"");


            
            #line 61 "..\..\Views\UserProfile\EditUserProfile.cshtml"
                                                            Write(UsersGlobalization.EditUser_RetypePassword_Tooltip_Description);

            
            #line default
            #line hidden
WriteLiteral("\"></div>\r\n                    <div class=\"bcms-content-titles\">");


            
            #line 62 "..\..\Views\UserProfile\EditUserProfile.cshtml"
                                                Write(UsersGlobalization.EditUser_RetypePassword_Title);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n                    <div class=\"bcms-input-box\">\r\n                       " +
" ");


            
            #line 64 "..\..\Views\UserProfile\EditUserProfile.cshtml"
                   Write(Html.TextBoxFor(m => m.RetypedPassword, new { @class = "bcms-editor-field-box", @type = "password" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        ");


            
            #line 65 "..\..\Views\UserProfile\EditUserProfile.cshtml"
                   Write(Html.BcmsValidationMessageFor(m => m.RetypedPassword));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </div>\r\n                </div>\r\n            </div>\r\n");


            
            #line 69 "..\..\Views\UserProfile\EditUserProfile.cshtml"
             

            
            #line default
            #line hidden
WriteLiteral("            <div class=\"bcms-blog-right\">\r\n                <div class=\"bcms-creat" +
"e-author-holder\">\r\n                    <div class=\"bcms-tooltip-mark\" data-messa" +
"ge=\"");


            
            #line 72 "..\..\Views\UserProfile\EditUserProfile.cshtml"
                                                            Write(UsersGlobalization.EditUser_UserImage_Tooltip_Description);

            
            #line default
            #line hidden
WriteLiteral("\"></div>\r\n                    <div class=\"bcms-content-titles\">");


            
            #line 73 "..\..\Views\UserProfile\EditUserProfile.cshtml"
                                                Write(UsersGlobalization.EditUser_Image_Title);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n                    <div class=\"bcms-uploaded-image\">\r\n                  " +
"      <!-- ko if: image().url() -->\r\n                        <a class=\"bcms-remo" +
"ve-image\" data-bind=\"click: image().remove.bind(image())\">");


            
            #line 76 "..\..\Views\UserProfile\EditUserProfile.cshtml"
                                                                                                Write(RootGlobalization.Button_Remove);

            
            #line default
            #line hidden
WriteLiteral(@"</a>
                        <a data-bind=""click: image().preview.bind(image())"">
                            <img data-bind=""attr: { src: image().thumbnailUrl(), alt: image().tooltip() }"" />
                        </a>
                        <!-- /ko -->
                    </div>
                    <div class=""bcms-upload-info"">
                        <div class=""bcms-upload-info-text"">");


            
            #line 83 "..\..\Views\UserProfile\EditUserProfile.cshtml"
                                                      Write(UsersGlobalization.EditUser_UploadImage_Info);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n                        <div class=\"bcms-btn-small\" data-bind=\"click: ima" +
"ge().select.bind(image())\">");


            
            #line 84 "..\..\Views\UserProfile\EditUserProfile.cshtml"
                                                                                               Write(UsersGlobalization.EditUser_UploadImage_Button_Title);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n");


            
            #line 88 "..\..\Views\UserProfile\EditUserProfile.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("    </div>\r\n</div>\r\n\r\n");


        }
    }
}
#pragma warning restore 1591
