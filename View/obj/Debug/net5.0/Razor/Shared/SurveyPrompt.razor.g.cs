#pragma checksum "D:\C#6 2025\Asm_WebFood_6\View\Shared\SurveyPrompt.razor" "{8829d00f-11b8-4213-878b-770e8597ac16}" "214960f9237b524914a1d23ce57413632494014d28e84e28c88a7e3d81998676"
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
    public partial class SurveyPrompt : global::Microsoft.AspNetCore.Components.ComponentBase
    #nullable disable
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "alert alert-secondary mt-4");
            __builder.AddAttribute(2, "role", "alert");
            __builder.AddMarkupContent(3, "<span class=\"oi oi-pencil mr-2\" aria-hidden=\"true\"></span>\r\n    ");
            __builder.OpenElement(4, "strong");
            __builder.AddContent(5, 
#nullable restore
#line 3 "D:\C#6 2025\Asm_WebFood_6\View\Shared\SurveyPrompt.razor"
             Title

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(6, "\r\n\r\n    ");
            __builder.AddMarkupContent(7, "<span class=\"text-nowrap\">\r\n        Please take our\r\n        <a target=\"_blank\" class=\"font-weight-bold\" href=\"https://go.microsoft.com/fwlink/?linkid=2137916\">brief survey</a></span>\r\n    and tell us what you think.\r\n");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 12 "D:\C#6 2025\Asm_WebFood_6\View\Shared\SurveyPrompt.razor"
       
    // Demonstrates how a parent component can supply parameters
    [Parameter]
    public string Title { get; set; }

#line default
#line hidden
#nullable disable

    }
}
#pragma warning restore 1591
