using BlazorApp1.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using static System.Net.WebRequestMethods;

namespace BlazorApp1.Components
{
    public partial class BiomeMobs
    {
        //Identifiant du biome choisi
        [Parameter]
        public int Id { get; set; }

        [Inject]
        public HttpClient Http { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }


        public MobClass CurrentDragItem { get; set; }

        [Parameter]
        //Monstres présents dans le biome
        public List<MobClass> Items { get; set; }


        //Monstres disponibles
        public List<MobClass> AvailableMobs { get; set; }


        [Parameter]
        public List<BMobs> Recipes { get; set; }

        /// <summary>
        /// Gets or sets the java script runtime.
        /// </summary>
        [Inject]
        internal IJSRuntime JavaScriptRuntime { get; set; }

        protected override async Task OnInitializedAsync()
        {
            BiomeItem[] biomes = (await Http.GetFromJsonAsync<BiomeItem[]>($"{NavigationManager.BaseUri}biome-fake-data.json"));
            AvailableMobs = (await Http.GetFromJsonAsync<MobClass[]>($"{NavigationManager.BaseUri}AvailableMobs.json")).ToList();
            Items = biomes[Id].Mobs;
        }



        public void AddMob(MobClass mob)
        {
            Items.Add(mob);
            StateHasChanged();
        }

        

        private void OnActionsCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            JavaScriptRuntime.InvokeVoidAsync("BiomeMobs.AddActions", e.NewItems);
        }
    }
}
