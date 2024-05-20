using System.Runtime.InteropServices.JavaScript;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.JSInterop;

namespace IcotakuScrapperDocs.Layout;

public partial class MainLayout : LayoutComponentBase
{
    private async Task ToggleTheme()
    {
        await JS.InvokeVoidAsync("toggleTheme");
        StateHasChanged();
    }
    
    private void NavigateToCounterComponent()
    {
        Navigation.NavigateTo("counter");
    }

    protected override void OnInitialized()
    {
        Navigation.LocationChanged += HandleLocationChanged;
    }

    protected override async Task OnInitializedAsync()
    {
        await JS.InvokeVoidAsync("loadAllHighlight");
        StateHasChanged();
    }

    private void HandleLocationChanged(object? sender, LocationChangedEventArgs e)
    {
        Logger.LogInformation("URL of new location: {Location}", e.Location);
    }

    public void Dispose()
    {
        Navigation.LocationChanged -= HandleLocationChanged;
    }
}