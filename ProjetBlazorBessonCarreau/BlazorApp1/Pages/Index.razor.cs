using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace BlazorApp1.Pages
{
    public partial class Index
    {
        [Inject]
        public IStringLocalizer<Index> Localizer { get; set; }
    }
}
