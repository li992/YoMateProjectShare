#pragma checksum "E:\VS2019Source\YoMateProjectShare\Views\Messages\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d38fe805012a7bc13edd2f39f43f8bea0398a566"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Messages_Index), @"mvc.1.0.view", @"/Views/Messages/Index.cshtml")]
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
#line 1 "E:\VS2019Source\YoMateProjectShare\Views\_ViewImports.cshtml"
using YoMateProjectShare;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\VS2019Source\YoMateProjectShare\Views\_ViewImports.cshtml"
using YoMateProjectShare.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "E:\VS2019Source\YoMateProjectShare\Views\Messages\Index.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "E:\VS2019Source\YoMateProjectShare\Views\Messages\Index.cshtml"
using YoMateProjectShare.Areas.Identity.Data;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d38fe805012a7bc13edd2f39f43f8bea0398a566", @"/Views/Messages/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d825f0feda4def85e63f8668c1a82456885ec3fb", @"/Views/_ViewImports.cshtml")]
    public class Views_Messages_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<string>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "E:\VS2019Source\YoMateProjectShare\Views\Messages\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<style>
    body {
        margin: 0px;
        padding: 0px;
    }

    .msg {
        position: absolute;
        top: 0;
        bottom: 30px;
        border: 1px solid green;
        margin-bottom: auto;
        display: block;
        overflow: scroll;
        width: 100%;
        white-space: nowrap;
    }
</style>


<div style=""position:relative;height:400px;width:100%"";>
    <div class=""msg"">
        <div id=""msgs"" style=""position:relative; bottom:0;""></div>
    </div>

    <div style=""position:absolute;height:20px;width:100%;left:0;bottom:0;display:block"">
        <input type=""text"" style=""max-width:unset;width:100%;max-width:100%"" id=""MessageField"" placeholder=""type message and press enter"" />
    </div>
</div>


");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script>\r\n    $(function () {\r\n        var userName = \"");
#nullable restore
#line 43 "E:\VS2019Source\YoMateProjectShare\Views\Messages\Index.cshtml"
                   Write(UserManager.GetUserName(User));

#line default
#line hidden
#nullable disable
                WriteLiteral(@""";

        var protocol = location.protocol === ""https:"" ? ""wss:"" : ""ws:"";
            var wsUri = protocol + ""//"" + window.location.host;
            var socket = new WebSocket(wsUri);
            socket.onopen = e => {
                console.log(""socket opened"", e);
            };

            socket.onclose = function (e) {
                console.log(""socket closed"", e);
            };

            socket.onmessage = function (e) {
                console.log(e);
            $('#msgs').append(e.data + '<br />');
            };

            socket.onerror = function (e) {
                console.error(e.data);
            };

        $('#MessageField').keypress(function (e) {
                if (e.which != 13) {
                    return;
                }

                e.preventDefault();

                var message = userName + "": "" + $('#MessageField').val();
                socket.send(message);
            $('#MessageField').val('');
            });
        });");
                WriteLiteral("\n    </script>\r\n");
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<UserInfo> UserManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public SignInManager<UserInfo> SignInManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<string> Html { get; private set; }
    }
}
#pragma warning restore 1591
