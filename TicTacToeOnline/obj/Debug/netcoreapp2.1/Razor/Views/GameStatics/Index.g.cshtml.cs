#pragma checksum "C:\Users\User\Documents\Visual Studio 2017\Projects\TicTacToeOnline\TicTacToeOnline\Views\GameStatics\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "647f7e43a67bc963c7fe2cbdba64cda60acf816f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_GameStatics_Index), @"mvc.1.0.view", @"/Views/GameStatics/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/GameStatics/Index.cshtml", typeof(AspNetCore.Views_GameStatics_Index))]
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
#line 2 "C:\Users\User\Documents\Visual Studio 2017\Projects\TicTacToeOnline\TicTacToeOnline\Views\GameStatics\Index.cshtml"
using TicTacToeOnline.Models.TicTacToe;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"647f7e43a67bc963c7fe2cbdba64cda60acf816f", @"/Views/GameStatics/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"73f57aa8c218fcd2dc5311f7266919001d83fb06", @"/Views/_ViewImports.cshtml")]
    public class Views_GameStatics_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<TicTacToeOnline.Models.GameStatics>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(97, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 4 "C:\Users\User\Documents\Visual Studio 2017\Projects\TicTacToeOnline\TicTacToeOnline\Views\GameStatics\Index.cshtml"
  
    ViewData["Title"] = "Games Statics";
    int gamesPlayed = @Model.Count();
    int wonGames = @Model.Count(stats => !stats.WinnerSymbol.Equals(Symbol.Tie.ToString()));
    int xWins = Model.Count(stats => stats.WinnerSymbol.Equals(Symbol.X.ToString()));
    decimal winPrecen = Convert.ToDecimal(wonGames) / Convert.ToDecimal(gamesPlayed) * 100m;
    decimal xWinsPrecen = Convert.ToDecimal(xWins) / Convert.ToDecimal(wonGames) * 100m;
    decimal oWinsPrecen = Convert.ToDecimal(wonGames - xWins) / Convert.ToDecimal(wonGames) * 100m;

#line default
#line hidden
            BeginContext(653, 48, true);
            WriteLiteral("<h2>Games Statics</h2>\r\n<h4>Total Games Played: ");
            EndContext();
            BeginContext(702, 11, false);
#line 14 "C:\Users\User\Documents\Visual Studio 2017\Projects\TicTacToeOnline\TicTacToeOnline\Views\GameStatics\Index.cshtml"
                   Write(gamesPlayed);

#line default
#line hidden
            EndContext();
            BeginContext(713, 35, true);
            WriteLiteral("</h4>\r\n<h4>Games Ended With a Win: ");
            EndContext();
            BeginContext(749, 8, false);
#line 15 "C:\Users\User\Documents\Visual Studio 2017\Projects\TicTacToeOnline\TicTacToeOnline\Views\GameStatics\Index.cshtml"
                       Write(wonGames);

#line default
#line hidden
            EndContext();
            BeginContext(757, 2, true);
            WriteLiteral(" (");
            EndContext();
            BeginContext(761, 9, false);
#line 15 "C:\Users\User\Documents\Visual Studio 2017\Projects\TicTacToeOnline\TicTacToeOnline\Views\GameStatics\Index.cshtml"
                                   Write(winPrecen);

#line default
#line hidden
            EndContext();
            BeginContext(771, 37, true);
            WriteLiteral("%)</h4>\r\n<h4>Games Ended With a Tie: ");
            EndContext();
            BeginContext(810, 20, false);
#line 16 "C:\Users\User\Documents\Visual Studio 2017\Projects\TicTacToeOnline\TicTacToeOnline\Views\GameStatics\Index.cshtml"
                        Write(gamesPlayed-wonGames);

#line default
#line hidden
            EndContext();
            BeginContext(831, 2, true);
            WriteLiteral(" (");
            EndContext();
            BeginContext(835, 13, false);
#line 16 "C:\Users\User\Documents\Visual Studio 2017\Projects\TicTacToeOnline\TicTacToeOnline\Views\GameStatics\Index.cshtml"
                                                 Write(100-winPrecen);

#line default
#line hidden
            EndContext();
            BeginContext(849, 36, true);
            WriteLiteral("%)</h4>\r\n<h4>Games Won By Player X: ");
            EndContext();
            BeginContext(886, 5, false);
#line 17 "C:\Users\User\Documents\Visual Studio 2017\Projects\TicTacToeOnline\TicTacToeOnline\Views\GameStatics\Index.cshtml"
                      Write(xWins);

#line default
#line hidden
            EndContext();
            BeginContext(891, 2, true);
            WriteLiteral(" (");
            EndContext();
            BeginContext(895, 11, false);
#line 17 "C:\Users\User\Documents\Visual Studio 2017\Projects\TicTacToeOnline\TicTacToeOnline\Views\GameStatics\Index.cshtml"
                               Write(xWinsPrecen);

#line default
#line hidden
            EndContext();
            BeginContext(907, 36, true);
            WriteLiteral("%)</h4>\r\n<h4>Games Won By Player O: ");
            EndContext();
            BeginContext(945, 16, false);
#line 18 "C:\Users\User\Documents\Visual Studio 2017\Projects\TicTacToeOnline\TicTacToeOnline\Views\GameStatics\Index.cshtml"
                       Write(wonGames - xWins);

#line default
#line hidden
            EndContext();
            BeginContext(962, 2, true);
            WriteLiteral(" (");
            EndContext();
            BeginContext(966, 11, false);
#line 18 "C:\Users\User\Documents\Visual Studio 2017\Projects\TicTacToeOnline\TicTacToeOnline\Views\GameStatics\Index.cshtml"
                                            Write(oWinsPrecen);

#line default
#line hidden
            EndContext();
            BeginContext(978, 93, true);
            WriteLiteral("%)</h4>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(1072, 48, false);
#line 23 "C:\Users\User\Documents\Visual Studio 2017\Projects\TicTacToeOnline\TicTacToeOnline\Views\GameStatics\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.WinnerSymbol));

#line default
#line hidden
            EndContext();
            BeginContext(1120, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(1176, 41, false);
#line 26 "C:\Users\User\Documents\Visual Studio 2017\Projects\TicTacToeOnline\TicTacToeOnline\Views\GameStatics\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Moves));

#line default
#line hidden
            EndContext();
            BeginContext(1217, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(1273, 47, false);
#line 29 "C:\Users\User\Documents\Visual Studio 2017\Projects\TicTacToeOnline\TicTacToeOnline\Views\GameStatics\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.WinningLine));

#line default
#line hidden
            EndContext();
            BeginContext(1320, 86, true);
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 35 "C:\Users\User\Documents\Visual Studio 2017\Projects\TicTacToeOnline\TicTacToeOnline\Views\GameStatics\Index.cshtml"
         foreach (var item in Model)
	{

#line default
#line hidden
            BeginContext(1448, 60, true);
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1509, 47, false);
#line 39 "C:\Users\User\Documents\Visual Studio 2017\Projects\TicTacToeOnline\TicTacToeOnline\Views\GameStatics\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.WinnerSymbol));

#line default
#line hidden
            EndContext();
            BeginContext(1556, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1624, 40, false);
#line 42 "C:\Users\User\Documents\Visual Studio 2017\Projects\TicTacToeOnline\TicTacToeOnline\Views\GameStatics\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Moves));

#line default
#line hidden
            EndContext();
            BeginContext(1664, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1732, 46, false);
#line 45 "C:\Users\User\Documents\Visual Studio 2017\Projects\TicTacToeOnline\TicTacToeOnline\Views\GameStatics\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.WinningLine));

#line default
#line hidden
            EndContext();
            BeginContext(1778, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1845, 59, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b3515ad37f684dd2aadbc7a2be284ff8", async() => {
                BeginContext(1893, 7, true);
                WriteLiteral("Details");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 48 "C:\Users\User\Documents\Visual Studio 2017\Projects\TicTacToeOnline\TicTacToeOnline\Views\GameStatics\Index.cshtml"
                                              WriteLiteral(item.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1904, 44, true);
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
            EndContext();
#line 51 "C:\Users\User\Documents\Visual Studio 2017\Projects\TicTacToeOnline\TicTacToeOnline\Views\GameStatics\Index.cshtml"
	}

#line default
#line hidden
            BeginContext(1952, 24, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n");
            EndContext();
            BeginContext(1976, 65, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e1f7a62197134e219d147783dd4a9c35", async() => {
                BeginContext(2020, 17, true);
                WriteLiteral("Back To Main Page");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2041, 2, true);
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<TicTacToeOnline.Models.GameStatics>> Html { get; private set; }
    }
}
#pragma warning restore 1591