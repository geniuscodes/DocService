using Microsoft.AspNetCore.Mvc;

namespace DocService.Views.Shared.Components.HeaderNotificationsMenu
{
    public class HeaderNotificationsMenuViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}