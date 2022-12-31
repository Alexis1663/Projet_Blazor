using BlazorApp1.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using BlazorApp1.Models;
using BlazorApp1.Factories;
using Microsoft.Extensions.Localization;

namespace BlazorApp1.Pages
{
    public partial class Edit
    {
        [Inject]
        public IStringLocalizer<Edit> Localizer { get; set; }

        [Parameter]
        public int Id { get; set; }

        /// <summary>
        /// The default enchant categories.
        /// </summary>
        private List<string> EnchantCategories = new List<string>() { "Aura de feu", "Recul", "Puissance", "Durabilité", "Châtiment" };
        private List<string> BuildWith = new List<string>() { "Bâton", "Bois", " Pierre", "Fer", "Or", "Diamand", "Autres" };
        private List<string> RepairWith = new List<string>() { "Bois", "Pierre", "Fer", "Or", "Diamand", "Autre" };

        /// <summary>
        /// The current item model
        /// </summary>
        private ToolModel toolModel = new()
        {
            EnchantCategories = new List<string>(),
            RepairWith = new List<string>(),
            BuildWith = new List<string>()
        };

        [Inject]
        public IDataService DataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IWebHostEnvironment WebHostEnvironment { get; set; }

        [Inject]
        public ILogger<Edit> Logger { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var item = await DataService.GetById(Id);

            var fileContent = await File.ReadAllBytesAsync($"{WebHostEnvironment.WebRootPath}/images/default.png");

            if (File.Exists($"{WebHostEnvironment.WebRootPath}/images/{toolModel.ToolName}.png"))
            {
                fileContent = await File.ReadAllBytesAsync($"{WebHostEnvironment.WebRootPath}/images/{item.ToolName}.png");
            }

            // Set the model with the item
            toolModel = ToolFactory.ToModel(item, fileContent);
        }

        private async void HandleValidSubmit()
        {
            await DataService.Update(Id, toolModel);



            Logger.Log(LogLevel.Information, $"L'outil : {Id} a été modifié");

            //Va recharger la page pour être sur de prendre en compte tous les changements
            NavigationManager.NavigateTo("Inventaire", true);
        }

        private async Task LoadImage(InputFileChangeEventArgs e)
        {
            // Set the content of the image to the model
            using (var memoryStream = new MemoryStream())
            {
                await e.File.OpenReadStream().CopyToAsync(memoryStream);
                toolModel.ImageContent = memoryStream.ToArray();
            }
        }

        private void OnEnchantCategoriesChange(string item, object checkedValue)
        {
            if ((bool)checkedValue)
            {
                if (!toolModel.EnchantCategories.Contains(item))
                {
                    toolModel.EnchantCategories.Add(item);
                }

                return;
            }

            if (toolModel.EnchantCategories.Contains(item))
            {
                toolModel.EnchantCategories.Remove(item);
            }
        }

        private void OnRepairWithChange(string item, object checkedValue)
        {
            if ((bool)checkedValue)
            {
                if (!toolModel.RepairWith.Contains(item))
                {
                    toolModel.RepairWith.Add(item);
                }

                return;
            }

            if (toolModel.RepairWith.Contains(item))
            {
                toolModel.RepairWith.Remove(item);
            }
        }

        private void OnBuildWithChange(string item, object checkedValue)
        {
            if ((bool)checkedValue)
            {
                if (!toolModel.BuildWith.Contains(item))
                {
                    toolModel.BuildWith.Add(item);
                }

                return;
            }

            if (toolModel.BuildWith.Contains(item))
            {
                toolModel.BuildWith.Remove(item);
            }
        }
    }
}
