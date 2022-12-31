using BlazorApp1.Modals;
using BlazorApp1.Models;
using BlazorApp1.Services;
using Blazored.LocalStorage;
using Blazored.Modal;
using Blazored.Modal.Services;
using Blazorise.DataGrid;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;

namespace BlazorApp1.Pages
{
    public partial class Inventaire
    {
        private int totalTools;
        private List<Tool> tools;

        [Inject]
        public ILogger<Inventaire> Logger { get; set; }

        [Inject]
        public HttpClient Http { get; set; }

        [Inject]
        public IDataService DataService { get; set; }


        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [CascadingParameter]
        public IModalService Modal { get; set; }

        [Inject]
        public IWebHostEnvironment WebHostEnvironment { get; set; }


        [Inject]
        public IStringLocalizer<Inventaire> Localizer { get; set; }


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

        private async void OnDelete(int id)
        {
            var parameters = new ModalParameters();
            
            parameters.Add(nameof(Tool.Id), id);

            var modal = Modal.Show<DeleteConfirmation>("Delete Confirmation", parameters);
            var result = await modal.Result;

            if (result.Cancelled)
            {
                return;
            }

            await DataService.Delete(id);

            Logger.Log(LogLevel.Information, $"Un outil a été supprimé : Identifiant de l'outil supprimé : {id}");
            // Reload the page
            NavigationManager.NavigateTo("Inventaire", true);
        }
    }
}