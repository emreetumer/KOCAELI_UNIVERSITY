#pragma checksum "C:\Users\Emre\source\repos\EvrakTakip\Pages\Bakimlar\BakimGecmisi.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4ac21936642c03ced0f0f7e7d2a13048c7164b81"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(EvrakTakip.Pages.Bakimlar.Pages_Bakimlar_BakimGecmisi), @"mvc.1.0.razor-page", @"/Pages/Bakimlar/BakimGecmisi.cshtml")]
namespace EvrakTakip.Pages.Bakimlar
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
#line 1 "C:\Users\Emre\source\repos\EvrakTakip\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Emre\source\repos\EvrakTakip\Pages\_ViewImports.cshtml"
using EvrakTakip;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Emre\source\repos\EvrakTakip\Pages\_ViewImports.cshtml"
using EvrakTakip.Data;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4ac21936642c03ced0f0f7e7d2a13048c7164b81", @"/Pages/Bakimlar/BakimGecmisi.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9e1b30c19b9ca2782335863ae62a348a93f13ed2", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Bakimlar_BakimGecmisi : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "../Mevraklar/Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-success form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "Detaylar", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
#nullable restore
#line 3 "C:\Users\Emre\source\repos\EvrakTakip\Pages\Bakimlar\BakimGecmisi.cshtml"
  
    ViewData["Title"] = "BakimGecmisi";
    Layout = "~/Pages/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"container pt-4 pb-2 row\">\r\n    <div class=\"col-6\">\r\n        <h2 class=\"text-info py-2\">Evrak Geçmişi</h2>\r\n    </div>\r\n    <div class=\"col-3 offset-3 text-right py-2\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4ac21936642c03ced0f0f7e7d2a13048c7164b815080", async() => {
                WriteLiteral("Listeye Geri Dön");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-kullaniciId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 13 "C:\Users\Emre\source\repos\EvrakTakip\Pages\Bakimlar\BakimGecmisi.cshtml"
                                                    WriteLiteral(Model.KullaniciId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["kullaniciId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-kullaniciId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["kullaniciId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n</div>\r\n\r\n\r\n");
#nullable restore
#line 18 "C:\Users\Emre\source\repos\EvrakTakip\Pages\Bakimlar\BakimGecmisi.cshtml"
 if (Model.BakimHizmetiGenel.Count == 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"backgroundwhite\">\r\n        <p>Evrak Geçmişi Bulunamamıştır!</p>\r\n    </div>\r\n");
#nullable restore
#line 23 "C:\Users\Emre\source\repos\EvrakTakip\Pages\Bakimlar\BakimGecmisi.cshtml"
}

else
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""container backgroundwhite"">
        <div class=""card"">
            <div class=""card-header bg-dark text-light ml-0 row container"">
                <div class=""col-1 text-center pt-3 text-white-50"">
                    <i class=""fas fa-user fa-2x""></i>
                </div>

                <div class=""col-5"">
                    <label class=""text-info"">");
#nullable restore
#line 35 "C:\Users\Emre\source\repos\EvrakTakip\Pages\Bakimlar\BakimGecmisi.cshtml"
                                        Write(Model.BakimHizmetiGenel[0].Evrak.ApplicationUser.AdSoyad);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label><br />\r\n                    <label class=\"text-info\">");
#nullable restore
#line 36 "C:\Users\Emre\source\repos\EvrakTakip\Pages\Bakimlar\BakimGecmisi.cshtml"
                                        Write(Model.BakimHizmetiGenel[0].Evrak.ApplicationUser.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral(" / ");
#nullable restore
#line 36 "C:\Users\Emre\source\repos\EvrakTakip\Pages\Bakimlar\BakimGecmisi.cshtml"
                                                                                                  Write(Model.BakimHizmetiGenel[0].Evrak.ApplicationUser.PhoneNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label><br />\r\n                </div>\r\n\r\n                <div class=\"col-5 text-right\">\r\n                    <label class=\"text-info\">");
#nullable restore
#line 40 "C:\Users\Emre\source\repos\EvrakTakip\Pages\Bakimlar\BakimGecmisi.cshtml"
                                        Write(Model.BakimHizmetiGenel[0].Evrak.EvrakTipi);

#line default
#line hidden
#nullable disable
            WriteLiteral("  ");
            WriteLiteral("  </label> <br />\r\n                    <label class=\"text-info\">");
#nullable restore
#line 41 "C:\Users\Emre\source\repos\EvrakTakip\Pages\Bakimlar\BakimGecmisi.cshtml"
                                        Write(Model.BakimHizmetiGenel[0].Evrak.Yil);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</label>
                </div>

                <div class=""col-1 text-center pt-3 text-white-50"">
                    <i class=""fas fa-file fa-2x""></i>
                </div>
            </div>
        </div>




        <div class=""card-body"">
            <table class=""table table-striped border"">
                <tr class=""table-secondary"">
                    <th>Toplam Kayıt Saati
");
            WriteLiteral("                    </th>\r\n                    <th>Toplam Fiyat\r\n");
            WriteLiteral("                    </th>\r\n                    <th>Detaylar\r\n");
            WriteLiteral("                    </th>\r\n                    <th>Kayıt Tarihi\r\n");
            WriteLiteral("                    </th>\r\n\r\n                    <th>\r\n\r\n                    </th>\r\n\r\n                </tr>\r\n\r\n");
#nullable restore
#line 75 "C:\Users\Emre\source\repos\EvrakTakip\Pages\Bakimlar\BakimGecmisi.cshtml"
                 foreach (var item in Model.BakimHizmetiGenel)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
#nullable restore
#line 79 "C:\Users\Emre\source\repos\EvrakTakip\Pages\Bakimlar\BakimGecmisi.cshtml"
                       Write(Html.DisplayFor(m => item.EvrakSayacSaat));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 82 "C:\Users\Emre\source\repos\EvrakTakip\Pages\Bakimlar\BakimGecmisi.cshtml"
                       Write(Html.DisplayFor(m => item.ToplamFiyat));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 85 "C:\Users\Emre\source\repos\EvrakTakip\Pages\Bakimlar\BakimGecmisi.cshtml"
                       Write(Html.DisplayFor(m => item.Detaylar));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 88 "C:\Users\Emre\source\repos\EvrakTakip\Pages\Bakimlar\BakimGecmisi.cshtml"
                       Write(Html.DisplayFor(m => item.EklendigiTarih));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n\r\n                        <td>\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4ac21936642c03ced0f0f7e7d2a13048c7164b8112773", async() => {
                WriteLiteral("<i class=\"fas fa-info-circle\"></i> &nbsp; Detaylar");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-evrakid", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 92 "C:\Users\Emre\source\repos\EvrakTakip\Pages\Bakimlar\BakimGecmisi.cshtml"
                                                                                            WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["evrakid"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-evrakid", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["evrakid"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </td>\r\n\r\n                    </tr>\r\n");
#nullable restore
#line 96 "C:\Users\Emre\source\repos\EvrakTakip\Pages\Bakimlar\BakimGecmisi.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </table>\r\n        </div>\r\n\r\n    </div>\r\n");
#nullable restore
#line 102 "C:\Users\Emre\source\repos\EvrakTakip\Pages\Bakimlar\BakimGecmisi.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EvrakTakip.Pages.Bakimlar.BakimGecmisiModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<EvrakTakip.Pages.Bakimlar.BakimGecmisiModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<EvrakTakip.Pages.Bakimlar.BakimGecmisiModel>)PageContext?.ViewData;
        public EvrakTakip.Pages.Bakimlar.BakimGecmisiModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
