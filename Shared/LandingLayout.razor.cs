using System;
using Microsoft.AspNetCore.Components;
using ktsstfportal.Client.AppTheme;
using ktsstfportal.Client.Services;

namespace ktsstfportal.Shared
{
    public partial class LandingLayout : LayoutComponentBase
    {
        private string? OptionSelected { get; set; } = "AppNo";
        private string? UserEntry { get; set; }
        [Inject] protected LayoutService LayoutService { get; set; } = default!;
        
        private bool _drawerOpen = false;
        
        protected override void OnInitialized()
        {
            LayoutService.SetBaseTheme(Theme.LandingPageTheme());

            base.OnInitialized();
        }
        
        private void ToggleDrawer()
        {
            _drawerOpen = !_drawerOpen;
        }

    }
}