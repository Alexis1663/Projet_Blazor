using Microsoft.AspNetCore.Components;
using BlazorApp1.Models;
using Blazorise.DataGrid;

namespace BlazorApp1.Pages
{
    public partial class Biome
    {
        private List<BiomeItem> biomes;
        private int totalBiomes;

        [Inject]
        public HttpClient Http { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        private async Task OnReadData(DataGridReadDataEventArgs<BiomeItem> d)
        {
            if (d.CancellationToken.IsCancellationRequested)
            {
                return;
            }

            var reponse = (await Http.GetFromJsonAsync<BiomeItem[]>($"{NavigationManager.BaseUri}biome-fake-data.json")).Skip((d.Page - 1) * d.PageSize).Take(d.PageSize).ToList();

            if (!d.CancellationToken.IsCancellationRequested)
            {
                totalBiomes = (await Http.GetFromJsonAsync<List<BiomeItem>>($"{NavigationManager.BaseUri}biome-fake-data.json")).Count;
                biomes = new List<BiomeItem>(reponse);
            }
        }
    }
}
