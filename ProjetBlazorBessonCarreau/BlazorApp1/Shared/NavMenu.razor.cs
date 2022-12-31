using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace BlazorApp1.Shared
{
    public partial class NavMenu
    {
        [Inject]
        public IStringLocalizer<NavMenu> Localizer { get; set; }
    }
}
