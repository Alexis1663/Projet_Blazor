using BlazorApp1.Models;
using Microsoft.AspNetCore.Components.Forms;

namespace BlazorApp1.Pages
{
    public partial class AddInventaire
    {

        private List<string> EnchantCategories = new List<string>() { "Aura de feu", "Recul", "Puissance", "Durabilité", "Châtiment" };
        private List<string> BuildWith = new List<string>() { "Bâton", "Bois", " Pierre", "Fer", "Or", "Diamand", "Autres" };
        private List<string> RepairWith = new List<string>() { "Bois", "Pierre", "Fer", "Or", "Diamand", "Autre" };


        private ToolModel tool = new()
        {
            
            EnchantCategories = new List<string>(),
            RepairWith = new List<string>()
        };

        private async void HandleValidSubmit()
        {

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
    }
}
