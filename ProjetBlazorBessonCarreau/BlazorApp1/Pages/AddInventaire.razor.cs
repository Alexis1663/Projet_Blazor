using BlazorApp1.Models;
using BlazorApp1.Services;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Hosting;

using Microsoft.Extensions.Localization;

namespace BlazorApp1.Pages
{
    public partial class AddInventaire
    {

        private List<string> EnchantCategories = new List<string>() { "Aura de feu", "Recul", "Puissance", "Durabilité", "Châtiment" };
        private List<string> BuildWith = new List<string>() { "Bâton", "Bois", " Pierre", "Fer", "Or", "Diamand", "Autres" };
        private List<string> RepairWith = new List<string>() { "Bois", "Pierre", "Fer", "Or", "Diamand", "Autre" };

        [Inject]
        public IStringLocalizer<AddInventaire> Localizer { get; set; }

        [Inject]
        public ILogger<AddInventaire> Logger { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IDataService DataService { get; set; }

        [Inject]
        public IWebHostEnvironment WebHostEnvironment { get; set; }


        [Inject]
        public ILogger<AddInventaire> Logger { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IDataService DataService { get; set; }

        [Inject]
        public IWebHostEnvironment WebHostEnvironment { get; set; }


        private ToolModel tool = new()
        {
            
            EnchantCategories = new List<string>(),
            RepairWith = new List<string>(),
            BuildWith= new List<string>()
        };

        private async void HandleValidSubmit()
        {
            await DataService.Add(tool);


            Logger.Log(LogLevel.Information, $"Un nouvel outil a été créé : Id : {tool.Id}, Nom : {tool.ToolName}, Durabilité : {tool.ToolMaxDurability}, Enchantements : {tool.EnchantCategories.Count}, Ingrédients : {tool.BuildWith.Count}, Réparations : {tool.RepairWith.Count}");
            NavigationManager.NavigateTo("Inventaire");
        }

        private async Task LoadImage(InputFileChangeEventArgs e)
        {
            // Set the content of the image to the model
            using (var memoryStream = new MemoryStream())
            {
                await e.File.OpenReadStream().CopyToAsync(memoryStream);
                tool.ImageContent = memoryStream.ToArray();
            }
        }

        private void OnEnchantCategoriesChange(string item, object checkedValue)
        {
            if ((bool)checkedValue)
            {
                if (!tool.EnchantCategories.Contains(item))
                {
                    tool.EnchantCategories.Add(item);
                }

                return;
            }

            if (tool.EnchantCategories.Contains(item))
            {
                tool.EnchantCategories.Remove(item);
            }
        }

        private void OnRepairWithChange(string item, object checkedValue)
        {
            if ((bool)checkedValue)
            {
                if (!tool.RepairWith.Contains(item))
                {
                    tool.RepairWith.Add(item);
                }

                return;
            }

        }

        private void OnBuildWithChange(string item, object checkedValue)
        {
            if ((bool)checkedValue)
            {
                if (!tool.BuildWith.Contains(item))
                {
                    tool.BuildWith.Add(item);
                }

                return;
            }

        }


        private void CreateLog()
        {
            ///var logLevels = Enum.
        }
    }
}
