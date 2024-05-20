using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.JSInterop;

namespace IcotakuScrapperDocs.Pages.Anime;

public partial class ScrapSheet : ComponentBase
{
    private string? IcotakuUrl { get; set; } = "https://anime.icotaku.com/anime/5633/Dr-STONE.html";
    private bool IsScrapFromUrlRunning { get; set; }
    private string? ScrapFromUrlError { get; set; }
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
        await Task.Delay(100);
        await JS.InvokeVoidAsync("loadAllHighlight");
        StateHasChanged();
    }

    private void HandleLocationChanged(object? sender, LocationChangedEventArgs e)
    {
        Logger.LogInformation("URL of new location: {Location}", e.Location);
    }

    /// <summary>
    /// Sélectionne l'onglet correspondant à l'ID donné
    /// </summary>
    /// <param name="tabId"></param>
    private async Task SelectTab(int tabId)
    {
        await JS.InvokeVoidAsync("selectTabItem", "#scrap_from_url_tab", tabId);
        StateHasChanged();
    }

    /// <summary>
    /// Exécute le scrap de l'URL donnée
    /// </summary>
    private async Task OnPlaygroundScrapUrl()
    {
        Dictionary<string, string?> results;
//Récupère les informations de l'anime via l'url de la fiche
        var anime = await Anime.ScrapAsync(url, AnimeScrapingOptions.Basic);

        if (anime is null)
        {
            results = new Dictionary<string, string?>
            {
                {"Erreur", "L'anime n'a pas été trouvé"}
            };
    
            return results;
        }

        results =  new Dictionary<string, string?>
        {
            {"Nom", anime.Name},
            {"Nombre d'épisodes", anime.EpisodeCount.ToString()},
            {"Synopsis", anime.Synopsis},
            {"Date de sortie", anime.ReleaseDate.ToString()}
        };

        return results;
    }

    public void Dispose()
    {
        Navigation.LocationChanged -= HandleLocationChanged;
    }
}