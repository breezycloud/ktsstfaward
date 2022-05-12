using ktsstfportal.Client.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;

namespace ktsstfportal.Shared;

public partial class AppBar
{
    [Parameter] public EventCallback<MouseEventArgs> DrawerToggleCallback { get; set; }
    [Parameter] public bool DisplaySearchBar { get; set; }

    [Inject] private NavigationManager NavigationManager { get; set; } = default!;

    [Inject] private LayoutService LayoutService { get; set; } = default!;

    private DialogOptions _dialogOptions = new() { Position = DialogPosition.TopCenter, NoHeader = true };

}