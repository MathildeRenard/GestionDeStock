#pragma checksum "C:\Users\yuuma\Desktop\Projet CUBE 4 Gestion Stock\GestionDeStock\STIVE_GestionStock\Views\Home\ShowProduct.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bd10ce9d4298350abd28c37e86bdfde34af62786"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_ShowProduct), @"mvc.1.0.view", @"/Views/Home/ShowProduct.cshtml")]
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
#line 1 "C:\Users\yuuma\Desktop\Projet CUBE 4 Gestion Stock\GestionDeStock\STIVE_GestionStock\Views\_ViewImports.cshtml"
using STIVE_GestionStock;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\yuuma\Desktop\Projet CUBE 4 Gestion Stock\GestionDeStock\STIVE_GestionStock\Views\_ViewImports.cshtml"
using STIVE_GestionStock.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\yuuma\Desktop\Projet CUBE 4 Gestion Stock\GestionDeStock\STIVE_GestionStock\Views\_ViewImports.cshtml"
using STIVE_GestionStock.Services;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bd10ce9d4298350abd28c37e86bdfde34af62786", @"/Views/Home/ShowProduct.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f3ec5bcceb5f2fd43b1e7510c82ab6a246a62d29", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_ShowProduct : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Product>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\yuuma\Desktop\Projet CUBE 4 Gestion Stock\GestionDeStock\STIVE_GestionStock\Views\Home\ShowProduct.cshtml"
  
    ViewData["Title"] = "Produit";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1> Information sur le produit : </h1>\r\n\r\n<div class=\"col\">\r\n    <img");
            BeginWriteAttribute("src", " src=\"", 131, "\"", 153, 1);
#nullable restore
#line 9 "C:\Users\yuuma\Desktop\Projet CUBE 4 Gestion Stock\GestionDeStock\STIVE_GestionStock\Views\Home\ShowProduct.cshtml"
WriteAttributeValue("", 137, Model.Url_photo, 137, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n</div>\r\n<div class=\"col\">\r\n    <p>Nom : ");
#nullable restore
#line 12 "C:\Users\yuuma\Desktop\Projet CUBE 4 Gestion Stock\GestionDeStock\STIVE_GestionStock\Views\Home\ShowProduct.cshtml"
        Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\r\n</div>\r\n<div class=\"col\">\r\n    <p>Description : ");
#nullable restore
#line 15 "C:\Users\yuuma\Desktop\Projet CUBE 4 Gestion Stock\GestionDeStock\STIVE_GestionStock\Views\Home\ShowProduct.cshtml"
                Write(Model.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\r\n</div>\r\n<div class=\"col\">\r\n    <p>Famille : ");
#nullable restore
#line 18 "C:\Users\yuuma\Desktop\Projet CUBE 4 Gestion Stock\GestionDeStock\STIVE_GestionStock\Views\Home\ShowProduct.cshtml"
            Write(Model.Family.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\r\n</div>\r\n<div class=\"col\">\r\n    <p>Quantité : ");
#nullable restore
#line 21 "C:\Users\yuuma\Desktop\Projet CUBE 4 Gestion Stock\GestionDeStock\STIVE_GestionStock\Views\Home\ShowProduct.cshtml"
             Write(Model.Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\r\n</div>\r\n<div class=\"col\">\r\n    <p>Disponnible : ");
#nullable restore
#line 24 "C:\Users\yuuma\Desktop\Projet CUBE 4 Gestion Stock\GestionDeStock\STIVE_GestionStock\Views\Home\ShowProduct.cshtml"
                Write(Model.Available);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\r\n</div>\r\n<div class=\"col\">\r\n    <p>Année de production : ");
#nullable restore
#line 27 "C:\Users\yuuma\Desktop\Projet CUBE 4 Gestion Stock\GestionDeStock\STIVE_GestionStock\Views\Home\ShowProduct.cshtml"
                        Write(Model.Product_year);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\r\n</div>\r\n<div class=\"col\">\r\n    <p>Prix unitaire : ");
#nullable restore
#line 30 "C:\Users\yuuma\Desktop\Projet CUBE 4 Gestion Stock\GestionDeStock\STIVE_GestionStock\Views\Home\ShowProduct.cshtml"
                  Write(Model.Unit_price);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\r\n</div>\r\n<div class=\"col\">\r\n    <p>Quantié en lot : ");
#nullable restore
#line 33 "C:\Users\yuuma\Desktop\Projet CUBE 4 Gestion Stock\GestionDeStock\STIVE_GestionStock\Views\Home\ShowProduct.cshtml"
                   Write(Model.Quantity_lot);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\r\n</div>\r\n<div class=\"col\">\r\n    <p>Prix du lot : ");
#nullable restore
#line 36 "C:\Users\yuuma\Desktop\Projet CUBE 4 Gestion Stock\GestionDeStock\STIVE_GestionStock\Views\Home\ShowProduct.cshtml"
                Write(Model.Lot_price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n</div>\r\n<div class=\"col\">\r\n    <p>Maison : ");
#nullable restore
#line 39 "C:\Users\yuuma\Desktop\Projet CUBE 4 Gestion Stock\GestionDeStock\STIVE_GestionStock\Views\Home\ShowProduct.cshtml"
           Write(Model.Home.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Product> Html { get; private set; }
    }
}
#pragma warning restore 1591