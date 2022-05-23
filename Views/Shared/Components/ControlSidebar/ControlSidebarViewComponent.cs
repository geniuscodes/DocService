using Microsoft.AspNetCore.Mvc;

namespace DocService.Views.Shared.Components.ControlSidebar
{
    public class ControlSidebarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}