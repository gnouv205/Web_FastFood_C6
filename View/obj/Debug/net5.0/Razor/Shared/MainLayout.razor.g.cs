#pragma checksum "D:\C#6 2025\Asm_WebFood_6\View\Shared\MainLayout.razor" "{8829d00f-11b8-4213-878b-770e8597ac16}" "cffe1f191f9666ad790df5e2162b6f681138c523607cbff365af8e324b91a344"
// <auto-generated/>
#pragma warning disable 1591
namespace View.Shared
{
    #line default
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "D:\C#6 2025\Asm_WebFood_6\View\_Imports.razor"
using System.Net.Http

#nullable disable
    ;
#nullable restore
#line 2 "D:\C#6 2025\Asm_WebFood_6\View\_Imports.razor"
using System.Net.Http.Json

#nullable disable
    ;
#nullable restore
#line 3 "D:\C#6 2025\Asm_WebFood_6\View\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms

#nullable disable
    ;
#nullable restore
#line 4 "D:\C#6 2025\Asm_WebFood_6\View\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing

#nullable disable
    ;
#nullable restore
#line 5 "D:\C#6 2025\Asm_WebFood_6\View\_Imports.razor"
using Microsoft.AspNetCore.Components.Web

#nullable disable
    ;
#nullable restore
#line 6 "D:\C#6 2025\Asm_WebFood_6\View\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization

#nullable disable
    ;
#nullable restore
#line 7 "D:\C#6 2025\Asm_WebFood_6\View\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http

#nullable disable
    ;
#nullable restore
#line 8 "D:\C#6 2025\Asm_WebFood_6\View\_Imports.razor"
using Microsoft.JSInterop

#nullable disable
    ;
#nullable restore
#line 9 "D:\C#6 2025\Asm_WebFood_6\View\_Imports.razor"
using View

#nullable disable
    ;
#nullable restore
#line 10 "D:\C#6 2025\Asm_WebFood_6\View\_Imports.razor"
using View.Shared

#line default
#line hidden
#nullable disable
    ;
    #nullable restore
    public partial class MainLayout : LayoutComponentBase
    #nullable disable
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "page");
            __builder.AddAttribute(2, "b-0gsfdbd658");
            __builder.OpenElement(3, "div");
            __builder.AddAttribute(4, "class", "sidebar");
            __builder.AddAttribute(5, "b-0gsfdbd658");
            __builder.OpenComponent<global::View.Shared.NavMenu>(6);
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(7, "\r\n\r\n    ");
            __builder.OpenElement(8, "div");
            __builder.AddAttribute(9, "class", "main");
            __builder.AddAttribute(10, "b-0gsfdbd658");
            __builder.AddMarkupContent(11, "<div class=\"top-row px-4\" b-0gsfdbd658><a href=\"http://blazor.net\" target=\"_blank\" class=\"ml-md-auto\" b-0gsfdbd658>About</a></div>\r\n\r\n        ");
            __builder.OpenElement(12, "div");
            __builder.AddAttribute(13, "class", "content px-4");
            __builder.AddAttribute(14, "b-0gsfdbd658");
            __builder.AddContent(15, 
#nullable restore
#line 14 "D:\C#6 2025\Asm_WebFood_6\View\Shared\MainLayout.razor"
             Body

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
