using BlazorApp1.Models;
using Blazorise;
using Microsoft.AspNetCore.Components;

namespace BlazorApp1.Components
{
    public partial class GestionMob
    {
        [Parameter]
        public int Index { get; set; }

        [Parameter]
        public MobClass mob { get; set; }

        [Parameter]
        public bool NoDrop { get; set; }

        [CascadingParameter]
        public BiomeMobs Parent { get; set; }

        internal void OnDragEnter()
        {
            if (NoDrop)
            {
                return;
            }
        }

        internal void OnDragLeave()
        {
            if (NoDrop)
            {
                return;
            }
        }

        internal void OnDrop()
        {
            if (NoDrop)
            {
                return;
            }

            this.mob = Parent.CurrentDragItem;

            //Ajoute le monstre aux monstres présents dans le biome
            Parent.AddMob(this.mob);
        }

        private void OnDragStart()
        {
            Parent.CurrentDragItem = this.mob;

        }
    }
}
