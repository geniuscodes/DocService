using Microsoft.AspNetCore.Mvc;

namespace DocService.Views.Shared.Components.SidebarBrand
{
    public class SidebarBrandViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}