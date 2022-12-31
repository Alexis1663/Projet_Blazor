using BlazorApp1.Pages;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp1.Models
{
    public class ToolModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Il est nécessaire de renseigner le nom de l'outil !")]
        [StringLength(30, ErrorMessage = "Le nom de l'objet ne doit pas dépasser 30 caractères.")]
        public string ToolName { get; set; }

        [Required(ErrorMessage = "Aucune durabilité renseignée !")]
        [Range(1, 200, ErrorMessage = "La durabilité est comprise entre 1 et 200")]
        public int ToolMaxDurability { get; set; }

        public List<string> EnchantCategories { get; set; }

        public List<string> RepairWith { get; set; }

        public List<string> BuildWith { get; set; }

        [Required(ErrorMessage = "Il est nécessaire d'ajouter une image pour l'outil !")]
        public byte[] ImageContent { get; set; }

    }
}
