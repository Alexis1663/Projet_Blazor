using BlazorApp1.Models;

namespace BlazorApp1.Components
{
    //Représente les mobs présents dans un biome
    public class BMobs
    {
        public int IdBiome { get; set; }    //Id du biome
        public List<MobClass> MobsinBiome { get; set; }   //Mobs présents dans le biome
    }
}
