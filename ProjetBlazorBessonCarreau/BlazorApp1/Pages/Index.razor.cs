using BlazorApp1.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace BlazorApp1.Pages
{
    public partial class Index
    {

        public List<MobClass> Mobs { get; set;  }

        [Inject]
        public IStringLocalizer<Index> Localizer { get; set; }

        protected override Task OnAfterRenderAsync(bool firstRender)
        {
            LoadMobs();
            StateHasChanged();
            return base.OnAfterRenderAsync(firstRender);
        }

        public void LoadMobs()
        {
            Mobs = new List<MobClass>
            {
                new MobClass
                {
                    Name = "Pigman",
                    Image = "Image pigman"
                },
            };
        }


    }
}