using BlazorApp1.Models;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using static System.Net.WebRequestMethods;

namespace BlazorApp1.Components
{
    public partial class BiomeMobs
    {
        //Identifiant du biome choisi, il est récupéré lorsque l'utilisateur clique sur un biome pour en connaître les mobs
        [Parameter]
        public int IdBiome { get; set; }

        [Inject]
        public HttpClient Http { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        //Le mob actuellement pris par la drag and drop
        public MobClass CurrentDragItem { get; set; }

        [Parameter]
        //Monstres présents dans le biome
        public List<MobClass> Items { get; set; }

        //Tableau des biomes 
        public BiomeItem[] Biomes { get; set; }

        //Monstres disponibles
        public List<MobClass> AvailableMobs { get; set; }

        [Inject]
        public ILocalStorageService LocalStorage { get; set; }


        [Parameter]
        public List<BMobs> Recipes { get; set; }

        /// <summary>
        /// Gets or sets the java script runtime.
        /// </summary>
        [Inject]
        internal IJSRuntime JavaScriptRuntime { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstrender)
        {
            //En essayant d'utiliser OnInitializedAsync ici, il y a un bug en essayant de récupréer les données de biome, mais étrangement, il ne se manifeste que si la ligne avec "Items" n'est pas commentée
            //Cependant,  en utilisant OnAfterRenderAsync, aucune données ne s'affiche bien que le bug ne se présente pas (même les mobs dispos ne sont pas montrés)
            Biomes = await LocalStorage.GetItemAsync<BiomeItem[]>("dataBiome");
            AvailableMobs = (await Http.GetFromJsonAsync<MobClass[]>($"{NavigationManager.BaseUri}AvailableMobs.json")).ToList();
            Items = Biomes[IdBiome].Mobs;
        }



        public void AddMob(MobClass mob)
        {
            //créer une méthode pour ajouter le mob dans le biome (peut être avec la DataService)
            Items.Add(mob);
            StateHasChanged();
        }

        

        private void OnActionsCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            JavaScriptRuntime.InvokeVoidAsync("BiomeMobs.AddActions", e.NewItems);
        }
    }
}
