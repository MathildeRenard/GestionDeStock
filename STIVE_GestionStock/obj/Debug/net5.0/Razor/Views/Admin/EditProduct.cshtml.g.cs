#pragma checksum "C:\Users\renar\Documents\GestionDeStock\STIVE_GestionStock\Views\Admin\EditProduct.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d9e8cdefa7f6c94909d632e3a936e23ea3e098de"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_EditProduct), @"mvc.1.0.view", @"/Views/Admin/EditProduct.cshtml")]
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
#line 1 "C:\Users\renar\Documents\GestionDeStock\STIVE_GestionStock\Views\_ViewImports.cshtml"
using STIVE_GestionStock;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\renar\Documents\GestionDeStock\STIVE_GestionStock\Views\_ViewImports.cshtml"
using STIVE_GestionStock.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\renar\Documents\GestionDeStock\STIVE_GestionStock\Views\_ViewImports.cshtml"
using STIVE_GestionStock.Services;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d9e8cdefa7f6c94909d632e3a936e23ea3e098de", @"/Views/Admin/EditProduct.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f3ec5bcceb5f2fd43b1e7510c82ab6a246a62d29", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_EditProduct : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "SubmitEditFormProduct", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<h1>Modification du produit</h1>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d9e8cdefa7f6c94909d632e3a936e23ea3e098de4561", async() => {
                WriteLiteral("\r\n    <div>\r\n        <input class=\"form-control\" type=\"text\" name=\"id\" hidden placeholder=\"id\"");
                BeginWriteAttribute("value", " value=\"", 208, "\"", 235, 1);
#nullable restore
#line 5 "C:\Users\renar\Documents\GestionDeStock\STIVE_GestionStock\Views\Admin\EditProduct.cshtml"
WriteAttributeValue("", 216, ViewBag.Product.Id, 216, 19, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n    </div>\r\n    <div class=\"row\">\r\n        <div class=\"col-4\">\r\n            <label");
                BeginWriteAttribute("class", " class=\"", 323, "\"", 331, 0);
                EndWriteAttribute();
                WriteLiteral(" for=\"name\">Nom du produit</label>\r\n            <input class=\"form-control\" id=\"name\" type=\"text\" name=\"name\" placeholder=\"Nom\"");
                BeginWriteAttribute("value", " value=\"", 459, "\"", 488, 1);
#nullable restore
#line 10 "C:\Users\renar\Documents\GestionDeStock\STIVE_GestionStock\Views\Admin\EditProduct.cshtml"
WriteAttributeValue("", 467, ViewBag.Product.Name, 467, 21, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n        </div>\r\n        <div class=\"col-4\">\r\n            <label");
                BeginWriteAttribute("class", " class=\"", 557, "\"", 565, 0);
                EndWriteAttribute();
                WriteLiteral(" for=\"Description\">Description</label>\r\n            <input class=\"form-control\" id=\"Description\" type=\"text\" name=\"description\" placeholder=\"Description\"");
                BeginWriteAttribute("value", " value=\"", 719, "\"", 755, 1);
#nullable restore
#line 14 "C:\Users\renar\Documents\GestionDeStock\STIVE_GestionStock\Views\Admin\EditProduct.cshtml"
WriteAttributeValue("", 727, ViewBag.Product.Description, 727, 28, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n        </div>\r\n        <div class=\"col-4\">\r\n            <label");
                BeginWriteAttribute("class", " class=\"", 824, "\"", 832, 0);
                EndWriteAttribute();
                WriteLiteral(" for=\"ProductYear\">Année de production</label>\r\n            <input class=\"form-control\" id=\"ProductYear\" type=\"text\" name=\"product_year\" placeholder=\"Année de production\"");
                BeginWriteAttribute("value", " value=\"", 1003, "\"", 1040, 1);
#nullable restore
#line 18 "C:\Users\renar\Documents\GestionDeStock\STIVE_GestionStock\Views\Admin\EditProduct.cshtml"
WriteAttributeValue("", 1011, ViewBag.Product.Product_year, 1011, 29, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n        </div>\r\n    </div>\r\n    <br />\r\n    <div class=\"row\">\r\n        <div class=\"col-6\">\r\n            <label");
                BeginWriteAttribute("class", " class=\"", 1156, "\"", 1164, 0);
                EndWriteAttribute();
                WriteLiteral(" for=\"Quantity\">Quantité</label>\r\n            <input class=\"form-control\" id=\"Quantity\" type=\"text\" name=\"quantity\" placeholder=\"Quantité\"");
                BeginWriteAttribute("value", " value=\"", 1303, "\"", 1336, 1);
#nullable restore
#line 25 "C:\Users\renar\Documents\GestionDeStock\STIVE_GestionStock\Views\Admin\EditProduct.cshtml"
WriteAttributeValue("", 1311, ViewBag.Product.Quantity, 1311, 25, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n        </div>\r\n        <div class=\"col-6\">\r\n            <label");
                BeginWriteAttribute("class", " class=\"", 1405, "\"", 1413, 0);
                EndWriteAttribute();
                WriteLiteral(" for=\"UnitPrice\">Prix unitaire</label>\r\n            <input class=\"form-control\" id=\"UnitPrice\" type=\"text\" name=\"unit_price\" placeholder=\"Prix\"");
                BeginWriteAttribute("value", " value=\"", 1557, "\"", 1592, 1);
#nullable restore
#line 29 "C:\Users\renar\Documents\GestionDeStock\STIVE_GestionStock\Views\Admin\EditProduct.cshtml"
WriteAttributeValue("", 1565, ViewBag.Product.Unit_price, 1565, 27, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n        </div>\r\n    </div>\r\n    <br />\r\n    <div class=\"row\">\r\n        <div class=\"col-6\">\r\n            <label");
                BeginWriteAttribute("class", " class=\"", 1708, "\"", 1716, 0);
                EndWriteAttribute();
                WriteLiteral(" for=\"QuantityLot\">Quantité du lot</label>\r\n            <input class=\"form-control\" type=\"text\" id=\"QuantityLot\" name=\"quantity_lot\" placeholder=\"Quantité en lot\"");
                BeginWriteAttribute("value", " value=\"", 1879, "\"", 1916, 1);
#nullable restore
#line 36 "C:\Users\renar\Documents\GestionDeStock\STIVE_GestionStock\Views\Admin\EditProduct.cshtml"
WriteAttributeValue("", 1887, ViewBag.Product.Quantity_lot, 1887, 29, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n        </div>\r\n        <div class=\"col-6\">\r\n            <label");
                BeginWriteAttribute("class", " class=\"", 1985, "\"", 1993, 0);
                EndWriteAttribute();
                WriteLiteral(" for=\"PriceLot\">Prix du lot</label>\r\n            <input class=\"form-control\" id=\"PriceLot\" type=\"text\" name=\"lot_price\" placeholder=\"Prix en lot\"");
                BeginWriteAttribute("value", " value=\"", 2139, "\"", 2173, 1);
#nullable restore
#line 40 "C:\Users\renar\Documents\GestionDeStock\STIVE_GestionStock\Views\Admin\EditProduct.cshtml"
WriteAttributeValue("", 2147, ViewBag.Product.Lot_price, 2147, 26, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n        </div>\r\n    </div>\r\n    <br />\r\n    <div class=\"row\">\r\n        <div class=\"col-12\">\r\n            <label");
                BeginWriteAttribute("class", " class=\"", 2290, "\"", 2298, 0);
                EndWriteAttribute();
                WriteLiteral(" for=\"photo\">Photo</label>\r\n            <input class=\"form-control\" id=\"photo\" type=\"text\" name=\"url_photo\" placeholder=\"Photo\"");
                BeginWriteAttribute("value", " value=\"", 2426, "\"", 2460, 1);
#nullable restore
#line 47 "C:\Users\renar\Documents\GestionDeStock\STIVE_GestionStock\Views\Admin\EditProduct.cshtml"
WriteAttributeValue("", 2434, ViewBag.Product.Url_photo, 2434, 26, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n        </div>\r\n    </div>\r\n    <br />\r\n    <div class=\"row\">\r\n        <div class=\"col-4\">\r\n            <label");
                BeginWriteAttribute("class", " class=\"", 2576, "\"", 2584, 0);
                EndWriteAttribute();
                WriteLiteral(" for=\"home\">Maison</label>\r\n            <select class=\"form-control\" id=\"home\" name=\"id_Home\" aria-label=\"Maison\">\r\n");
#nullable restore
#line 55 "C:\Users\renar\Documents\GestionDeStock\STIVE_GestionStock\Views\Admin\EditProduct.cshtml"
                 foreach (Home h in ViewBag.Home)
                {
                    if (ViewBag.Product.Home.Id_Home == h.Id_Home)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d9e8cdefa7f6c94909d632e3a936e23ea3e098de12619", async() => {
#nullable restore
#line 59 "C:\Users\renar\Documents\GestionDeStock\STIVE_GestionStock\Views\Admin\EditProduct.cshtml"
                                                       Write(h.Name);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 59 "C:\Users\renar\Documents\GestionDeStock\STIVE_GestionStock\Views\Admin\EditProduct.cshtml"
                                    WriteLiteral(h.Id_Home);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 60 "C:\Users\renar\Documents\GestionDeStock\STIVE_GestionStock\Views\Admin\EditProduct.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d9e8cdefa7f6c94909d632e3a936e23ea3e098de15147", async() => {
#nullable restore
#line 63 "C:\Users\renar\Documents\GestionDeStock\STIVE_GestionStock\Views\Admin\EditProduct.cshtml"
                                              Write(h.Name);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 63 "C:\Users\renar\Documents\GestionDeStock\STIVE_GestionStock\Views\Admin\EditProduct.cshtml"
                           WriteLiteral(h.Id_Home);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 64 "C:\Users\renar\Documents\GestionDeStock\STIVE_GestionStock\Views\Admin\EditProduct.cshtml"
                    }
                }

#line default
#line hidden
#nullable disable
                WriteLiteral("            </select>\r\n        </div>\r\n        <div class=\"col-4\">\r\n            <label");
                BeginWriteAttribute("class", " class=\"", 3209, "\"", 3217, 0);
                EndWriteAttribute();
                WriteLiteral(" for=\"family\">Famille</label>\r\n            <select class=\"form-control\" id=\"family\" name=\"id_Family\" aria-label=\"Famille\">\r\n");
#nullable restore
#line 71 "C:\Users\renar\Documents\GestionDeStock\STIVE_GestionStock\Views\Admin\EditProduct.cshtml"
                 foreach (Family f in ViewBag.Family)
                {
                    if (ViewBag.Product.Family.Id_Family == f.Id_Family)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d9e8cdefa7f6c94909d632e3a936e23ea3e098de18067", async() => {
#nullable restore
#line 75 "C:\Users\renar\Documents\GestionDeStock\STIVE_GestionStock\Views\Admin\EditProduct.cshtml"
                                                         Write(f.Name);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 75 "C:\Users\renar\Documents\GestionDeStock\STIVE_GestionStock\Views\Admin\EditProduct.cshtml"
                                    WriteLiteral(f.Id_Family);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 76 "C:\Users\renar\Documents\GestionDeStock\STIVE_GestionStock\Views\Admin\EditProduct.cshtml"

                    }
                    else
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d9e8cdefa7f6c94909d632e3a936e23ea3e098de20601", async() => {
#nullable restore
#line 80 "C:\Users\renar\Documents\GestionDeStock\STIVE_GestionStock\Views\Admin\EditProduct.cshtml"
                                                Write(f.Name);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 80 "C:\Users\renar\Documents\GestionDeStock\STIVE_GestionStock\Views\Admin\EditProduct.cshtml"
                           WriteLiteral(f.Id_Family);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 81 "C:\Users\renar\Documents\GestionDeStock\STIVE_GestionStock\Views\Admin\EditProduct.cshtml"
                    }
                }

