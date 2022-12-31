using Microsoft.AspNetCore.Components;
using BlazorApp1.Models;
using Blazorise.DataGrid;
using Blazored.LocalStorage;
using Blazorise;

namespace BlazorApp1.Pages
{
    public partial class Biome
    {
        private List<BiomeItem> biomes;
        private int totalBiomes;

        [Inject]
        public HttpClient Http { get; set; }

        [Inject]
        public ILocalStorageService LocalStorage { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            // Do not treat this action if is not the first render
            if (!firstRender)
            {
                return;
            }

            var currentData = await LocalStorage.GetItemAsync<BiomeItem[]>("dataBiome");

            // Check if data exist in the local storage
            if (currentData == null)
            {
                // this code add in the local storage the fake data (we load the data sync for initialize the data before load the OnReadData method)
                var originalData = Http.GetFromJsonAsync<BiomeItem[]>($"{NavigationManager.BaseUri}biome-fake-data.json").Result;
                await LocalStorage.SetItemAsync("dataBiome", originalData);
            }
        }

        private async Task OnReadData(DataGridReadDataEventArgs<BiomeItem> d)
        {
            if (d.CancellationToken.IsCancellationRequested)
            {
                return;
            }

            // When you use a real API, we use this follow code
            //var response = await Http.GetJsonAsync<Data[]>( $"http://my-api/api/data?page={e.Page}&pageSize={e.PageSize}" );
            var response = (await LocalStorage.GetItemAsync<BiomeItem[]>("dataBiome")).Skip((d.Page - 1) * d.PageSize).Take(d.PageSize).ToList();

            if (!d.CancellationToken.IsCancellationRequested)
            {
                totalBiomes = (await LocalStorage.GetItemAsync<List<BiomeItem>>("dataBiome")).Count;
                biomes = new List<BiomeItem>(response); // an actual data for the current page
            }

        }
    }
}
