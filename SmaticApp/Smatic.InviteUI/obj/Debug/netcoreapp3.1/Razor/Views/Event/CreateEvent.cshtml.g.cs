#pragma checksum "E:\smaticapp\SmaticApp\Smatic.InviteUI\Views\Event\CreateEvent.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b95577f4068a841f509a8b2b7b0125727e68ebb2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Event_CreateEvent), @"mvc.1.0.view", @"/Views/Event/CreateEvent.cshtml")]
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
#line 1 "E:\smaticapp\SmaticApp\Smatic.InviteUI\Views\_ViewImports.cshtml"
using Smatic.InviteUI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\smaticapp\SmaticApp\Smatic.InviteUI\Views\_ViewImports.cshtml"
using Smatic.InviteUI.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b95577f4068a841f509a8b2b7b0125727e68ebb2", @"/Views/Event/CreateEvent.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"67f21d6ed4d576448cc79c4d0a7eb257f2b52058", @"/Views/_ViewImports.cshtml")]
    public class Views_Event_CreateEvent : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EventModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"form-style-5\">\r\n");
#nullable restore
#line 3 "E:\smaticapp\SmaticApp\Smatic.InviteUI\Views\Event\CreateEvent.cshtml"
     using (Html.BeginForm())
    {
       

#line default
#line hidden
#nullable disable
            WriteLiteral("    <fieldset>\r\n        <legend><span class=\"number\">1</span>Toplantı Oluştur</legend>\r\n        ");
#nullable restore
#line 8 "E:\smaticapp\SmaticApp\Smatic.InviteUI\Views\Event\CreateEvent.cshtml"
   Write(Html.TextBoxFor(t => t.Name, new { placeholder = "Toplantı Konusu", type = "text" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n        ");
#nullable restore
#line 10 "E:\smaticapp\SmaticApp\Smatic.InviteUI\Views\Event\CreateEvent.cshtml"
   Write(Html.TextAreaFor(t => t.Partipicants, new { placeHolder = "Katılımcılar" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n        <label for=\"job\">Toplantı Odası</label>\r\n\r\n        ");
#nullable restore
#line 14 "E:\smaticapp\SmaticApp\Smatic.InviteUI\Views\Event\CreateEvent.cshtml"
   Write(Html.DropDownList("EventRoomId", Model.RoomList));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n      \r\n    </fieldset>\r\n            <input type=\"submit\" value=\"GÖNDER\" />\r\n");
#nullable restore
#line 18 "E:\smaticapp\SmaticApp\Smatic.InviteUI\Views\Event\CreateEvent.cshtml"
       
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EventModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
