using BlazorApp1.Models;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;

namespace BlazorApp1.Pages
{
    public partial class Inventaire
    {
        private List<Tool> tools;

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

            var currentData = await LocalStorage.GetItemAsync<Tool[]>("data");

            // Check if data exist in the local storage
            if (currentData == null)
            {
                // this code add in the local storage the fake data (we load the data sync for initialize the data before load the OnReadData method)
                var originalData = Http.GetFromJsonAsync<Tool[]>($"{NavigationManager.BaseUri}fake-data.json").Result;
                await LocalStorage.SetItemAsync("data", originalData);
            }
        }

        private async Task OnReadData(DataGridReadDataEventArgs<Item> e)
        {
            if (e.CancellationToken.IsCancellationRequested)
            {
                return;
            }

            // When you use a real API, we use this follow code
            //var response = await Http.GetJsonAsync<Data[]>( $"http://my-api/api/data?page={e.Page}&pageSize={e.PageSize}" );
            var response = (await LocalStorage.GetItemAsync<Tool[]>("data")).Skip((e.Page - 1) * e.PageSize).Take(e.PageSize).ToList();

            if (!e.CancellationToken.IsCancellationRequested)
            {
                totalItem = (await LocalStorage.GetItemAsync<List<Tool>>("data")).Count;
                tools = new List<Tool>(response); // an actual data for the current page
            }
        }
    }
}
}
