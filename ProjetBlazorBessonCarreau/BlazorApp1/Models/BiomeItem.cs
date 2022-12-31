namespace BlazorApp1.Models
{
    public class BiomeItem
    {
        public int Id { get; set; }
        public enum Env { Hostile, Paysible }

        public String Nom { get; set; }

        public String VersionAjout { get; set; }

        public Env Environemment { get; set; }

        public String Image { get; set; }

        public List<MobClass> Mobs { get; set; }
    }
}