#line default
#line hidden
#nullable disable
                WriteLiteral("            </select>\r\n        </div>\r\n        <div class=\"col-4\">\r\n            <label");
                BeginWriteAttribute("class", " class=\"", 3866, "\"", 3874, 0);
                EndWriteAttribute();
                WriteLiteral(" for=\"warehouse\">Entrepôt</label>\r\n            <select class=\"form-control\" id=\"warehouse\" name=\"id_Warehouse\" aria-label=\"Entrepot\">\r\n");
#nullable restore
#line 88 "C:\Users\renar\Documents\GestionDeStock\STIVE_GestionStock\Views\Admin\EditProduct.cshtml"
                 foreach (Warehouse w in ViewBag.Warehouse)
                {
                    if (ViewBag.Product.Warehouse.Id_Warehouse == w.Id_Warehouse)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d9e8cdefa7f6c94909d632e3a936e23ea3e098de23551", async() => {
#nullable restore
#line 92 "C:\Users\renar\Documents\GestionDeStock\STIVE_GestionStock\Views\Admin\EditProduct.cshtml"
                                                            Write(w.Name);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 92 "C:\Users\renar\Documents\GestionDeStock\STIVE_GestionStock\Views\Admin\EditProduct.cshtml"
                                    WriteLiteral(w.Id_Warehouse);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 93 "C:\Users\renar\Documents\GestionDeStock\STIVE_GestionStock\Views\Admin\EditProduct.cshtml"


                    }
                    else
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d9e8cdefa7f6c94909d632e3a936e23ea3e098de26093", async() => {
#nullable restore
#line 98 "C:\Users\renar\Documents\GestionDeStock\STIVE_GestionStock\Views\Admin\EditProduct.cshtml"
                                                   Write(w.Name);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 98 "C:\Users\renar\Documents\GestionDeStock\STIVE_GestionStock\Views\Admin\EditProduct.cshtml"
                           WriteLiteral(w.Id_Warehouse);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 99 "C:\Users\renar\Documents\GestionDeStock\STIVE_GestionStock\Views\Admin\EditProduct.cshtml"
                    }
                }

