using BlazorApp1.Models;
using BlazorApp1.Services;
using Blazored.LocalStorage;
using Blazorise;
using Blazorise.DataGrid;
using Microsoft.AspNetCore.Components;
using System.Diagnostics;

namespace BlazorApp1.Pages
{
    public partial class Inventaire
    {
        private int totalTools;
        private List<Tool> tools;

        [Inject]
        public HttpClient Http { get; set; }

        [Inject]
        public IDataService DataService { get; set; }


        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IWebHostEnvironment WebHostEnvironment { get; set; }


        private async Task OnReadData(DataGridReadDataEventArgs<Tool> e)
        {
            if (e.CancellationToken.IsCancellationRequested)
            {
                return;
            }

            if (!e.CancellationToken.IsCancellationRequested)
            {
                tools = await DataService.List(e.Page, e.PageSize);
                totalTools = await DataService.Count();
            }
        }
    }
}
