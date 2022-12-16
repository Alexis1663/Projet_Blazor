using BlazorApp1.Models;
using Blazored.LocalStorage;
using Blazorise;
using Blazorise.DataGrid;
using Microsoft.AspNetCore.Components;

namespace BlazorApp1.Pages
{
    public partial class Inventaire
    {
        private int totalTools;
        private Tool[] tools;

        [Inject]
        public HttpClient Http { get; set; }

        //[Inject]
        //public ILocalStorageService LocalStorage { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }


        /*protected override async Task OnInitializedAsync()
        {
            tools = await Http.GetFromJsonAsync<Tool[]>($"{NavigationManager.BaseUri}fake-data-tool.json");
        }
        /*
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

        
        private async Task OnReadData(DataGridReadDataEventArgs<Tool> t)
        {
            if (t.CancellationToken.IsCancellationRequested)
            {
                return;
            }

            var response = (await LocalStorage.GetItemAsync<Tool[]>("data")).Skip((t.Page - 1) * t.PageSize).Take(t.PageSize).ToList();

            if (!t.CancellationToken.IsCancellationRequested)
            {
                totalTools = (await LocalStorage.GetItemAsync<List<Tool>>("data")).Count;
                tools = new List<Tool>(response); // an actual data for the current page
            }
        }*/
    }
}
