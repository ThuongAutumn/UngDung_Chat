#pragma checksum "E:\Nam3\Ky1\LT_Mang\BaoCao\Code\LTM_Chat\LTM_Chat\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0de9ab3b9c6edc752cd806f1ebe379997c1ecbf2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "E:\Nam3\Ky1\LT_Mang\BaoCao\Code\LTM_Chat\LTM_Chat\Views\_ViewImports.cshtml"
using LTM_Chat;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Nam3\Ky1\LT_Mang\BaoCao\Code\LTM_Chat\LTM_Chat\Views\_ViewImports.cshtml"
using LTM_Chat.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0de9ab3b9c6edc752cd806f1ebe379997c1ecbf2", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8d07991ba244efb5ee6732e6396c84e0b87d2da6", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "E:\Nam3\Ky1\LT_Mang\BaoCao\Code\LTM_Chat\LTM_Chat\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""text-center"">
    <h1 class=""display-4"">Welcome</h1>
    <p>Learn about <a href=""https://docs.microsoft.com/aspnet/core"">building Web apps with ASP.NET hahahâ khoi vao roi Core</a>.</p>
</div>
<div>
    <label>Thương: Nhập tin nhắn:</label>
    <input id=""tinnhan"" />
    <button onclick=""GuiTinNhan('thuong')"">Gửi</button>
</div>
<div>
    <label> Linh: Nhập tin nhắn:</label>
    <input id=""tinnhan-linh"" />
    <button onclick=""GuiTinNhan('linh')"">Gửi</button>
</div>
<div>
    <label> Quy: Nhập tin nhắn:</label>
    <input id=""tinnhan-quy"" />
    <button onclick=""GuiTinNhan('quy')"">Gửi</button>
</div>
<div>
    <label>Nội dung tin nhắn</label>
    <div id=""noidung"">        
    </div>
</div>
<script type=""text/javascript"">
    var tinnhan = document.getElementById(""tinnhan"").value;    
    function GuiTinNhan(dc) {
        if (dc == 'thuong') {
            tinnhan = document.getElementById(""tinnhan"").value;
            tinnhan = ""Thương : "" + tinnhan
        } else i");
            WriteLiteral(@"f (dc == 'linh') {
            tinnhan = document.getElementById(""tinnhan-linh"").value;
            tinnhan = ""Linh : "" + tinnhan
            
        } else {
            tinnhan = document.getElementById(""tinnhan-quy"").value;
            tinnhan = ""Quy : "" + tinnhan
        }
        
        // tao the p
        var the_p = document.createElement(""P"");
        // lay du lieu
        
        var textnode = document.createTextNode(tinnhan);
        // ĐUA DU LIỆu VÀo THẺ
        the_p.appendChild(textnode);
        // ĐƯA THẺ VÒ KHU VỤc NỘi DUNG
        document.getElementById(""noidung"").appendChild(the_p);
    }
</script>
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591