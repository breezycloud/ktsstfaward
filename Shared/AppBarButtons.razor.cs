using ktsstfportal.Client.Services;
using Microsoft.AspNetCore.Components;

namespace ktsstfportal.Shared;

public partial class AppBarButtons
{    
    [Inject] private LayoutService LayoutService { get; set; } = default!;    
    protected override async Task OnInitializedAsync()
    {    
        await base.OnInitializedAsync();
    }    
}