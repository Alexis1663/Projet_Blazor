using Microsoft.AspNetCore.Components;
using BlazorApp1.Models;

namespace BlazorApp1.Pages
{
    public partial class Biome
    {
        private BiomeItem[] biomes;

        [Inject]
        public HttpClient Http { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {

            biomes = await Http.GetFromJsonAsync<BiomeItem[]>($"{NavigationManager.BaseUri}biome-fake-data.json");
        }
    }
}
