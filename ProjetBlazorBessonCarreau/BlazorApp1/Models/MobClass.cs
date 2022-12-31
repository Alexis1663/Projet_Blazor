using System.Diagnostics;

namespace BlazorApp1.Models
{
    public class MobClass
    {
        public enum Type { Hostile, Neutre }

        public Type TypeMob { get; set; }
        public string Name { get; set; }

        public String VersionAjout { get; set; }

        public String Image { get; set; }
    }
}
