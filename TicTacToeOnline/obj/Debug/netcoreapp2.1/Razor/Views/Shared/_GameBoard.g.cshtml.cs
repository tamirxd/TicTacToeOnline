#pragma checksum "C:\Users\User\Documents\Visual Studio 2017\Projects\TicTacToeOnline\TicTacToeOnline\Views\Shared\_GameBoard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a749406d65f73ef3cfa022f2b20aff1d4423e783"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__GameBoard), @"mvc.1.0.view", @"/Views/Shared/_GameBoard.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_GameBoard.cshtml", typeof(AspNetCore.Views_Shared__GameBoard))]
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
#line 1 "C:\Users\User\Documents\Visual Studio 2017\Projects\TicTacToeOnline\TicTacToeOnline\Views\_ViewImports.cshtml"
using TicTacToeOnline;

#line default
#line hidden
#line 2 "C:\Users\User\Documents\Visual Studio 2017\Projects\TicTacToeOnline\TicTacToeOnline\Views\_ViewImports.cshtml"
using TicTacToeOnline.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a749406d65f73ef3cfa022f2b20aff1d4423e783", @"/Views/Shared/_GameBoard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"73f57aa8c218fcd2dc5311f7266919001d83fb06", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__GameBoard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TicTacToeOnline.ViewModels.GamePartialViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(59, 28, true);
            WriteLiteral("\r\n<section>\r\n\r\n    <table>\r\n");
            EndContext();
#line 7 "C:\Users\User\Documents\Visual Studio 2017\Projects\TicTacToeOnline\TicTacToeOnline\Views\Shared\_GameBoard.cshtml"
          
	    for (int i = 0; i < 3; i++)
	    {

#line default
#line hidden
            BeginContext(141, 22, true);
            WriteLiteral("                <tr>\r\n");
            EndContext();
#line 11 "C:\Users\User\Documents\Visual Studio 2017\Projects\TicTacToeOnline\TicTacToeOnline\Views\Shared\_GameBoard.cshtml"
                       for (int j = 0; j < 3; j++)
			{

#line default
#line hidden
            BeginContext(221, 157, true);
            WriteLiteral("                            <td width=\"100\" height=\"100\" align=\"center\">\r\n                                <button height=\"100\" style=\"width:100%;height:100%\"");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 378, "\"", 391, 1);
#line 14 "C:\Users\User\Documents\Visual Studio 2017\Projects\TicTacToeOnline\TicTacToeOnline\Views\Shared\_GameBoard.cshtml"
WriteAttributeValue("", 383, i*3+j, 383, 8, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(392, 90, true);
            WriteLiteral(" class=\"btn btn-outline-secondary btn-game\"></button>\r\n                            </td>\r\n");
            EndContext();
#line 16 "C:\Users\User\Documents\Visual Studio 2017\Projects\TicTacToeOnline\TicTacToeOnline\Views\Shared\_GameBoard.cshtml"
			}
                    

#line default
#line hidden
            BeginContext(511, 23, true);
            WriteLiteral("                </tr>\r\n");
            EndContext();
#line 19 "C:\Users\User\Documents\Visual Studio 2017\Projects\TicTacToeOnline\TicTacToeOnline\Views\Shared\_GameBoard.cshtml"
	    }
        

#line default
#line hidden
            BeginContext(553, 84, true);
            WriteLiteral("    </table>\r\n    <div id=\"msg-box\" class=\"text-sm-center mt-3\"></div>\r\n</section>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TicTacToeOnline.ViewModels.GamePartialViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
