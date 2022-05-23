using Microsoft.AspNetCore.Mvc;

namespace DocService.Views.Shared.Components.SidebarMenu
{
    public class SidebarMenuViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}