#line default
#line hidden
#nullable disable
                WriteLiteral("            </select>\r\n        </div>\r\n    </div>\r\n    <br />\r\n    <div class=\"row justify-content-center\" >\r\n        <div class=\"form-check col-md-3\">\r\n");
#nullable restore
#line 107 "C:\Users\renar\Documents\GestionDeStock\STIVE_GestionStock\Views\Admin\EditProduct.cshtml"
             if (ViewBag.Product.Auto_replenishment == true)
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <input class=\"form-check-input position-static\" type=\"checkbox\" id=\"gridCheck\" name=\"auto_replenishment\" value=\"true\" checked>\r\n");
#nullable restore
#line 110 "C:\Users\renar\Documents\GestionDeStock\STIVE_GestionStock\Views\Admin\EditProduct.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <input class=\"form-check-input position-static\" type=\"checkbox\" id=\"gridCheck\" name=\"auto_replenishment\" value=\"true\">\r\n");
#nullable restore
#line 114 "C:\Users\renar\Documents\GestionDeStock\STIVE_GestionStock\Views\Admin\EditProduct.cshtml"
            }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"            <label class=""form-check-label"" for=""gridCheck""> Auto réapprovisionnement</label>
        </div>
    </div>
    <br />
    <div class=""row justify-content-center"">
        <div class=""col-6"">
            <button type=""submit"" class=""btn btn-primary btn-block"">Enregistrer</button>
        </div>
    </div>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
