using ktsstfportal.Client.AppTheme;
using ktsstfportal.Client.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using ktsstfportal.Shared;

namespace ktsstfportal.Shared;
public partial class MainLayout : LayoutComponentBase, IDisposable
{
    [Inject] private LayoutService? LayoutService { get; set; }

    private MudThemeProvider? _mudThemeProvider;

    protected override void OnInitialized()
    {
        LayoutService!.SetBaseTheme(Theme.DocsTheme());
        LayoutService.MajorUpdateOccured += LayoutServiceOnMajorUpdateOccured!;
        base.OnInitialized();
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            await ApplyUserPreferences();
            StateHasChanged();
        }
    }

    private async Task ApplyUserPreferences()
    {
        var defaultDarkMode = await _mudThemeProvider!.GetSystemPreference();
        await LayoutService!.ApplyUserPreferences(defaultDarkMode);
    }

    public void Dispose()
    {
        LayoutService!.MajorUpdateOccured -= LayoutServiceOnMajorUpdateOccured!;
    }

    private void LayoutServiceOnMajorUpdateOccured(object sender, EventArgs e) => StateHasChanged();
}