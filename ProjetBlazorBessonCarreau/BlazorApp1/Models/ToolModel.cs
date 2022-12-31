using BlazorApp1.Pages;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp1.Models
{
    public class ToolModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Il est n�cessaire de renseigner le nom de l'outil !")]
        [StringLength(30, ErrorMessage = "Le nom de l'objet ne doit pas d�passer 30 caract�res.")]
        public string ToolName { get; set; }

        [Required(ErrorMessage = "Aucune durabilité renseignée !")]
        [Range(1, 200, ErrorMessage = "La durabilité est comprise entre 1 et 200")]
        [Required(ErrorMessage = "Aucune durabilit� renseign�e !")]
        [Range(1, 200, ErrorMessage = "La durabilit� est comprise entre 1 et 200")]
        public int ToolMaxDurability { get; set; }

        public List<string> EnchantCategories { get; set; }

        public List<string> RepairWith { get; set; }

        public List<string> BuildWith { get; set; }


        [Required(ErrorMessage = "Il est n�cessaire d'ajouter une image pour l'outil !")]

        public byte[] ImageContent { get; set; }

    }
}
