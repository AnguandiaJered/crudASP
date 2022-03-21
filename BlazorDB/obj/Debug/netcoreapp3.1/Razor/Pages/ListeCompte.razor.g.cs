#pragma checksum "E:\Projet web\banque\BlazorDB\BlazorDB\Pages\ListeCompte.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6a098e7be45baf1869d5080a1ad734c2b2dbd244"
// <auto-generated/>
#pragma warning disable 1591
namespace BlazorDB.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "E:\Projet web\banque\BlazorDB\BlazorDB\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Projet web\banque\BlazorDB\BlazorDB\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\Projet web\banque\BlazorDB\BlazorDB\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "E:\Projet web\banque\BlazorDB\BlazorDB\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "E:\Projet web\banque\BlazorDB\BlazorDB\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "E:\Projet web\banque\BlazorDB\BlazorDB\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "E:\Projet web\banque\BlazorDB\BlazorDB\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "E:\Projet web\banque\BlazorDB\BlazorDB\_Imports.razor"
using BlazorDB;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "E:\Projet web\banque\BlazorDB\BlazorDB\_Imports.razor"
using BlazorDB.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "E:\Projet web\banque\BlazorDB\BlazorDB\Pages\ListeCompte.razor"
using BlazorDB.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Projet web\banque\BlazorDB\BlazorDB\Pages\ListeCompte.razor"
using BlazorDB.Data.Interfaces;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/Listcompte")]
    public partial class ListeCompte : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h3>Liste des comptes</h3>\r\n");
            __builder.AddMarkupContent(1, "<a href=\"#\" class=\"btn btn-primary offset-10\">Ajouter un compte</a>\r\n\r\n");
#nullable restore
#line 10 "E:\Projet web\banque\BlazorDB\BlazorDB\Pages\ListeCompte.razor"
 if (compte == null)
{

#line default
#line hidden
#nullable disable
            __builder.AddContent(2, "    ");
            __builder.AddMarkupContent(3, "<p>loading...</p>\r\n");
#nullable restore
#line 13 "E:\Projet web\banque\BlazorDB\BlazorDB\Pages\ListeCompte.razor"
}
else
{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(4, "table");
            __builder.AddAttribute(5, "class", "table table-bordered table-striped mt-5");
            __builder.AddMarkupContent(6, "\r\n    ");
            __builder.AddMarkupContent(7, "<thead>\r\n    <th>Numero Compte</th>\r\n    <th>Type Compte</th>\r\n    <th>Date create</th>\r\n    <th>Solde</th>\r\n    <th>Clients</th>\r\n    <th>Author</th>\r\n    <th>Actions</th>\r\n    </thead>\r\n    ");
            __builder.OpenElement(8, "tbody");
            __builder.AddMarkupContent(9, "\r\n");
#nullable restore
#line 27 "E:\Projet web\banque\BlazorDB\BlazorDB\Pages\ListeCompte.razor"
         foreach (var e in compte)
        {

#line default
#line hidden
#nullable disable
            __builder.AddContent(10, "            ");
            __builder.OpenElement(11, "tr");
            __builder.AddMarkupContent(12, "\r\n                ");
            __builder.OpenElement(13, "td");
            __builder.AddContent(14, 
#nullable restore
#line 30 "E:\Projet web\banque\BlazorDB\BlazorDB\Pages\ListeCompte.razor"
                     e.NumCompte

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(15, "\r\n                ");
            __builder.OpenElement(16, "td");
            __builder.AddContent(17, 
#nullable restore
#line 31 "E:\Projet web\banque\BlazorDB\BlazorDB\Pages\ListeCompte.razor"
                     e.TypeCompte

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(18, "\r\n                ");
            __builder.OpenElement(19, "td");
            __builder.AddContent(20, 
#nullable restore
#line 32 "E:\Projet web\banque\BlazorDB\BlazorDB\Pages\ListeCompte.razor"
                     e.DateCreate

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(21, "\r\n                ");
            __builder.OpenElement(22, "td");
            __builder.AddContent(23, 
#nullable restore
#line 33 "E:\Projet web\banque\BlazorDB\BlazorDB\Pages\ListeCompte.razor"
                     e.Solde

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(24, "\r\n                ");
            __builder.OpenElement(25, "td");
            __builder.AddContent(26, 
#nullable restore
#line 34 "E:\Projet web\banque\BlazorDB\BlazorDB\Pages\ListeCompte.razor"
                     e.ClientName

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(27, "\r\n                ");
            __builder.OpenElement(28, "td");
            __builder.AddContent(29, 
#nullable restore
#line 35 "E:\Projet web\banque\BlazorDB\BlazorDB\Pages\ListeCompte.razor"
                     e.Author

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(30, "\r\n                ");
            __builder.AddMarkupContent(31, "<td>\r\n                    <a class=\"btn btn-primary oi oi-pencil\" href=\"#\">Edit</a>\r\n                    <a class=\"btn btn-danger oi oi-trash\" href=\"#\">Delete</a>\r\n                </td>\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(32, "\r\n");
#nullable restore
#line 41 "E:\Projet web\banque\BlazorDB\BlazorDB\Pages\ListeCompte.razor"
        }

#line default
#line hidden
#nullable disable
            __builder.AddContent(33, "    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(34, "\r\n");
            __builder.CloseElement();
            __builder.AddMarkupContent(35, "\r\n");
#nullable restore
#line 44 "E:\Projet web\banque\BlazorDB\BlazorDB\Pages\ListeCompte.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 46 "E:\Projet web\banque\BlazorDB\BlazorDB\Pages\ListeCompte.razor"
       
    IEnumerable<CompteModel> compte;

    protected override async Task OnInitializedAsync()
    {
        compte = await CompteService.GetCompte();
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ICompteService CompteService { get; set; }
    }
}
#pragma warning restore 1591