#pragma checksum "E:\Projet web\crudASP\BlazorDB\BlazorDB\Pages\EditCity.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "83526df9dfcd43b27e397548e6fde70ecc8d69a9"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace BlazorDB.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "E:\Projet web\crudASP\BlazorDB\BlazorDB\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Projet web\crudASP\BlazorDB\BlazorDB\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\Projet web\crudASP\BlazorDB\BlazorDB\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "E:\Projet web\crudASP\BlazorDB\BlazorDB\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "E:\Projet web\crudASP\BlazorDB\BlazorDB\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "E:\Projet web\crudASP\BlazorDB\BlazorDB\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "E:\Projet web\crudASP\BlazorDB\BlazorDB\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "E:\Projet web\crudASP\BlazorDB\BlazorDB\_Imports.razor"
using BlazorDB;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "E:\Projet web\crudASP\BlazorDB\BlazorDB\_Imports.razor"
using BlazorDB.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "E:\Projet web\crudASP\BlazorDB\BlazorDB\Pages\EditCity.razor"
using BlazorDB.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Projet web\crudASP\BlazorDB\BlazorDB\Pages\EditCity.razor"
using BlazorDB.Data.Interfaces;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/editcity/{id:int}")]
    public partial class EditCity : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 38 "E:\Projet web\crudASP\BlazorDB\BlazorDB\Pages\EditCity.razor"
       
    [Parameter]
    public int id { get; set; }
    City city = new City();
    protected override async Task OnInitializedAsync()
    {
        city = await CityService.SingleCity(id);
    }
    protected async Task UpdateCity()
    {
        await CityService.EditCity(id, city);
        NavigationManager.NavigateTo("ListeCities");
    }
    void Fermer()
    {
        NavigationManager.NavigateTo("ListeCities");
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ICityService CityService { get; set; }
    }
}
#pragma warning restore 1591
